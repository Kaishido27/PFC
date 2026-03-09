using PFC.App.Helper; // Make sure your helper namespace is included!
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

            // USE HELPER: Turns "IcedCoffee" into "Iced Coffee"
            lblProductCategory.Text = UIHelper.FormatEnumName(_product.Category.ToString());
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
        #region Core Logic

        private void UpdateLiveTotal()
        {
            // 1. Base price from the ProductSizeOption class
            decimal unitPrice = 0m;
            if (cboSizes.SelectedItem is ProductSizeOption selectedOption)
            {
                unitPrice = selectedOption.Price;
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

        // DELETED: Local FormatEnumName method!

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
                SelectedSize = selectedOption.Size,
                Quantity = (int)numQuantity.Value,
                AddOns = selectedAddOns,
                UnitPrice = selectedOption.Price,
                UnitCost = selectedOption.Cost
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
                // USE HELPER: Formats add-ons like "ExtraShot" -> "Extra Shot"
                e.Value = UIHelper.FormatEnumName(addon.ToString());
            }
        }

        private void cboSizes_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is ProductSizeOption option)
            {
                // USE TRANSLATOR: Automatically turns ProductSize.EightOz into "8 Ounces"
                string prettyName = option.Size.ToFriendlyString();

                // Final format: "8 Ounces (₱120.00)"
                e.Value = $"{prettyName} (₱{option.Price:N2})";
            }
        }

        #endregion
    }
}