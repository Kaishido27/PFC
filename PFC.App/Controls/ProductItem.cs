using PFC.Domain.Models;
using Syncfusion.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PFC.App.Controls
{
    public partial class ProductItem : UserControl
    {
        // 1. The Property to store the product data
        public Product? ProductData { get; private set; }

        // New: event to signal the product was clicked (encapsulates child click wiring)
        public event EventHandler<ProductEventArgs>? ProductClicked;

        public ProductItem()
        {
            InitializeComponent();

            // Forward clicks on the control itself
            this.Click += OnAnyClick;

            // Wire existing child controls (designer-created)
            foreach (Control child in Controls)
            {
                child.Click += OnAnyClick;
            }
        }

        // Ensure dynamically added child controls also forward clicks
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            e.Control.Click += OnAnyClick;
        }

        // 2. The Method to bind data to the labels
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

        // Click forwarding handler
        private void OnAnyClick(object? sender, EventArgs e)
        {
            if (ProductData is not null)
            {
                ProductClicked?.Invoke(this, new ProductEventArgs(ProductData));
            }
        }

        // 3. Helper to make "IcedCoffee" look like "Iced Coffee"
        private string FormatEnumName(string name)
        {
            return Regex.Replace(name, "([a-z])([A-Z])", "$1 $2");
        }

        // Apply gradient theme to the panel based on Category
        private void ApplyCategoryTheme(Category category)
        {
            try
            {
                // choose primary color per category, keep beige as secondary
                Color primary;
                Color secondary;
                GradientStyle style = GradientStyle.Horizontal;

                switch (category)
                {
                    case Category.Matcha:
                        // Forest Green and leaf green
                        primary = Color.FromArgb(28, 59, 30);
                        secondary = Color.FromArgb(93, 131, 67);

                        break;
                    case Category.FlavoredMilk:
                        // Deep Berry and Soft pink
                        primary = Color.FromArgb(224, 118, 132);
                        secondary = Color.FromArgb(134, 41, 51);

                        break;
                    case Category.Soda:
                        // Midnight Blue and Royal Blue
                        primary = Color.FromArgb(42, 75, 143);
                        secondary = Color.FromArgb(12, 24, 68);
                        break;
                    case Category.HotCoffee:
                        // Roasted Bean and Tawny
                        primary = Color.FromArgb(175, 123, 75);
                        secondary = Color.FromArgb(50, 27, 19);
                        break;
                    case Category.IcedCoffee:
                    default:
                        //Deep Espresso and Caramel
                        primary = Color.FromArgb(181, 122, 73);
                        secondary = Color.FromArgb(60, 26, 15);

                        break;
                }


                // set new gradient brush info (Syncfusion BrushInfo) to change the gradient colors
                pfcRoundedGradientPanel1.BackgroundColor = new BrushInfo(style, primary, secondary);

                //Optional: tweak border or text color for contrast
                var textColor = GetContrastingTextColor(primary);
                lblName.ForeColor = textColor;
                lblPrice.ForeColor = textColor;
                lblCategory.ForeColor = textColor;
            }
            catch
            {
                // if designer control missing or anything fails, don't crash the UI
            }
        }

        // small helper to pick readable text color
        private Color GetContrastingTextColor(Color bg)
        {
            // luminance calculation
            double luminance = (0.299 * bg.R + 0.587 * bg.G + 0.114 * bg.B) / 255;
            return luminance > 0.6 ? Color.Black : Color.White;
        }
    }

    // Small EventArgs type to pass product information
    public class ProductEventArgs : EventArgs
    {
        public Product Product { get; }

        public ProductEventArgs(Product product) => Product = product;
    }
}
