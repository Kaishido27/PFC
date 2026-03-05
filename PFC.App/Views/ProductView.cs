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
        private Order _currentOrder = new Order(); // The active cart holding the user's current session


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

        //Placeholder 
        private void OpenOrderDialog(PFC.Domain.Models.Product product)
        {
            // 1. Instantiate the form we just built, passing the clicked product
            using (var orderForm = new OrderEntryForm(product))
            {
                // 2. Show it as a blocking pop-up. The code waits here until the user closes it.
                if (orderForm.ShowDialog(this) == DialogResult.OK)
                {
                    // 3. The user clicked Confirm! Grab the populated OrderDetail
                    OrderDetail? newItem = orderForm.ResultingDetail;
                    
                    if (newItem != null)
                    {
                        // 4. Add it to our active cart
                        _currentOrder.Details.Add(newItem);

                        // 5. Tell the UI to update the sidebar
                        RefreshOrderSidebar();
                    }
                }
            }
        }
         private void RefreshOrderSidebar()
         {
            // 1. Clear the old list before redrawing
            flwCartItems.Controls.Clear();

            // 2. Loop through every item currently in the cart
            foreach (var item in _currentOrder.Details.ToList()) // .ToList() prevents modification errors
            {
                // Create the new UserControl
                var cartControl = new PFC.App.Controls.CartItemControl();

                // Pass the data to it
                cartControl.SetData(item);

                // Adjust the width so it fills the panel but leaves room for the scrollbar
                cartControl.Width = flwCartItems.Width - 25;

                // Wire up the Remove event!
                cartControl.RemoveClicked += (sender, e) =>
                {
                    // Remove it from our memory model
                    _currentOrder.Details.Remove(item);

                    // Refresh the UI to reflect the deletion
                    RefreshOrderSidebar();
                };

                // Add it to the FlowLayoutPanel
                flwCartItems.Controls.Add(cartControl);
            }

            // 3. Update the Grand Total at the very bottom
            if (lblGrandTotal != null)
            {
                lblGrandTotal.Text = $"Total: ₱{_currentOrder.TotalAmount:N2}";
            }
        }
    }
 }
