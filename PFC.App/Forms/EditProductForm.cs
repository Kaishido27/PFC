using PFC.Domain.Models;
using PFC.Infrastructure;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore; // Added for .Include()

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

        // Require the Product ID to know which item we are editing
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
            // 1. Configure combo column and bind its values to the enum
            if (dataGridView1.Columns["Sizeoption"] is DataGridViewComboBoxColumn sizeCol)
            {
                sizeCol.DataSource = Enum.GetValues(typeof(ProductSize));
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

            // 3. Bind category combobox
            cmbCategory.DataSource = Enum.GetValues(typeof(Category));

            // 4. Load Existing Product Data
            LoadProductData();

            // Bind the grid to our loaded options
            dataGridView1.DataSource = _sizeOptions;
        }

        private void LoadProductData()
        {
            try
            {
                using var db = new AppDbContext();
                var product = db.Products
                    .Include(p => p.SizeOptions)
                    .FirstOrDefault(p => p.Id == _productId);

                if (product == null)
                {
                    MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                // Populate UI
                txtName.Text = product.Name;
                cmbCategory.SelectedItem = product.Category;

                // Populate the BindingList with existing size options
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // Add an empty size option row 
            _sizeOptions.Add(new ProductSizeOption { Size = ProductSize.EightOz, Price = 0m, Cost = 0m });

            // Focus the new row in the grid for convenience
            var idx = _sizeOptions.Count - 1;
            dataGridView1.CurrentCell = dataGridView1.Rows[idx].Cells["Sizeoption"];
            dataGridView1.BeginEdit(true);
        }

        private void DataGridView1_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var col = dataGridView1.Columns[e.ColumnIndex];

            // Handle the "Actions" delete button inside the grid
            if (string.Equals(col.Name, "Actions", StringComparison.OrdinalIgnoreCase))
            {
                var item = dataGridView1.Rows[e.RowIndex].DataBoundItem as ProductSizeOption;
                if (item != null)
                {
                    var confirm = MessageBox.Show("Remove this size option?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        _sizeOptions.Remove(item);
                    }
                }
            }
        }

        // --- Save & Cancel Actions ---

        private void btnSave_Click(object? sender, EventArgs e)
        {
            // 1. Basic Validation
            var name = txtName.Text?.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a product name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_sizeOptions == null || _sizeOptions.Count == 0)
            {
                MessageBox.Show("Please add at least one size option with price and cost.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Check for Duplicate Sizes
            var duplicateSizes = _sizeOptions.GroupBy(s => s.Size).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
            if (duplicateSizes.Any())
            {
                MessageBox.Show($"Duplicate sizes found: {string.Join(", ", duplicateSizes)}. Remove duplicates.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Validate Prices and Costs
            foreach (var so in _sizeOptions)
            {
                if (so.Price <= 0m)
                {
                    MessageBox.Show("Each size option must have a price greater than 0.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (so.Cost < 0m)
                {
                    MessageBox.Show("Cost cannot be negative.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (!(cmbCategory.SelectedItem is Category category))
            {
                MessageBox.Show("Please select a category.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Update Database
            try
            {
                using var db = new AppDbContext();
                var product = db.Products
                    .Include(p => p.SizeOptions)
                    .FirstOrDefault(p => p.Id == _productId);

                if (product == null)
                {
                    MessageBox.Show("Product no longer exists in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update scalar properties
                product.Name = name;
                product.Category = category;

                // Safely update collection: Remove old options and insert new ones
                db.RemoveRange(product.SizeOptions);
                product.SizeOptions = _sizeOptions
                    .Select(so => new ProductSizeOption
                    {
                        Size = so.Size,
                        Price = so.Price,
                        Cost = so.Cost
                    })
                    .ToList();

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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