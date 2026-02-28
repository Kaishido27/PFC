using PFC.Domain.Models;
using PFC.Infrastructure;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace PFC.App.Forms
{
    public partial class AddProductForm : Form
    {
        private BindingList<ProductSizeOption> _sizeOptions = new BindingList<ProductSizeOption>();

        public AddProductForm()
        {
            InitializeComponent();
        }

        private void AddProductForm_Load(object sender, EventArgs e)
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

            // Disable automatic new-row; we'll add rows explicitly via the Add Size button
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false; // removal handled via Actions button
            dataGridView1.DataSource = _sizeOptions;

            // Bind category combobox
            cmbCategory.DataSource = Enum.GetValues(typeof(Category));

            // Start with one row so the user has a place to begin
            if (_sizeOptions.Count == 0)
            {
                _sizeOptions.Add(new ProductSizeOption { Size = ProductSize.Eightoz, Price = 0m, Cost = 0m });
            }
        }

        private void SfRoundedButtonAddSize_Click(object? sender, EventArgs e)
        {
            // Add an empty size option row (user will edit Size/Price/Cost)
            _sizeOptions.Add(new ProductSizeOption { Size = ProductSize.Eightoz, Price = 0m, Cost = 0m });
            // Focus the new row in the grid for convenience
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
                    var confirm = MessageBox.Show("Remove this size option?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        _sizeOptions.Remove(item);
                    }
                }
            }
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
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

            // Validate and check duplicates
            var duplicateSizes = _sizeOptions.GroupBy(s => s.Size).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
            if (duplicateSizes.Any())
            {
                MessageBox.Show($"Duplicate sizes found: {string.Join(", ", duplicateSizes)}. Remove duplicates.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

            try
            {
                using var db = new AppDbContext();
                db.Products.Add(product);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Ensure a single well-defined cancel behavior.
            // If the designer already set DialogResult, this is still safe and idempotent.
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
