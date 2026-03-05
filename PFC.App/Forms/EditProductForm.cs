using Microsoft.EntityFrameworkCore;
using PFC.Domain.Models;
using PFC.Infrastructure;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace PFC.App.Forms
{
    public partial class EditProductForm : Form
    {
        private readonly int _productId;
        private Product _product;
        private BindingList<ProductSizeOption> _sizeOptions = new();

        public EditProductForm(int productId)
        {
            InitializeComponent();
            _productId = productId;
            this.Load += EditProductForm_Load;
        }

        private void EditProductForm_Load(object sender, EventArgs e)
        {
            SetupGrid();
            SetupCategoryCombo();
            LoadProductData();
        }

        private void SetupGrid()
        {
            // Configure combo column and bind its values to the enum
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

            // Grid Settings: Disable automatic new-row; we'll add rows explicitly via the Add Size button
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false; // removal handled via Actions button
            dataGridView1.DataSource = _sizeOptions;
        }

        private void SetupCategoryCombo()
        {
            cmbCategory.DataSource = Enum.GetValues(typeof(Category));
        }

        private void LoadProductData()
        {
            using var db = new AppDbContext();
            _product = db.Products.FirstOrDefault(p => p.Id == _productId);

            if (_product == null)
            {
                MessageBox.Show("Product not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            txtName.Text = _product.Name;
            cmbCategory.SelectedItem = _product.Category;

            foreach (var size in _product.SizeOptions ?? Enumerable.Empty<ProductSizeOption>())
            {
                _sizeOptions.Add(size);
            }
        }

        private void sfRoundedButtonAddSize_Click(object sender, EventArgs e)
        {
            _sizeOptions.Add(new ProductSizeOption
            {
                Size = ProductSize.EightOz,
                Price = 0m,
                Cost = 0m
            });

            // Focus the new row in the grid for convenience
            var idx = _sizeOptions.Count - 1;
            dataGridView1.CurrentCell = dataGridView1.Rows[idx].Cells["Sizeoption"];
            dataGridView1.BeginEdit(true);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void btnSave_Click(object sender, EventArgs e)
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

            // Save to database
            try
            {
                using var db = new AppDbContext();
                var existing = db.Products
                    .Include(p => p.SizeOptions)
                    .FirstOrDefault(p => p.Id == _productId);

                if (existing != null)
                {
                    // Update basic properties
                    existing.Name = name;
                    existing.Category = category;

                    // Clear existing size options
                    existing.SizeOptions.Clear();

                    // Add updated size options
                    foreach (var so in _sizeOptions)
                    {
                        existing.SizeOptions.Add(new ProductSizeOption
                        {
                            Size = so.Size,
                            Price = so.Price,
                            Cost = so.Cost,
                            ProductId = existing.Id
                        });
                    }

                    db.SaveChanges();
                }

                MessageBox.Show("Product updated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
