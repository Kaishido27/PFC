using PFC.Domain.Models;
using Syncfusion.Drawing;
using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PFC.App.Controls
{
    public partial class ProductItem : UserControl
    {
        // ==========================================
        // PROPERTIES & EVENTS
        // ==========================================
        #region Properties & Events

        public Product? ProductData { get; private set; }

        public event EventHandler<ProductEventArgs>? ProductClicked;

        // NEW: Event for when the Edit icon is clicked
        public event EventHandler<ProductEventArgs>? EditClicked;

        #endregion

        // ==========================================
        // CONSTRUCTOR
        // ==========================================
        #region Constructor

        public ProductItem()
        {
            InitializeComponent();

            this.Click += OnAnyClick;
            pfcRoundedGradientPanel1.Click += OnAnyClick;
        }

        #endregion

        // ==========================================
        // DATA BINDING & THEMING
        // ==========================================
        #region Data Binding & Theming

        public void SetProduct(Product product)
        {
            this.ProductData = product;

            lblName.Text = product.Name ?? "Unknown Product";
            lblCategory.Text = FormatEnumName(product.Category.ToString());

            if (product.SizeOptions != null && product.SizeOptions.Any())
            {
                decimal minPrice = product.SizeOptions.Min(s => s.Price);
                lblPrice.Text = $"Starts at {minPrice:C}";

                var sizeList = product.SizeOptions
                      .Select(s => FormatEnumName(s.Size.ToString()))
                      .ToList();
                lblAvailableSizes.Text = string.Join("\n", sizeList);
            }
            else
            {
                lblPrice.Text = "Price N/A";
                lblAvailableSizes.Text = "No sizes setup";
            }

            ApplyCategoryTheme(product.Category);
        }

        private void ApplyCategoryTheme(Category category)
        {
            try
            {
                Color primary;
                Color secondary;
                GradientStyle style = GradientStyle.Horizontal;

                switch (category)
                {
                    case Category.Matcha:
                        primary = Color.FromArgb(55, 95, 58);
                        secondary = Color.FromArgb(93, 131, 67);
                        break;

                    case Category.FlavoredMilk:
                        primary = Color.FromArgb(224, 118, 132);
                        secondary = Color.FromArgb(165, 70, 80);
                        break;

                    case Category.Soda:
                        primary = Color.FromArgb(42, 75, 143);
                        secondary = Color.FromArgb(35, 55, 115);
                        break;

                    case Category.HotCoffee:
                        primary = Color.FromArgb(175, 123, 75);
                        secondary = Color.FromArgb(95, 55, 40);
                        break;

                    case Category.IcedCoffee:
                    default:
                        primary = Color.FromArgb(181, 122, 73);
                        secondary = Color.FromArgb(105, 55, 35);
                        break;
                }

                pfcRoundedGradientPanel1.BackgroundColor = new BrushInfo(style, primary, secondary);

                var textColor = GetContrastingTextColor(primary);
                lblName.ForeColor = textColor;
                lblPrice.ForeColor = textColor;
                lblCategory.ForeColor = textColor;
                lblAvailableSizes.ForeColor = textColor;
            }
            catch
            {
                // If designer control missing or anything fails, don't crash the UI
            }
        }

        #endregion

        // ==========================================
        // HELPER METHODS
        // ==========================================
        #region Helper Methods

        private string FormatEnumName(string name)
        {
            return Regex.Replace(name, "([a-z])([A-Z])", "$1 $2");
        }

        private Color GetContrastingTextColor(Color bg)
        {
            double luminance = (0.299 * bg.R + 0.587 * bg.G + 0.114 * bg.B) / 255;
            return luminance > 0.6 ? Color.Black : Color.White;
        }

        #endregion

        // ==========================================
        // EVENT HANDLERS
        // ==========================================
        #region Event Handlers

        private void OnAnyClick(object? sender, EventArgs e)
        {
            if (ProductData is not null)
            {
                ProductClicked?.Invoke(this, new ProductEventArgs(ProductData));
            }
        }

        private void ClickEdit_Click(object sender, EventArgs e)
        {
            // Stop the click from bubbling to the parent (prevents opening OrderDialog)
            if (ProductData is not null)
            {
                EditClicked?.Invoke(this, new ProductEventArgs(ProductData));
            }
        }

        #endregion
    }

    // ==========================================
    // CUSTOM EVENT ARGS
    // ==========================================
    #region Custom Event Args

    public class ProductEventArgs : EventArgs
    {
        public Product Product { get; }
        public ProductEventArgs(Product product) => Product = product;
    }

    #endregion
}