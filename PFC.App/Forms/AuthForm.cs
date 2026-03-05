using PFC.Infrastructure;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace PFC.App.Forms
{
    public partial class AuthForm : Form
    {
        // --- NEW: THE MODE SWITCH ---
        // If true, we check the MasterKey. If false, we check the AdminPassword.

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsMasterKeyMode { get; set; } = false;

        public AuthForm()
        {
            InitializeComponent();

            // UX: Enter key clicks confirm, Esc clicks cancel
            this.AcceptButton = btnConfirm;
            this.CancelButton = btnCancel;
        }

        private void btnConfirm_Click(object? sender, EventArgs e)
        {
            using (var db = new AppDbContext())
            {
                // Access your system settings table
                var settings = db.SystemSettings.FirstOrDefault();

                if (settings == null)
                {
                    MessageBox.Show("System settings not found. Please contact the developer.", "Error");
                    return;
                }

                // --- INTEGRATED LOGIC: SELECT THE TARGET KEY ---
                // We pick which password to compare against based on our current mode
                string targetKey = IsMasterKeyMode ? settings.MasterKey : settings.AdminPassword;

                if (txtPassword.Text == targetKey)
                {
                    // Success! Closes the form and tells the parent "It's OK"
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    // Customized error message based on what the user was trying to do
                    string errorMsg = IsMasterKeyMode ? "Invalid Master Key!" : "Invalid Admin Password!";
                    MessageBox.Show(errorMsg, "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lnkChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var auth = new AuthForm())
            {
                auth.Text = "Verify Master Key";
                auth.IsMasterKeyMode = true; // Tell the popup to use Master Key logic

                if (auth.ShowDialog() == DialogResult.OK)
                {
                    // If they passed the Master Key check, open the actual change screen
                    using (var changeForm = new ChangePasswordForm())
                    {
                        changeForm.ShowDialog();
                    }
                }
            }
        }
    }
}