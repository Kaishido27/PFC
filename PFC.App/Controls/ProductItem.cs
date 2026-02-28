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
                Color secondary = Color.Beige;
                GradientStyle style = GradientStyle.ForwardDiagonal;

                switch (category)
                {
                    case Category.Matcha:
                        // green and beige
                        primary = Color.FromArgb(72, 201, 176); // teal-green
                        break;
                    case Category.FlavoredMilk:
                        // pink and beige
                        primary = Color.FromArgb(255, 182, 193); // light pink
                        break;
                    case Category.Soda:
                        // dark / black and beige
                        primary = Color.FromArgb(45, 45, 45); // dark gray (~black)
                        break;
                    case Category.HotCoffee:
                        // darker brown and beige
                        primary = Color.FromArgb(115, 74, 18); // dark coffee brown
                        break;
                    case Category.IcedCoffee:
                    default:
                        // keep the iced coffee color used previously
                        primary = Color.BurlyWood;
                        break;
                }

                
                // set new gradient brush info (Syncfusion BrushInfo) to change the gradient colors
                pfcRoundedGradientPanel1.BackgroundColor = new BrushInfo(style, primary, secondary);

                // Optional: tweak border or text color for contrast
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
