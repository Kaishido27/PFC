using PFC.App.Controls;
using PFC.App.Forms;
using PFC.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PFC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PFC.App.Views
{
    public partial class ProductView : UserControl
    {
        private List<Product> _allProducts = new List<Product>();
        private Category _currentFilter = Category.IcedCoffee; // default filter

        public ProductView()
        {
            InitializeComponent();

            // Improve painting / reduce flicker
            SetStyle(System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer |
                     System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                     System.Windows.Forms.ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            // enable double buffering on FlowLayoutPanel (protected property) via reflection
            try
            {
                var prop = typeof(FlowLayoutPanel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                prop?.SetValue(flowLayoutPanel1, true, null);
            }
            catch
            {
                // ignore if reflection fails
            }

            // Wire filter buttons using named handlers and ensure a single subscription
            try
            {
                btnIcedCoffee.Click -= BtnIcedCoffee_Click;
                btnIcedCoffee.Click += BtnIcedCoffee_Click;

                btnHotCoffee.Click -= BtnHotCoffee_Click;
                btnHotCoffee.Click += BtnHotCoffee_Click;

                btnFlavMilk.Click -= BtnFlavMilk_Click;
                btnFlavMilk.Click += BtnFlavMilk_Click;

                btnMatcha.Click -= BtnMatcha_Click;
                btnMatcha.Click += BtnMatcha_Click;

                btnSoda.Click -= BtnSoda_Click;
                btnSoda.Click += BtnSoda_Click;
            }
            catch
            {
                // If buttons not found at runtime (designer mismatch) ignore; fix names in designer.
            }

            // wire add product button (ensure single subscription)
            try
            {
                btnAddProduct.Click -= btnAddProduct_Click;
                btnAddProduct.Click += btnAddProduct_Click;
            }
            catch
            {
                // ignore if not present
            }

            // Load initial data (this will apply default filter)
            LoadProducts();
        }

        // Named handlers used to avoid duplicate lambda subscriptions
        private void BtnIcedCoffee_Click(object? sender, EventArgs e) => SetFilter(Category.IcedCoffee);
        private void BtnHotCoffee_Click(object? sender, EventArgs e) => SetFilter(Category.HotCoffee);
        private void BtnFlavMilk_Click(object? sender, EventArgs e) => SetFilter(Category.FlavoredMilk);
        private void BtnMatcha_Click(object? sender, EventArgs e) => SetFilter(Category.Matcha);
        private void BtnSoda_Click(object? sender, EventArgs e) => SetFilter(Category.Soda);

        // Re-query DB and display
        public void LoadProducts()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(LoadProducts));
                return;
            }

            try
            {
                using var db = new AppDbContext();
                _allProducts = db.Products
                    .Include(p => p.SizeOptions)
                    .ToList();

                ApplyFilterAndDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetFilter(Category category)
        {
            _currentFilter = category;
            ApplyFilterAndDisplay();
            UpdateFilterButtonVisuals();
        }

        private void ApplyFilterAndDisplay()
        {
            IEnumerable<Product> items;
            if (_allProducts == null)
            {
                items = Enumerable.Empty<Product>();
            }
            else
            {
                items = _allProducts.Where(p => p.Category == _currentFilter);
            }

            DisplayProducts(items);
        }

        private void UpdateFilterButtonVisuals()
        {
            // Update visual state for the filter buttons (uses explicit designer names).
            try
            {
                // Reset styles (adjust as needed)
                btnIcedCoffee.BackColor = (_currentFilter == Category.IcedCoffee) ? System.Drawing.Color.FromArgb(221, 184, 146) : SystemColors.Control;
                btnHotCoffee.BackColor = (_currentFilter == Category.HotCoffee) ? System.Drawing.Color.FromArgb(221, 184, 146) : SystemColors.Control;
                btnFlavMilk.BackColor = (_currentFilter == Category.FlavoredMilk) ? System.Drawing.Color.FromArgb(221, 184, 146) : SystemColors.Control;
                btnMatcha.BackColor = (_currentFilter == Category.Matcha) ? System.Drawing.Color.FromArgb(221, 184, 146) : SystemColors.Control;
                btnSoda.BackColor = (_currentFilter == Category.Soda) ? System.Drawing.Color.FromArgb(221, 184, 146) : SystemColors.Control;
            }
            catch
            {
                // ignore if any button missing
            }
        }

        // Accept any enumerable and handle null gracefully
        public void DisplayProducts(IEnumerable<PFC.Domain.Models.Product>? products)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => DisplayProducts(products)));
                return;
            }

            // Remove only product item controls so other UI (filter buttons, etc.) are not removed.
            var existingProductItems = flowLayoutPanel1.Controls
                .OfType<ProductItem>()
                .ToList();

            foreach (var ctl in existingProductItems)
            {
                flowLayoutPanel1.Controls.Remove(ctl);
                ctl.Dispose();
            }

            if (products == null)
            {
                return;
            }

            // Hide while building to reduce flicker, and suspend layout for performance
            flowLayoutPanel1.SuspendLayout();
            var prevVisible = flowLayoutPanel1.Visible;
            flowLayoutPanel1.Visible = false;

            foreach (var prod in products)
            {
                var p = prod;

                var item = new ProductItem();
                item.SetProduct(p);

                // Subscribe to the product clicked event
                item.ProductClicked += (s, e) => OpenOrderDialog(e.Product);

                flowLayoutPanel1.Controls.Add(item);
            }

            flowLayoutPanel1.ResumeLayout();
            flowLayoutPanel1.Visible = prevVisible;
        }

        // Click handler for Add Product button
        private void btnAddProduct_Click(object? sender, EventArgs e)
        {
            using var dlg = new AddProductForm();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        // Placeholder — replace with your actual order dialog creation and navigation
        private void OpenOrderDialog(PFC.Domain.Models.Product product)
        {
            MessageBox.Show($"Open order dialog for: {product.Name ?? "Unknown"}", "Product Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
