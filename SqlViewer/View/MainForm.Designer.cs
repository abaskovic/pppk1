namespace SqlViewer.View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            toolStrip1 = new ToolStrip();
            tsbSelect = new ToolStripButton();
            tsbSave = new ToolStripButton();
            tvServer = new TreeView();
            tbContent = new TextBox();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbSelect, tsbSave });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(749, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbSelect
            // 
            tsbSelect.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbSelect.Image = (Image)resources.GetObject("tsbSelect.Image");
            tsbSelect.ImageTransparentColor = Color.Magenta;
            tsbSelect.Name = "tsbSelect";
            tsbSelect.Size = new Size(23, 22);
            tsbSelect.Text = "Select";
            tsbSelect.Click += TsbSave_Click;
            // 
            // tsbSave
            // 
            tsbSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbSave.Image = (Image)resources.GetObject("tsbSave.Image");
            tsbSave.ImageTransparentColor = Color.Magenta;
            tsbSave.Name = "tsbSave";
            tsbSave.Size = new Size(23, 22);
            tsbSave.Text = "Save";
            tsbSave.Click += TsbSave_Click;
            // 
            // tvServer
            // 
            tvServer.Location = new Point(12, 28);
            tvServer.Name = "tvServer";
            tvServer.Size = new Size(272, 548);
            tvServer.TabIndex = 1;
            tvServer.BeforeExpand += TwServer_BeforeExpand;
            // 
            // tbContent
            // 
            tbContent.Location = new Point(290, 28);
            tbContent.Multiline = true;
            tbContent.Name = "tbContent";
            tbContent.ScrollBars = ScrollBars.Vertical;
            tbContent.Size = new Size(447, 548);
            tbContent.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(749, 629);
            Controls.Add(tbContent);
            Controls.Add(tvServer);
            Controls.Add(toolStrip1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            FormClosed += MainForm_FormClosed;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tsbSelect;
        private ToolStripButton tsbSave;
        private TreeView tvServer;
        private TextBox tbContent;
    }
}