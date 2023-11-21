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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            toolStrip1 = new ToolStrip();
            tsbSelect = new ToolStripButton();
            tsbSave = new ToolStripButton();
            tvServer = new TreeView();
            tbQuery = new TextBox();
            btnExecute = new Button();
            tabControl = new TabControl();
            tabResults = new TabPage();
            tabMessages = new TabPage();
            dgResults = new DataGridView();
            toolStrip1.SuspendLayout();
            tabControl.SuspendLayout();
            tabResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgResults).BeginInit();
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
            tsbSelect.Click += TsbSelect_Click;
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
            tvServer.Size = new Size(272, 589);
            tvServer.TabIndex = 1;
            tvServer.AfterCollapse += TwServer_AfterCollapse;
            tvServer.BeforeExpand += TwServer_BeforeExpand;
            // 
            // tbQuery
            // 
            tbQuery.Location = new Point(290, 28);
            tbQuery.Multiline = true;
            tbQuery.Name = "tbQuery";
            tbQuery.ScrollBars = ScrollBars.Vertical;
            tbQuery.Size = new Size(447, 321);
            tbQuery.TabIndex = 2;
            // 
            // btnExecute
            // 
            btnExecute.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnExecute.ForeColor = SystemColors.ControlText;
            btnExecute.Image = (Image)resources.GetObject("btnExecute.Image");
            btnExecute.ImageAlign = ContentAlignment.MiddleLeft;
            btnExecute.Location = new Point(628, 355);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(109, 58);
            btnExecute.TabIndex = 3;
            btnExecute.Text = "Execute";
            btnExecute.UseVisualStyleBackColor = true;
            btnExecute.Click += BtnExecute_Click;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabResults);
            tabControl.Controls.Add(tabMessages);
            tabControl.Location = new Point(290, 412);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(447, 205);
            tabControl.TabIndex = 4;
            // 
            // tabResults
            // 
            tabResults.Controls.Add(dgResults);
            tabResults.Location = new Point(4, 24);
            tabResults.Name = "tabResults";
            tabResults.Padding = new Padding(3);
            tabResults.Size = new Size(439, 177);
            tabResults.TabIndex = 0;
            tabResults.Text = "Results";
            tabResults.UseVisualStyleBackColor = true;
            // 
            // tabMessages
            // 
            tabMessages.Location = new Point(4, 24);
            tabMessages.Name = "tabMessages";
            tabMessages.Padding = new Padding(3);
            tabMessages.Size = new Size(439, 177);
            tabMessages.TabIndex = 1;
            tabMessages.Text = "Messages";
            tabMessages.UseVisualStyleBackColor = true;
            // 
            // dgResults
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(255, 255, 192);
            dgResults.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgResults.Dock = DockStyle.Fill;
            dgResults.Location = new Point(3, 3);
            dgResults.Name = "dgResults";
            dgResults.RowTemplate.Height = 25;
            dgResults.Size = new Size(433, 171);
            dgResults.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(749, 629);
            Controls.Add(tabControl);
            Controls.Add(btnExecute);
            Controls.Add(tbQuery);
            Controls.Add(tvServer);
            Controls.Add(toolStrip1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            FormClosed += MainForm_FormClosed;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabControl.ResumeLayout(false);
            tabResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tsbSelect;
        private ToolStripButton tsbSave;
        private TreeView tvServer;
        private TextBox tbQuery;
        private Button btnExecute;
        private TabControl tabControl;
        private TabPage tabResults;
        private TabPage tabMessages;
        private DataGridView dgResults;
    }
}