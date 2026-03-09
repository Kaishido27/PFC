using PFC.App.Helper; 
using PFC.Domain.Models;
using PFC.Services;   
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PFC.App.Forms
{
    public partial class EditProductForm : Form
    {
        // ==========================================
        // FIELDS & PROPERTIES
        // ==========================================
        #region Fields & Properties

        private readonly int _productId;
        private BindingList<ProductSizeOption> _sizeOptions = new BindingList<ProductSizeOption>();

        #endregion

        // ==========================================
        // CONSTRUCTOR
        // ==========================================
        #region Constructor

        public EditProductForm(int productId)
        {
            InitializeComponent();
            _productId = productId;
        }

        #endregion

        // ==========================================
        // SETUP METHODS
        // ==========================================
        #region Setup Methods

        private void EditProductForm_Load(object sender, EventArgs e)
        {
            // DESIGNER FIX
            if (UIHelper.IsDesignMode()) return;

            // 1. Configure SIZE combo column with Translator!
            if (dataGridView1.Columns["Sizeoption"] is DataGridViewComboBoxColumn sizeCol)
            {
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

            // 3. Bind CATEGORY combobox with Regex Formatter!
            var categoryList = Enum.GetValues(typeof(Category))
                                   .Cast<Category>()
                                   .Select(c => new { Value = c, Text = UIHelper.FormatEnumName(c.ToString()) })
                                   .ToList();

            cmbCategory.DataSource = categoryList;
            cmbCategory.DisplayMember = "Text";
            cmbCategory.ValueMember = "Value";

            // 4. Load Existing Product Data
            LoadProductData();
            dataGridView1.DataSource = _sizeOptions;
        }

        private void LoadProductData()
        {
            try
            {
                // USES PRODUCT SERVICE INSTEAD OF DB CONTEXT
                var productService = new ProductService();
                var product = productService.GetProductById(_productId);

                if (product == null)
                {
                    UIHelper.ShowError("Product not found.");
                    Close();
                    return;
                }

                // Populate UI
                txtName.Text = product.Name;
                cmbCategory.SelectedValue = product.Category;

                _sizeOptions.Clear();
                foreach (var option in product.SizeOptions)
                {
                    _sizeOptions.Add(new ProductSizeOption
                    {
                        Size = option.Size,
                        Price = option.Price,
                        Cost = option.Cost
                    });
                }

                // Archive/Restore Button Styling 
                if (product.IsArchived)
                {
                    btnDeleteProduct.Text = "Restore Product";
                    btnDeleteProduct.Style.BackColor = Color.ForestGreen;
                    btnDeleteProduct.Style.FocusedBackColor = Color.ForestGreen;
                    btnDeleteProduct.Style.HoverBackColor = Color.ForestGreen;
                }
                else
                {
                    btnDeleteProduct.Text = "Delete Product";
                    btnDeleteProduct.Style.BackColor = Color.IndianRed;
                    btnDeleteProduct.Style.FocusedBackColor = Color.IndianRed;
                    btnDeleteProduct.Style.HoverBackColor = Color.IndianRed;
                }

                // Both states use white text
                btnDeleteProduct.Style.ForeColor = Color.White;
                btnDeleteProduct.Style.FocusedForeColor = Color.White;
                btnDeleteProduct.Style.HoverForeColor = Color.White;
            }
            catch (Exception ex)
            {
                UIHelper.ShowError($"Error loading product: {ex.Message}");
            }
        }

        #endregion

        // ==========================================
        // EVENT HANDLERS
        // ==========================================
        #region Event Handlers

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
                    if (UIHelper.Confirm("Remove this size option?"))
                    {
                        _sizeOptions.Remove(item);
                    }
                }
            }
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            // 1. Basic Validation (Uses new UIHelper)
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

            var duplicateSizes = _sizeOptions.GroupBy(s => s.Size).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
            if (duplicateSizes.Any())
            {
                var duplicateNames = string.Join(", ", duplicateSizes.Select(s => s.ToFriendlyString()));
                UIHelper.ShowWarning($"Duplicate sizes found: {duplicateNames}. Remove duplicates.");
                return;
            }

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

            if (cmbCategory.SelectedValue is not Category category)
            {
                UIHelper.ShowWarning("Please select a category.");
                return;
            }

            // 2. Map & Save Using Service
            try
            {
                var product = new Product
                {
                    Id = _productId,
                    Name = name,
                    Category = category,
                    SizeOptions = _sizeOptions.Select(so => new ProductSizeOption
                    {
                        Size = so.Size,
                        Price = so.Price,
                        Cost = so.Cost
                    }).ToList()
                };

                var productService = new ProductService();
                productService.UpdateProduct(product);
            }
            catch (Exception ex)
            {
                UIHelper.ShowError($"Error updating product: {ex.Message}");
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

        // --- Soft Delete / Restore Logic ---
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                var productService = new ProductService();
                var product = productService.GetProductById(_productId);

                if (product == null) return;

                if (product.IsArchived) // RESTORE LOGIC
                {
                    if (UIHelper.Confirm("Put this product back on the active menu?", "Restore"))
                    {
                        productService.ToggleArchiveStatus(_productId, false);
                        MessageBox.Show("Product restored successfully!", "Restored", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                else // ARCHIVE LOGIC
                {
                    if (UIHelper.Confirm("Remove this product from the menu? It will be safely hidden from cashiers.", "Archive"))
                    {
                        productService.ToggleArchiveStatus(_productId, true);
                        MessageBox.Show("Product archived successfully.", "Archived", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                UIHelper.ShowError($"Error updating status: {ex.Message}");
            }
        }

        #endregion
    }
}