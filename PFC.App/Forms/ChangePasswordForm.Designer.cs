namespace PFC.App.Forms
{
    partial class ChangePasswordForm
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
            txtNewValue = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtConfirmValue = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            cmbTarget = new ComboBox();
            btnCancel = new PFC.App.Controls.SfRoundedButton();
            btnSave = new PFC.App.Controls.SfRoundedButton();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)txtNewValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtConfirmValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtNewValue
            // 
            txtNewValue.BeforeTouchSize = new Size(280, 27);
            txtNewValue.Location = new Point(12, 91);
            txtNewValue.Name = "txtNewValue";
            txtNewValue.PasswordChar = '●';
            txtNewValue.PlaceholderText = "Enter New Password";
            txtNewValue.Size = new Size(280, 27);
            txtNewValue.TabIndex = 4;
            txtNewValue.UseSystemPasswordChar = true;
            // 
            // txtConfirmValue
            // 
            txtConfirmValue.BeforeTouchSize = new Size(280, 27);
            txtConfirmValue.Location = new Point(12, 137);
            txtConfirmValue.Name = "txtConfirmValue";
            txtConfirmValue.PasswordChar = '●';
            txtConfirmValue.PlaceholderText = "Confirm Password";
            txtConfirmValue.Size = new Size(280, 27);
            txtConfirmValue.TabIndex = 6;
            txtConfirmValue.UseSystemPasswordChar = true;
            // 
            // cmbTarget
            // 
            cmbTarget.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTarget.FormattingEnabled = true;
            cmbTarget.Items.AddRange(new object[] { "Admin Password", "Master Key" });
            cmbTarget.Location = new Point(115, 38);
            cmbTarget.Name = "cmbTarget";
            cmbTarget.Size = new Size(151, 28);
            cmbTarget.TabIndex = 8;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(255, 128, 128);
            btnCancel.Font = new Font("Segoe UI Semibold", 9F);
            btnCancel.Location = new Point(284, 196);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(88, 35);
            btnCancel.Style.BackColor = Color.FromArgb(255, 128, 128);
            btnCancel.Style.FocusedBorder = null;
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(128, 255, 128);
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.Location = new Point(187, 196);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(88, 35);
            btnSave.Style.BackColor = Color.FromArgb(128, 255, 128);
            btnSave.Style.FocusedBorder = null;
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.authenticity;
            pictureBox1.Location = new Point(28, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(71, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // ChangePasswordForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(384, 243);
            Controls.Add(pictureBox1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cmbTarget);
            Controls.Add(txtConfirmValue);
            Controls.Add(txtNewValue);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ChangePasswordForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chnage Password";
            ((System.ComponentModel.ISupportInitialize)txtNewValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtConfirmValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNewValue;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtConfirmValue;
        private ComboBox cmbTarget;
        private Controls.SfRoundedButton btnCancel;
        private Controls.SfRoundedButton btnSave;
        private PictureBox pictureBox1;
    }
}