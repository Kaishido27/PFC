using PFC.Domain.Models;
using Syncfusion.Drawing;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PFC.App.Helper; // Ensure this matches your actual folder name!

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

            // Uses your centralized Regex formatter
            lblCategory.Text = UIHelper.FormatEnumName(product.Category.ToString());

            if (product.SizeOptions != null && product.SizeOptions.Any())
            {
                decimal minPrice = product.SizeOptions.Min(s => s.Price);
                lblPrice.Text = $"Starts at {minPrice:C}";

                // 1. USE YOUR NEW SIZE TRANSLATOR HERE!
                // This will print "8 oz" instead of "Eight Oz"
                var sizeList = product.SizeOptions
                      .Select(s => s.Size.ToFriendlyString())
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

                // 2. USE YOUR UI HELPER FOR COLOR MATH!
                var textColor = UIHelper.GetContrastingTextColor(primary);

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