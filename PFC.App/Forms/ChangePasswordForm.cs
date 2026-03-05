using PFC.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PFC.App.Forms
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();

            if (cmbTarget.Items.Count > 0) cmbTarget.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Basic Validation
            if (string.IsNullOrWhiteSpace(txtNewValue.Text))
            {
                MessageBox.Show("Password cannot be empty.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNewValue.Text != txtConfirmValue.Text)
            {
                MessageBox.Show("New passwords do not match. Please re-type them.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Database Update
            try
            {
                using (var db = new AppDbContext())
                {
                    // Grab the single settings row
                    var settings = db.SystemSettings.FirstOrDefault();

                    if (settings == null)
                    {
                        MessageBox.Show("System settings not found in database.", "Error");
                        return;
                    }

                    // 3. Determine which field to update
                    string selectedOption = cmbTarget.SelectedItem?.ToString() ?? "Admin Password";

                    if (selectedOption == "Master Key")
                    {
                        settings.MasterKey = txtNewValue.Text;
                        MessageBox.Show("Master Key updated successfully!", "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        settings.AdminPassword = txtNewValue.Text;
                        MessageBox.Show("Admin Password updated successfully!", "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    db.SaveChanges(); // Commit the change to the DB
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save changes: {ex.Message}", "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
