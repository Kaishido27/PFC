using PFC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PFC.App.Forms
{
    public partial class OrderEntryForm : Form
    {
        // ==========================================
        // FIELDS & PROPERTIES
        // ==========================================
        #region Fields & Properties

        public OrderDetail? ResultingDetail { get; private set; }
        private Product _product;

        #endregion

        // ==========================================
        // CONSTRUCTOR
        // ==========================================
        #region Constructor

        public OrderEntryForm(Product product)
        {
            InitializeComponent();
            _product = product;

            // 1. Initial UI Setup
            lblProductName.Text = _product.Name ?? "Unknown Product";
            lblProductCategory.Text = FormatEnumName(_product.Category.ToString());
            numQuantity.Value = 1;

            // 2. Load Data into Controls
            SetupSizeComboBox();
            PopulateAddOns();

            // 3. Run initial calculation to update the label immediately
            UpdateLiveTotal();
        }

        #endregion

        // ==========================================
        // SETUP METHODS
        // ==========================================
        #region Setup Methods

        private void SetupSizeComboBox()
        {
            if (_product.SizeOptions != null && _product.SizeOptions.Any())
            {
                cboSizes.DataSource = _product.SizeOptions.ToList();
            }
        }

        private void PopulateAddOns()
        {
            chkAddOns.Items.Clear();
            chkAddOns.FormattingEnabled = true;

            foreach (AddOns addon in Enum.GetValues(typeof(AddOns)))
            {
                chkAddOns.Items.Add(addon);
            }
        }

        #endregion

        // ==========================================
        // CORE LOGIC & HELPERS
        // ==========================================
        #region Core Logic & Helpers

        private void UpdateLiveTotal()
        {
            // 1. Base price from the ProductSizeOption class
            decimal unitPrice = 0m;
            if (cboSizes.SelectedItem is ProductSizeOption selectedOption)
            {
                unitPrice = selectedOption.Price; // Now we can safely access .Price!
            }

            // 2. Add-on price (₱10 per selected item)
            int addOnCount = chkAddOns.CheckedItems.Count;
            decimal addOnPrice = addOnCount * 10m;

            // 3. Final math
            int quantity = (int)numQuantity.Value;
            decimal finalTotal = (unitPrice + addOnPrice) * quantity;

            // 4. Update the UI
            if (lblLiveTotal != null)
            {
                lblLiveTotal.Text = $"Total: ₱{finalTotal:N2}";
            }
        }

        private string FormatEnumName(string name)
        {
            return System.Text.RegularExpressions.Regex.Replace(name, "([a-z])([A-Z])", "$1 $2");
        }

        #endregion

        // ==========================================
        // UI EVENT HANDLERS
        // ==========================================
        #region UI Event Handlers

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            List<AddOns> selectedAddOns = chkAddOns.CheckedItems
                                                   .Cast<AddOns>()
                                                   .ToList();

            // Grab the selected option from the combobox
            var selectedOption = (ProductSizeOption)cboSizes.SelectedItem!;

            ResultingDetail = new OrderDetail
            {
                Product = _product,
                ProductId = _product.Id,
                SelectedSize = selectedOption.Size, // Extract the enum from the option class!
                Quantity = (int)numQuantity.Value,
                AddOns = selectedAddOns
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cboSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLiveTotal();
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            UpdateLiveTotal();
        }

        private void chkAddOns_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Wait for the UI to actually register the checkmark before calculating
            this.BeginInvoke(new Action(UpdateLiveTotal));
        }

        private void ChkAddOns_Format(object? sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is AddOns addon)
            {
                e.Value = FormatEnumName(addon.ToString());
            }
        }

        private void cboSizes_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is ProductSizeOption option)
            {
                // Add spaces to the enum and append the price
                string prettyName = FormatEnumName(option.Size.ToString());
                e.Value = $"{prettyName} (₱{option.Price:N2})";
            }
        }

        #endregion
    }
}