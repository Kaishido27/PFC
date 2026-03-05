using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PFC.App.Views
{
    public partial class ReportsView : UserControl
    {
        public ReportsView()
        {
            InitializeComponent();
            InitializeDateRange();
        }

        private void InitializeDateRange()
        {
            // Set default date range to the last 7 days
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            dtpEndDate.Value = DateTime.Today;

            cmbDateRange.SelectedIndex = 0; // Default to "Last 7 Days"

            cmbDateRange.SelectedIndexChanged += CmbDateRange_SelectedIndexChanged;
            dtpStartDate.ValueChanged += DatePickers_ValueChanged;
            dtpEndDate.ValueChanged += DatePickers_ValueChanged;
            btnExport.Click += btnExport_Click;

            UpdateDateRangeDisplay();
        }

        private void CmbDateRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedRange = cmbDateRange.SelectedItem.ToString();

            switch (selectedRange)
            {
                case "Last 7 Days":
                    dtpStartDate.Value = DateTime.Today.AddDays(-7);
                    dtpEndDate.Value = DateTime.Today;
                    break;
                case "Last 30 Days":
                    dtpStartDate.Value = DateTime.Today.AddDays(-30);
                    dtpEndDate.Value = DateTime.Today;
                    break;
                case "This Month":
                    dtpStartDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    dtpEndDate.Value = DateTime.Today;
                    break;
                case "Last Month":
                    var lastMonth = DateTime.Today.AddMonths(-1);
                    dtpStartDate.Value = new DateTime(lastMonth.Year, lastMonth.Month, 1);
                    dtpEndDate.Value = new DateTime(lastMonth.Year, lastMonth.Month, DateTime.DaysInMonth(lastMonth.Year, lastMonth.Month));
                    break;
                case "Custom Range":
                    // Do nothing, allow user to select dates
                    break;
            }

            UpdateDateRangeDisplay();

        }

        private void DatePickers_ValueChanged(object sender, EventArgs e)
        {
            if (cmbDateRange.SelectedItem.ToString() == "Custom Range")
            {
                cmbDateRange.SelectedItem = cmbDateRange.Items.IndexOf("Custom Range");

            }
            UpdateDateRangeDisplay();
        }

        private void UpdateDateRangeDisplay()
        {
            var dateRange = $"{dtpStartDate.Value:MMM dd, yyyy} - {dtpEndDate.Value:MMM dd, yyyy}";
            label3.Text = $"Track your coffee shop's revenue, profit and growth metrics | {dateRange}";

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using var saveDialog = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv|Excel Files (*.xlsx)|*.xlsx|PDF Files (*.pdf)|*.pdf",
                Title = "Export Report",
                FileName = $"Report_{DateTime.Now:yyyyMMdd_HHmmss}"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show($"Report will be exported to:\n{saveDialog.FileName}\n\n" +
                    $"Date Range: {dtpStartDate.Value:MMM dd, yyyy} - {dtpEndDate.Value:MMM dd, yyyy}",
                    "Export Ready", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
