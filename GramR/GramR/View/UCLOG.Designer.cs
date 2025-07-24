namespace GramR.View
{
    partial class UCLOG
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
            pnlLogControls = new Panel();
            btnClear = new Button();
            btnSave = new Button();
            LOG = new RichTextBox();
            pnlLogControls.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLogControls
            // 
            pnlLogControls.Controls.Add(btnSave);
            pnlLogControls.Controls.Add(btnClear);
            pnlLogControls.Dock = DockStyle.Top;
            pnlLogControls.Location = new Point(0, 0);
            pnlLogControls.Name = "pnlLogControls";
            pnlLogControls.Padding = new Padding(3);
            pnlLogControls.Size = new Size(780, 33);
            pnlLogControls.TabIndex = 0;
            // 
            // btnClear
            // 
            btnClear.BackgroundImage = Properties.Resources.darkxl;
            btnClear.BackgroundImageLayout = ImageLayout.Stretch;
            btnClear.Dock = DockStyle.Right;
            btnClear.FlatStyle = FlatStyle.Popup;
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(685, 3);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(92, 27);
            btnClear.TabIndex = 1;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.BackgroundImage = Properties.Resources.darkxl;
            btnSave.BackgroundImageLayout = ImageLayout.Stretch;
            btnSave.Dock = DockStyle.Right;
            btnSave.FlatStyle = FlatStyle.Popup;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(593, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(92, 27);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // LOG
            // 
            LOG.BackColor = Color.FromArgb(32, 32, 32);
            LOG.BorderStyle = BorderStyle.FixedSingle;
            LOG.Dock = DockStyle.Fill;
            LOG.Font = new Font("Consolas", 9F);
            LOG.ForeColor = Color.Lime;
            LOG.Location = new Point(0, 33);
            LOG.Name = "LOG";
            LOG.Size = new Size(780, 350);
            LOG.TabIndex = 1;
            LOG.Text = "";
            // 
            // UCLOG
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            Controls.Add(LOG);
            Controls.Add(pnlLogControls);
            Name = "UCLOG";
            Size = new Size(780, 383);
            pnlLogControls.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLogControls;
        private Button btnClear;
        private Button btnSave;
        private RichTextBox LOG;
    }
}
