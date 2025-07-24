namespace GramR
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlNav = new Pnl();
            btnLog = new Button();
            btnDb = new Button();
            pnlController = new Pnl();
            pnlNav.SuspendLayout();
            SuspendLayout();
            // 
            // pnlNav
            // 
            pnlNav.BorderColor = Color.Gainsboro;
            pnlNav.BorderSize = 1;
            pnlNav.Controls.Add(btnLog);
            pnlNav.Controls.Add(btnDb);
            pnlNav.Dock = DockStyle.Top;
            pnlNav.Location = new Point(10, 10);
            pnlNav.Name = "pnlNav";
            pnlNav.Padding = new Padding(3);
            pnlNav.Size = new Size(780, 38);
            pnlNav.TabIndex = 0;
            pnlNav.Text = "pnl1";
            // 
            // btnLog
            // 
            btnLog.BackgroundImage = Properties.Resources.darkxl;
            btnLog.BackgroundImageLayout = ImageLayout.Stretch;
            btnLog.Dock = DockStyle.Left;
            btnLog.FlatStyle = FlatStyle.Popup;
            btnLog.ForeColor = Color.White;
            btnLog.Location = new Point(96, 4);
            btnLog.Name = "btnLog";
            btnLog.Size = new Size(100, 30);
            btnLog.TabIndex = 1;
            btnLog.Text = "Log";
            btnLog.UseVisualStyleBackColor = true;
            btnLog.Click += btnLog_Click;
            // 
            // btnDb
            // 
            btnDb.BackgroundImage = Properties.Resources.darkxl;
            btnDb.BackgroundImageLayout = ImageLayout.Stretch;
            btnDb.Dock = DockStyle.Left;
            btnDb.FlatStyle = FlatStyle.Popup;
            btnDb.ForeColor = Color.White;
            btnDb.Location = new Point(4, 4);
            btnDb.Name = "btnDb";
            btnDb.Size = new Size(92, 30);
            btnDb.TabIndex = 0;
            btnDb.Text = "Database";
            btnDb.UseVisualStyleBackColor = true;
            btnDb.Click += btnDb_Click;
            // 
            // pnlController
            // 
            pnlController.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlController.BorderColor = Color.Gainsboro;
            pnlController.BorderSize = 1;
            pnlController.Location = new Point(10, 54);
            pnlController.Name = "pnlController";
            pnlController.Padding = new Padding(3);
            pnlController.Size = new Size(780, 383);
            pnlController.TabIndex = 1;
            pnlController.Text = "pnl1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(800, 450);
            Controls.Add(pnlController);
            Controls.Add(pnlNav);
            DoubleBuffered = true;
            Name = "MainForm";
            Padding = new Padding(10);
            pnlNav.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Pnl pnlNav;
        private Button btnDb;
        private Button btnLog;
        private Pnl pnlController;
    }
}
