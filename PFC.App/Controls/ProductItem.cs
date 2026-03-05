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

        // The Property to store the product data
        public Product? ProductData { get; private set; }

        // Event to signal the product was clicked (encapsulates child click wiring)
        public event EventHandler<ProductEventArgs>? ProductClicked;

        #endregion

        // ==========================================
        // CONSTRUCTOR
        // ==========================================
        #region Constructor

        public ProductItem()
        {
            InitializeComponent();

            // Forward clicks on the control itself and the main Syncfusion panel
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

            // Set the Name
            lblName.Text = product.Name ?? "Unknown Product";

            // Set the Category using the helper below
            lblCategory.Text = FormatEnumName(product.Category.ToString());

            // Calculate the starting price
            if (product.SizeOptions != null && product.SizeOptions.Any())
            {
                decimal minPrice = product.SizeOptions.Min(s => s.Price);
                lblPrice.Text = $"Starts at {minPrice:C}";
            }
            else
            {
                lblPrice.Text = "Price N/A";
            }

            // Apply category-based gradient theme
            ApplyCategoryTheme(product.Category);
        }

        private void ApplyCategoryTheme(Category category)
        {
            try
            {
                // Choose primary color per category, keep beige as secondary
                Color primary;
                Color secondary;
                GradientStyle style = GradientStyle.Horizontal;

                switch (category)
                {
                    case Category.Matcha:
                        // Lighter Forest Green and leaf green
                        primary = Color.FromArgb(55, 95, 58);
                        secondary = Color.FromArgb(93, 131, 67);
                        break;

                    case Category.FlavoredMilk:
                        // Deep Berry and Soft pink
                        primary = Color.FromArgb(224, 118, 132);
                        secondary = Color.FromArgb(165, 70, 80);
                        break;

                    case Category.Soda:
                        // Midnight Blue and Royal Blue
                        primary = Color.FromArgb(42, 75, 143);
                        secondary = Color.FromArgb(35, 55, 115);
                        break;

                    case Category.HotCoffee:
                        // Roasted Bean and Tawny
                        primary = Color.FromArgb(175, 123, 75);
                        secondary = Color.FromArgb(95, 55, 40);
                        break;

                    case Category.IcedCoffee:
                    default:
                        // Deep Espresso and Caramel
                        primary = Color.FromArgb(181, 122, 73);
                        secondary = Color.FromArgb(105, 55, 35);
                        break;
                }

                // Set new gradient brush info (Syncfusion BrushInfo) to change the gradient colors
                pfcRoundedGradientPanel1.BackgroundColor = new BrushInfo(style, primary, secondary);

                // Optional: tweak border or text color for contrast
                var textColor = GetContrastingTextColor(primary);
                lblName.ForeColor = textColor;
                lblPrice.ForeColor = textColor;
                lblCategory.ForeColor = textColor;
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

        // Small helper to make "IcedCoffee" look like "Iced Coffee"
        private string FormatEnumName(string name)
        {
            return Regex.Replace(name, "([a-z])([A-Z])", "$1 $2");
        }

        // Small helper to pick readable text color based on background
        private Color GetContrastingTextColor(Color bg)
        {
            // Luminance calculation
            double luminance = (0.299 * bg.R + 0.587 * bg.G + 0.114 * bg.B) / 255;
            return luminance > 0.6 ? Color.Black : Color.White;
        }

        #endregion

        // ==========================================
        // EVENT HANDLERS
        // ==========================================
        #region Event Handlers

        // Click forwarding handler
        private void OnAnyClick(object? sender, EventArgs e)
        {
            if (ProductData is not null)
            {
                ProductClicked?.Invoke(this, new ProductEventArgs(ProductData));
            }
        }

        private void ClickEdit_Click(object sender, EventArgs e)
        {
            // Placeholder for future edit logic
        }

        #endregion
    }

    // ==========================================
    // CUSTOM EVENT ARGS
    // ==========================================
    #region Custom Event Args

    // Small EventArgs type to pass product information
    public class ProductEventArgs : EventArgs
    {
        public Product Product { get; }
        public ProductEventArgs(Product product) => Product = product;
    }

    #endregion
}