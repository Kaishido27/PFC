namespace PFC.App.Forms
{
    partial class AuthForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtPassword = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            btnConfirm = new PFC.App.Controls.SfRoundedButton();
            btnCancel = new PFC.App.Controls.SfRoundedButton();
            label1 = new Label();
            lnkChangePassword = new LinkLabel();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)txtPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.BeforeTouchSize = new Size(354, 31);
            txtPassword.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(24, 90);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderText = "Enter Password";
            txtPassword.Size = new Size(354, 31);
            txtPassword.TabIndex = 0;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.FromArgb(128, 255, 128);
            btnConfirm.Font = new Font("Segoe UI Semibold", 9F);
            btnConfirm.Location = new Point(220, 167);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(88, 35);
            btnConfirm.Style.BackColor = Color.FromArgb(128, 255, 128);
            btnConfirm.Style.FocusedBorder = null;
            btnConfirm.TabIndex = 1;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(255, 128, 128);
            btnCancel.Font = new Font("Segoe UI Semibold", 9F);
            btnCancel.Location = new Point(317, 167);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(88, 35);
            btnCancel.Style.BackColor = Color.FromArgb(255, 128, 128);
            btnCancel.Style.FocusedBorder = null;
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(90, 30);
            label1.Name = "label1";
            label1.Size = new Size(226, 28);
            label1.TabIndex = 3;
            label1.Text = "Enter Admin Password";
            // 
            // lnkChangePassword
            // 
            lnkChangePassword.AutoSize = true;
            lnkChangePassword.Location = new Point(254, 124);
            lnkChangePassword.Name = "lnkChangePassword";
            lnkChangePassword.Size = new Size(124, 20);
            lnkChangePassword.TabIndex = 4;
            lnkChangePassword.TabStop = true;
            lnkChangePassword.Text = "Change Password";
            lnkChangePassword.LinkClicked += lnkChangePassword_LinkClicked;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.authenticity;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(63, 60);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // AuthForm
            // 
            AcceptButton = btnConfirm;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(417, 214);
            Controls.Add(pictureBox1);
            Controls.Add(lnkChangePassword);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(txtPassword);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "AuthForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Verification";
            ((System.ComponentModel.ISupportInitialize)txtPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtPassword;
        private Controls.SfRoundedButton btnConfirm;
        private Controls.SfRoundedButton btnCancel;
        private Label label1;
        private LinkLabel lnkChangePassword;
        private PictureBox pictureBox1;
    }
}