using Microsoft.EntityFrameworkCore;
using PFC.App.Controls;
using PFC.App.Forms;
using PFC.Domain.Models;
using PFC.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PFC.App.Views
{
    public partial class ProductView : UserControl
    {
        // ==========================================
        // FIELDS & PROPERTIES
        // ==========================================
        #region Fields

        private List<Product> _allProducts = new List<Product>();
        private Category _currentFilter = Category.IcedCoffee; // Default filter
        private Order _currentOrder = new Order(); // The active cart holding the user's current session

        #endregion

        // ==========================================
        // CONSTRUCTOR & SETUP
        // ==========================================
        #region Constructor

        public ProductView()
        {
            InitializeComponent();
            SetupDoubleBuffering();

            // Load initial data (this will apply the default filter)
            LoadProducts();
        }

        private void SetupDoubleBuffering()
        {
            // Improve painting / reduce flicker on the main control
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            // Enable double buffering on FlowLayoutPanel via reflection
            try
            {
                var prop = typeof(FlowLayoutPanel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                prop?.SetValue(flowLayoutPanel1, true, null);
            }
            catch
            {
                // Ignore if reflection fails
            }
        }

        #endregion

        // ==========================================
        // PRODUCT LOADING & DISPLAY LOGIC
        // ==========================================
        #region Product Logic

        // Re-query DB and fetch all products
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
                MessageBox.Show($"Failed to load products: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetFilter(Category category)
        {
            _currentFilter = category;
            ApplyFilterAndDisplay();
        }

        private void ApplyFilterAndDisplay()
        {
            var items = _allProducts == null
                ? Enumerable.Empty<Product>()
                : _allProducts.Where(p => p.Category == _currentFilter);

            DisplayProducts(items);
        }

        public void DisplayProducts(IEnumerable<Product>? products)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => DisplayProducts(products)));
                return;
            }

            // 1. Clean up old memory (Dispose UI controls)
            var existingProductItems = flowLayoutPanel1.Controls.OfType<ProductItem>().ToList();
            foreach (var ctl in existingProductItems)
            {
                flowLayoutPanel1.Controls.Remove(ctl);
                ctl.Dispose();
            }

            if (products == null) return;

            // 2. Hide while building to reduce flicker, and suspend layout for performance
            flowLayoutPanel1.SuspendLayout();
            var prevVisible = flowLayoutPanel1.Visible;
            flowLayoutPanel1.Visible = false;

            // 3. Draw new product cards
            foreach (var prod in products)
            {
                var item = new ProductItem();
                item.SetProduct(prod);
                item.ProductClicked += (s, e) => OpenOrderDialog(e.Product);

                flowLayoutPanel1.Controls.Add(item);
            }

            // 4. Restore UI state
            flowLayoutPanel1.ResumeLayout();
            flowLayoutPanel1.Visible = prevVisible;
        }

        #endregion

        // ==========================================
        // CART & CHECKOUT LOGIC
        // ==========================================
        #region Cart Logic

        private void OpenOrderDialog(Product product)
        {
            using (var orderForm = new OrderEntryForm(product))
            {
                if (orderForm.ShowDialog(this) == DialogResult.OK)
                {
                    OrderDetail? newItem = orderForm.ResultingDetail;

                    if (newItem != null)
                    {
                        _currentOrder.Details.Add(newItem);
                        RefreshOrderSidebar();
                    }
                }
            }
        }

        private void RefreshOrderSidebar()
        {
            // 1. Properly dispose of old CartItemControls to prevent memory leaks!
            var existingCartItems = flwCartItems.Controls.OfType<CartItemControl>().ToList();
            foreach (var ctl in existingCartItems)
            {
                flwCartItems.Controls.Remove(ctl);
                ctl.Dispose();
            }

            // 2. Loop through every item currently in the cart
            foreach (var item in _currentOrder.Details.ToList())
            {
                var cartControl = new CartItemControl();
                cartControl.SetData(item);

                // Adjust width dynamically (subtracting margins prevents horizontal scrollbars)
                cartControl.Width = flwCartItems.ClientSize.Width - (cartControl.Margin.Left + cartControl.Margin.Right);

                // Wire up the Remove event
                cartControl.RemoveClicked += (sender, e) =>
                {
                    _currentOrder.Details.Remove(item);
                    RefreshOrderSidebar();
                };

                flwCartItems.Controls.Add(cartControl);
            }

            // 3. Update the Grand Total
            if (lblGrandTotal != null)
            {
                lblGrandTotal.Text = $"Total: ₱{_currentOrder.TotalAmount:N2}";
            }
        }

        private void btnConfirmOrder_Click(object sender, EventArgs e)
        {
            if (_currentOrder.Details == null || !_currentOrder.Details.Any())
            {
                MessageBox.Show("The cart is empty! Please add some items first.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new AppDbContext())
                {
                    _currentOrder.OrderDate = DateTime.Now;

                    // EF Core Safety Trick: Unlink the Product reference so it doesn't create duplicate products
                    foreach (var detail in _currentOrder.Details)
                    {
                        detail.Product = null;
                    }

                    db.Orders.Add(_currentOrder);
                    db.SaveChanges();
                }

                MessageBox.Show("Order successfully saved!", "Transaction Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the cart for the next customer
                _currentOrder = new Order();
                RefreshOrderSidebar();
            }
            catch (Exception ex)
            {
                string errorMsg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show($"Failed to save order to database:\n\n{errorMsg}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        // ==========================================
        // UI EVENT HANDLERS
        // ==========================================
        #region UI Events

        // Category Filters
        private void BtnIcedCoffee_Click(object? sender, EventArgs e) => SetFilter(Category.IcedCoffee);
        private void BtnHotCoffee_Click(object? sender, EventArgs e) => SetFilter(Category.HotCoffee);
        private void BtnFlavMilk_Click(object? sender, EventArgs e) => SetFilter(Category.FlavoredMilk);
        private void BtnMatcha_Click(object? sender, EventArgs e) => SetFilter(Category.Matcha);
        private void BtnSoda_Click(object? sender, EventArgs e) => SetFilter(Category.Soda);

        // Add Product Menu
        private void btnAddProduct_Click(object? sender, EventArgs e)
        {
            using var dlg = new AddProductForm();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        #endregion
    }
}