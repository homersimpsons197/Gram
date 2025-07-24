namespace GramR.View
{
    partial class UCDB
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblId = new Label();
            lblAcc = new Label();
            gbDb = new GroupBox();
            chUser = new CheckBox();
            chAcc = new CheckBox();
            gbDb.SuspendLayout();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblId.BorderStyle = BorderStyle.FixedSingle;
            lblId.ForeColor = Color.White;
            lblId.Location = new Point(321, 22);
            lblId.Name = "lblId";
            lblId.Size = new Size(120, 30);
            lblId.TabIndex = 4;
            lblId.Text = "Id:";
            lblId.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAcc
            // 
            lblAcc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAcc.BorderStyle = BorderStyle.FixedSingle;
            lblAcc.ForeColor = Color.White;
            lblAcc.Location = new Point(195, 22);
            lblAcc.Name = "lblAcc";
            lblAcc.Size = new Size(120, 30);
            lblAcc.TabIndex = 3;
            lblAcc.Text = "Accounts:";
            lblAcc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gbDb
            // 
            gbDb.Controls.Add(chAcc);
            gbDb.Controls.Add(chUser);
            gbDb.ForeColor = Color.White;
            gbDb.Location = new Point(10, 10);
            gbDb.Name = "gbDb";
            gbDb.Size = new Size(179, 45);
            gbDb.TabIndex = 5;
            gbDb.TabStop = false;
            gbDb.Text = "Database";
            // 
            // chUser
            // 
            chUser.AutoSize = true;
            chUser.Location = new Point(104, 18);
            chUser.Name = "chUser";
            chUser.Size = new Size(67, 21);
            chUser.TabIndex = 0;
            chUser.Text = "Users";
            chUser.UseVisualStyleBackColor = true;
            // 
            // chAcc
            // 
            chAcc.AutoSize = true;
            chAcc.Location = new Point(6, 18);
            chAcc.Name = "chAcc";
            chAcc.Size = new Size(92, 21);
            chAcc.TabIndex = 1;
            chAcc.Text = "Accounts";
            chAcc.UseVisualStyleBackColor = true;
            // 
            // UCDB
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            Controls.Add(gbDb);
            Controls.Add(lblId);
            Controls.Add(lblAcc);
            Name = "UCDB";
            Size = new Size(780, 383);
            gbDb.ResumeLayout(false);
            gbDb.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblId;
        private Label lblAcc;
        private GroupBox gbDb;
        private CheckBox chAcc;
        private CheckBox chUser;
    }
}
