using PFC.App.Helper; 
using PFC.Domain.Models;
using PFC.Services;   
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace PFC.App.Forms
{
    public partial class AddProductForm : Form
    {
        // ==========================================
        // FIELDS & PROPERTIES
        // ==========================================
        #region Fields & Properties

        private BindingList<ProductSizeOption> _sizeOptions = new BindingList<ProductSizeOption>();

        #endregion

        // ==========================================
        // CONSTRUCTOR
        // ==========================================
        #region Constructor

        public AddProductForm()
        {
            InitializeComponent();
        }

        #endregion

        // ==========================================
        // SETUP METHODS
        // ==========================================
        #region Setup Methods

        private void AddProductForm_Load(object sender, EventArgs e)
        {
            // DESIGNER FIX
            if (UIHelper.IsDesignMode()) return;

            // 1. Configure SIZE combo column with your Translator!
            if (dataGridView1.Columns["Sizeoption"] is DataGridViewComboBoxColumn sizeCol)
            {
                // Generates a list mapping Enum (EightOz) -> Text ("8 Ounces")
                var sizeDisplayList = Enum.GetValues(typeof(ProductSize))
                                          .Cast<ProductSize>()
                                          .Select(s => new { Value = s, Text = s.ToFriendlyString() })
                                          .ToList();

                sizeCol.DataSource = sizeDisplayList;
                sizeCol.DisplayMember = "Text";
                sizeCol.ValueMember = "Value";

                sizeCol.DataPropertyName = nameof(ProductSizeOption.Size);
                sizeCol.ValueType = typeof(ProductSize);
            }

            if (dataGridView1.Columns["Price"] is DataGridViewColumn priceCol)
            {
                priceCol.DataPropertyName = nameof(ProductSizeOption.Price);
            }

            if (dataGridView1.Columns["Cost"] is DataGridViewColumn costCol)
            {
                costCol.DataPropertyName = nameof(ProductSizeOption.Cost);
            }

            // 2. Grid Settings
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.DataSource = _sizeOptions;

            // 3. Bind CATEGORY combobox with your Regex Formatter!
            // Generates a list mapping Enum (IcedCoffee) -> Text ("Iced Coffee")
            var categoryList = Enum.GetValues(typeof(Category))
                                   .Cast<Category>()
                                   .Select(c => new { Value = c, Text = UIHelper.FormatEnumName(c.ToString()) })
                                   .ToList();

            cmbCategory.DataSource = categoryList;
            cmbCategory.DisplayMember = "Text";
            cmbCategory.ValueMember = "Value";

            // 4. Start with one row
            if (_sizeOptions.Count == 0)
            {
                _sizeOptions.Add(new ProductSizeOption { Size = ProductSize.EightOz, Price = 0m, Cost = 0m });
            }
        }

        #endregion

        // ==========================================
        // EVENT HANDLERS
        // ==========================================
        #region Event Handlers

        // --- Grid Actions ---

        private void SfRoundedButtonAddSize_Click(object? sender, EventArgs e)
        {
            _sizeOptions.Add(new ProductSizeOption { Size = ProductSize.EightOz, Price = 0m, Cost = 0m });

            var idx = _sizeOptions.Count - 1;
            dataGridView1.CurrentCell = dataGridView1.Rows[idx].Cells["Sizeoption"];
            dataGridView1.BeginEdit(true);
        }

        private void DataGridView1_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var col = dataGridView1.Columns[e.ColumnIndex];

            if (string.Equals(col.Name, "Actions", StringComparison.OrdinalIgnoreCase))
            {
                var item = dataGridView1.Rows[e.RowIndex].DataBoundItem as ProductSizeOption;
                if (item != null)
                {
                    // HELPER: Replaced raw MessageBox with UIHelper
                    if (UIHelper.Confirm("Remove this size option?"))
                    {
                        _sizeOptions.Remove(item);
                    }
                }
            }
        }

        // --- Save & Cancel Actions ---

        private void btnSave_Click(object? sender, EventArgs e)
        {
            // 1. Basic Validation (Uses the new ShowWarning helper!)
            var name = txtName.Text?.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                UIHelper.ShowWarning("Please enter a product name.");
                return;
            }

            if (_sizeOptions == null || _sizeOptions.Count == 0)
            {
                UIHelper.ShowWarning("Please add at least one size option with price and cost.");
                return;
            }

            // 2. Check for Duplicate Sizes
            var duplicateSizes = _sizeOptions.GroupBy(s => s.Size).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
            if (duplicateSizes.Any())
            {
                var duplicateNames = string.Join(", ", duplicateSizes.Select(s => s.ToFriendlyString()));
                UIHelper.ShowWarning($"Duplicate sizes found: {duplicateNames}. Remove duplicates.");
                return;
            }

            // 3. Validate Prices and Costs
            foreach (var so in _sizeOptions)
            {
                if (so.Price <= 0m)
                {
                    UIHelper.ShowWarning("Each size option must have a price greater than 0.");
                    return;
                }
                if (so.Cost < 0m)
                {
                    UIHelper.ShowWarning("Cost cannot be negative.");
                    return;
                }
            }

            // Since we bound an anonymous object to the combobox, we have to grab the 'Value' property
            if (cmbCategory.SelectedValue is not Category category)
            {
                UIHelper.ShowWarning("Please select a category.");
                return;
            }

            // 4. Map to Domain Model
            var product = new Product
            {
                Name = name,
                Category = category
            };

            product.SizeOptions = _sizeOptions
                .Select(so => new ProductSizeOption
                {
                    Size = so.Size,
                    Price = so.Price,
                    Cost = so.Cost
                })
                .ToList();

            // 5. Save using your new ProductService!
            try
            {
                var productService = new ProductService();
                productService.AddProduct(product);
            }
            catch (Exception ex)
            {
                UIHelper.ShowError($"Error saving product: {ex.Message}");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion
    }
}