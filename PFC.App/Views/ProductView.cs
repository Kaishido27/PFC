using PFC.App.Controls;
using PFC.App.Forms;
using PFC.App.Helper;
using PFC.App.Helpers; // <-- Make sure you include your Helpers!
using PFC.Domain.Models;
using PFC.Infrastructure;
using PFC.Services;    // <-- Make sure you include your Services!
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PFC.App.Views
{
    public partial class ProductView : UserControl
    {
        #region Fields
        private List<Product> _allProducts = new List<Product>();
        private Category _currentFilter = Category.IcedCoffee;
        private Order _currentOrder = new Order();
        private System.Windows.Forms.Timer _searchTimer = new System.Windows.Forms.Timer();
        private bool _isAddProductUnlocked = false;
        #endregion

        #region Constructor
        public ProductView()
        {
            InitializeComponent();

            // 1 LINE HELPER CALL! (Sets up the form to not flicker)
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            UIHelper.EnableDoubleBuffering(flowLayoutPanel1);

            _searchTimer.Interval = 500;
            _searchTimer.Tick += SearchTimer_Tick;

            LoadProducts();
            btnCash_Click(this, EventArgs.Empty);
        }
        #endregion

        #region Product Logic
        public void LoadProducts()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(LoadProducts));
                return;
            }

            try
            {
                // Checks if the application is currently running inside the Visual Studio Designer
                if (UIHelper.IsDesignMode()) return;

                var productService = new ProductService();
                bool viewingArchived = chkShowArchived != null && chkShowArchived.Checked;

                _allProducts = productService.GetProducts(viewingArchived);
                ApplyFilterAndDisplay();
            }
            catch (Exception ex)
            {
                UIHelper.ShowError($"Failed to load products: {ex.Message}");
            }
        }

        private void SetFilter(Category category)
        {
            _currentFilter = category;
            ApplyFilterAndDisplay();
        }

        private void ApplyFilterAndDisplay()
        {
            var items = _allProducts == null ? Enumerable.Empty<Product>() : _allProducts.AsEnumerable();
            string searchText = txtSearch.Text?.Trim() ?? "";

            if (string.IsNullOrEmpty(searchText) || searchText == "Search Products")
            {
                items = items.Where(p => p.Category == _currentFilter);
            }
            else
            {
                items = items.Where(p => p.Name != null && p.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase));
            }
            DisplayProducts(items);
        }

        public void DisplayProducts(IEnumerable<Product>? products)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => DisplayProducts(products)));
                return;
            }

            var existingProductItems = flowLayoutPanel1.Controls.OfType<ProductItem>().ToList();
            foreach (var ctl in existingProductItems)
            {
                flowLayoutPanel1.Controls.Remove(ctl);
                ctl.Dispose();
            }

            if (products == null) return;

            flowLayoutPanel1.SuspendLayout();
            var prevVisible = flowLayoutPanel1.Visible;
            flowLayoutPanel1.Visible = false;

            foreach (var prod in products)
            {
                var item = new ProductItem();
                item.SetProduct(prod);

                item.ProductClicked += (s, e) => OpenOrderDialog(e.Product);
                item.EditClicked += (s, e) => OpenEditProductDialog(e.Product);

                flowLayoutPanel1.Controls.Add(item);
            }

            flowLayoutPanel1.ResumeLayout();
            flowLayoutPanel1.Visible = prevVisible;
        }
        #endregion

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

        private void OpenEditProductDialog(Product product)
        {
            // SECURITY HELPER CALL!
            if (!SecurityHelper.IsAuthorized()) return;

            using var editForm = new EditProductForm(product.Id);
            if (editForm.ShowDialog(this) == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        private void RefreshOrderSidebar()
        {
            var existingCartItems = flwCartItems.Controls.OfType<CartItemControl>().ToList();
            foreach (var ctl in existingCartItems)
            {
                flwCartItems.Controls.Remove(ctl);
                ctl.Dispose();
            }

            foreach (var item in _currentOrder.Details.ToList())
            {
                var cartControl = new CartItemControl();
                cartControl.SetData(item);

                cartControl.Width = flwCartItems.ClientSize.Width - (cartControl.Margin.Left + cartControl.Margin.Right);

                cartControl.RemoveClicked += (sender, e) =>
                {
                    _currentOrder.Details.Remove(item);
                    RefreshOrderSidebar();
                };

                flwCartItems.Controls.Add(cartControl);
            }

            if (lblGrandTotal != null)
            {
                lblGrandTotal.Text = $"Total: ₱{_currentOrder.TotalAmount:N2}";
            }

            if (lblItemCount != null)
            {
                int totalItems = _currentOrder.Details.Sum(d => d.Quantity);
                lblItemCount.Text = totalItems == 1 ? "1 Item" : $"{totalItems} Items";
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

                    foreach (var detail in _currentOrder.Details)
                    {
                        detail.Product = null;
                    }

                    db.Orders.Add(_currentOrder);
                    db.SaveChanges();
                }

                MessageBox.Show("Order successfully saved!", "Transaction Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _currentOrder = new Order();
                RefreshOrderSidebar();

                btnCash_Click(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                UIHelper.ShowError($"Failed to save order to database:\n\n{ex.InnerException?.Message ?? ex.Message}");
            }
        }
        #endregion

        #region UI Events
        private void BtnIcedCoffee_Click(object? sender, EventArgs e) => SetFilter(Category.IcedCoffee);
        private void BtnHotCoffee_Click(object? sender, EventArgs e) => SetFilter(Category.HotCoffee);
        private void BtnFlavMilk_Click(object? sender, EventArgs e) => SetFilter(Category.FlavoredMilk);
        private void BtnMatcha_Click(object? sender, EventArgs e) => SetFilter(Category.Matcha);
        private void BtnSoda_Click(object? sender, EventArgs e) => SetFilter(Category.Soda);

        private void btnAddProduct_Click(object? sender, EventArgs e)
        {
    
            using (var addForm = new AddProductForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _searchTimer.Stop();
            _searchTimer.Start();
        }

        private void SearchTimer_Tick(object? sender, EventArgs e)
        {
            _searchTimer.Stop();
            ApplyFilterAndDisplay();
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            _currentOrder.PaymentMethod = PaymentMethod.Cash;
            // (Swaps the colors automatically)
            UIHelper.SetPaymentButtonActive(btnCash, btnOnline);
        }

        private void btnOnline_Click(object sender, EventArgs e)
        {
            _currentOrder.PaymentMethod = PaymentMethod.Online;
            // (Swaps the colors automatically)
            UIHelper.SetPaymentButtonActive(btnOnline, btnCash);
        }

        private void chkShowArchived_CheckStateChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }
        #endregion
    }
}