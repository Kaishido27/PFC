using System.Windows.Forms;
using PFC.Domain.Models;

namespace PFC.App.Helper
{
    public static class UIHelper
    {

        // 1. Centralizes the ugly reflection code for fixing screen flickering
        public static void EnableDoubleBuffering(Control control)
        {
            try
            {
                var prop = typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                prop?.SetValue(control, true, null);
            }
            catch { }
        }

        // 2. Centralizes the massive blocks of Syncfusion color styling!
        public static void SetPaymentButtonActive(Syncfusion.WinForms.Controls.SfButton activeBtn, Syncfusion.WinForms.Controls.SfButton inactiveBtn)
        {
            // Set the clicked button to Green
            activeBtn.Style.BackColor = Color.DarkGreen;
            activeBtn.Style.FocusedBackColor = Color.DarkGreen;
            activeBtn.Style.HoverBackColor = Color.DarkGreen;
            activeBtn.Style.ForeColor = Color.White;
            activeBtn.Style.FocusedForeColor = Color.White;
            activeBtn.Style.HoverForeColor = Color.White;

            // Set the other button back to Gray
            inactiveBtn.Style.BackColor = Color.WhiteSmoke;
            inactiveBtn.Style.FocusedBackColor = Color.WhiteSmoke;
            inactiveBtn.Style.HoverBackColor = Color.WhiteSmoke;
            inactiveBtn.Style.ForeColor = Color.Black;
            inactiveBtn.Style.FocusedForeColor = Color.Black;
            inactiveBtn.Style.HoverForeColor = Color.Black;
        }
        // Standardizes the appearance and behavior of DataGridViews across the entire application
        public static void FormatStandardGrid(DataGridView grid)
        {
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // Centralizes error reporting
        public static void ShowError(string message)
        {
            MessageBox.Show(message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Centralizes destructive action confirmations
        public static bool Confirm(string message, string title = "Confirm")
        {
            var result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return result == DialogResult.Yes;
        }

        // Checks if the application is currently running inside the Visual Studio Designer
        public static bool IsDesignMode()
        {
            return System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime;
        }

        public static string ToFriendlyString(this ProductSize size)
        {
            switch (size)
            {
                case ProductSize.EightOz:
                    return "8 Ounces";
                case ProductSize.TwelveOz:
                    return "12 Ounces";
                case ProductSize.SixteenOz:
                    return "16 Ounces";
                case ProductSize.TwentyTwoOz:
                    return "22 Ounces";

                // Add any other sizes you have in your enum here!

                default:
                    return size.ToString();
            }
        }

        public static string FormatEnumName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return string.Empty;
            return System.Text.RegularExpressions.Regex.Replace(name, "([a-z])([A-Z])", "$1 $2");
        }

        // Automatically chooses black or white text depending on how dark the background color is
        public static System.Drawing.Color GetContrastingTextColor(System.Drawing.Color bg)
        {
            double luminance = (0.299 * bg.R + 0.587 * bg.G + 0.114 * bg.B) / 255;
            return luminance > 0.6 ? System.Drawing.Color.Black : System.Drawing.Color.White;
        }

        // Centralizes validation warnings
        public static void ShowWarning(string message, string title = "Validation")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}