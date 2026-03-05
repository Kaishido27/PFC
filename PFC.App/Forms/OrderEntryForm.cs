using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PFC.Domain.Models;

namespace PFC.App.Forms
{
    public partial class OrderEntryForm : Form
    {
        public OrderDetail ResultingDetail { get; private set; }
        private Product _product;

        public OrderEntryForm(Product product)
        {
            InitializeComponent();
            _product = product;

            // 1. Set Product Name
            lblProductName.Text = _product.Name;
            lblProductCategory.Text = FormatEnumName(_product.Category.ToString());

            // 2. Setup Size ComboBox
            if (_product.SizeOptions != null && _product.SizeOptions.Any())
            {
                cboSizes.DataSource = _product.SizeOptions.ToList();
                cboSizes.DisplayMember = "Size";
            }

            // 3. Setup Add-ons CheckedListBox from Enum
            PopulateAddOns();

            // 4. Default Quantity
            numQuantity.Value = 1;

        }

        private void PopulateAddOns()
        {
            // Clear existing items just in case
            chkAddOns.Items.Clear();
            chkAddOns.Format += ChkAddOns_Format;
            // Loop through all values in your AddOns enum
            foreach (AddOns addon in Enum.GetValues(typeof(AddOns)))
            {
                // We add the actual enum value to the list
                chkAddOns.Items.Add(addon);
            }
        }
        private void ChkAddOns_Format(object? sender, ListControlConvertEventArgs e)
        {
            // If the item is our AddOns enum, format its string representation
            if (e.ListItem is AddOns addon)
            {
                e.Value = FormatEnumName(addon.ToString());
            }
        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Extract the checked items and cast them directly back to your AddOns enum
            List<AddOns> selectedAddOns = chkAddOns.CheckedItems
                                                   .Cast<AddOns>()
                                                   .ToList();

            // Build the OrderDetail using Object Initializer
            ResultingDetail = new OrderDetail
            {
                Product = _product,
                ProductId = _product.Id,
                SelectedSize = (ProductSize)cboSizes.SelectedItem,
                Quantity = (int)numQuantity.Value,
                AddOns = selectedAddOns // Plugs perfectly into your List<AddOns>!
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private string FormatEnumName(string name)
        {
            return System.Text.RegularExpressions.Regex.Replace(name, "([a-z])([A-Z])", "$1 $2");
        }
    }
}
