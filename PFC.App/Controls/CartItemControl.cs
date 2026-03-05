using PFC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PFC.App.Controls
{
    public partial class CartItemControl : UserControl
    {
        // 1. Store the item data
        public OrderDetail? ItemData { get; private set; }
        // 2. Create an event so the Main View knows when to delete this item
        public event EventHandler? RemoveClicked;

        public CartItemControl()
        {
            InitializeComponent();
        }

        // 3. The method to load the data into the UI
        public void SetData(OrderDetail item)
        {
            if (item == null) return; // Safety check fixes the warnings below it!
            ItemData = item;

            // Basic text
            lblQuantity.Text = $"{item.Quantity}x";
            lblProductName.Text = item.Product?.Name ?? "Unknown Product";
            lblLineTotal.Text = $"₱{item.TotalLinePrice:N2}";

            // Format the Size
            string prettySize = FormatEnumName(item.SelectedSize.ToString());

            // Format the Add-ons
            List<string> prettyAddOns = new List<string>();
            if (item.AddOns != null && item.AddOns.Any())
            {
                foreach (var addon in item.AddOns)
                {
                    prettyAddOns.Add($"+ {FormatEnumName(addon.ToString())}");
                }
            }

            // Combine Size and Add-ons into one label with line breaks
            string detailsText = prettySize;
            if (prettyAddOns.Any())
            {
                // \n creates a new line in the label!
                detailsText += "\n" + string.Join("\n", prettyAddOns);
            }

            lblDetails.Text = detailsText;
        }

        // 4. Trigger the custom event when the X is clicked
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            RemoveClicked?.Invoke(this, EventArgs.Empty);
        }

        // Our handy regex formatter
        private string FormatEnumName(string name)
        {
            return System.Text.RegularExpressions.Regex.Replace(name, "([a-z])([A-Z])", "$1 $2");
        }
    }
}

