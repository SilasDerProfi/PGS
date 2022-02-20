namespace PGS.UI
{
    partial class MainWindow
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
            PGS.Data.Graph<PGS.Data.PebbledNode> graph_11 = new PGS.Data.Graph<PGS.Data.PebbledNode>();
            this.drawboard = new PGS.UI.GraphDrawboard();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.zoomBar = new PGS.UI.ToolStripTraceBarItem();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuitemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.fromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graph1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graph2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graph3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graph4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graph5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.rescaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbClear = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbRun = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawboard
            // 
            this.drawboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawboard.BackColor = System.Drawing.Color.White;
            this.drawboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawboard.Graph = graph_11;
            this.drawboard.Location = new System.Drawing.Point(-1, 35);
            this.drawboard.Name = "drawboard";
            this.drawboard.Size = new System.Drawing.Size(814, 371);
            this.drawboard.TabIndex = 0;
            this.drawboard.TabStop = false;
            this.drawboard.ZoomvalueChanged += new System.EventHandler(this.Drawboard_ZoomvalueChanged);
            this.drawboard.SizeChanged += new System.EventHandler(this.Drawboard_SizeChanged);
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.Color.White;
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.zoomBar});
            this.statusBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusBar.Location = new System.Drawing.Point(0, 409);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(812, 27);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(39, 22);
            this.statusLabel.Text = "Ready";
            // 
            // zoomBar
            // 
            this.zoomBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.zoomBar.Maximum = 200;
            this.zoomBar.Minimum = 10;
            this.zoomBar.Name = "zoomBar";
            this.zoomBar.Size = new System.Drawing.Size(200, 25);
            this.zoomBar.Text = "Zoom";
            this.zoomBar.Value = 40;
            this.zoomBar.ValueChanged += new System.EventHandler(this.ZoomBar_ValueChanged);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.White;
            this.menu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitemFile,
            this.tsbSettings,
            this.tsbHelp,
            this.tsbRun});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(812, 32);
            this.menu.TabIndex = 2;
            this.menu.Text = "menuStrip1";
            // 
            // menuitemFile
            // 
            this.menuitemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSave,
            this.tsmLoad,
            this.toolStripSeparator1,
            this.rescaleToolStripMenuItem,
            this.tsbClear});
            this.menuitemFile.Image = global::PGS.Properties.Resources.file;
            this.menuitemFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuitemFile.Name = "menuitemFile";
            this.menuitemFile.Padding = new System.Windows.Forms.Padding(4, 0, 10, 0);
            this.menuitemFile.Size = new System.Drawing.Size(76, 28);
            this.menuitemFile.Text = "File";
            // 
            // tsmSave
            // 
            this.tsmSave.Image = global::PGS.Properties.Resources.save;
            this.tsmSave.Name = "tsmSave";
            this.tsmSave.Size = new System.Drawing.Size(185, 30);
            this.tsmSave.Text = "Save";
            this.tsmSave.Click += new System.EventHandler(this.SaveToFile_Click);
            // 
            // tsmLoad
            // 
            this.tsmLoad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromFileToolStripMenuItem,
            this.graph1ToolStripMenuItem,
            this.graph2ToolStripMenuItem,
            this.graph3ToolStripMenuItem,
            this.graph4ToolStripMenuItem,
            this.graph5ToolStripMenuItem});
            this.tsmLoad.Name = "tsmLoad";
            this.tsmLoad.Size = new System.Drawing.Size(185, 30);
            this.tsmLoad.Text = "Load";
            // 
            // fromFileToolStripMenuItem
            // 
            this.fromFileToolStripMenuItem.Name = "fromFileToolStripMenuItem";
            this.fromFileToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.fromFileToolStripMenuItem.Text = "From File ...";
            this.fromFileToolStripMenuItem.Click += new System.EventHandler(this.LoadFromFile_Click);
            // 
            // graph1ToolStripMenuItem
            // 
            this.graph1ToolStripMenuItem.Name = "graph1ToolStripMenuItem";
            this.graph1ToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.graph1ToolStripMenuItem.Tag = "1";
            this.graph1ToolStripMenuItem.Text = "Graph 1";
            this.graph1ToolStripMenuItem.Click += new System.EventHandler(this.OpenPredefinedGraph);
            // 
            // graph2ToolStripMenuItem
            // 
            this.graph2ToolStripMenuItem.Name = "graph2ToolStripMenuItem";
            this.graph2ToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.graph2ToolStripMenuItem.Tag = "2";
            this.graph2ToolStripMenuItem.Text = "Graph 2";
            this.graph2ToolStripMenuItem.Click += new System.EventHandler(this.OpenPredefinedGraph);
            // 
            // graph3ToolStripMenuItem
            // 
            this.graph3ToolStripMenuItem.Name = "graph3ToolStripMenuItem";
            this.graph3ToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.graph3ToolStripMenuItem.Tag = "3";
            this.graph3ToolStripMenuItem.Text = "Graph 3";
            this.graph3ToolStripMenuItem.Click += new System.EventHandler(this.OpenPredefinedGraph);
            // 
            // graph4ToolStripMenuItem
            // 
            this.graph4ToolStripMenuItem.Name = "graph4ToolStripMenuItem";
            this.graph4ToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.graph4ToolStripMenuItem.Tag = "4";
            this.graph4ToolStripMenuItem.Text = "Graph 4";
            this.graph4ToolStripMenuItem.Click += new System.EventHandler(this.OpenPredefinedGraph);
            // 
            // graph5ToolStripMenuItem
            // 
            this.graph5ToolStripMenuItem.Name = "graph5ToolStripMenuItem";
            this.graph5ToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.graph5ToolStripMenuItem.Tag = "5";
            this.graph5ToolStripMenuItem.Text = "Graph 5";
            this.graph5ToolStripMenuItem.Click += new System.EventHandler(this.OpenPredefinedGraph);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // rescaleToolStripMenuItem
            // 
            this.rescaleToolStripMenuItem.Image = global::PGS.Properties.Resources.rescale;
            this.rescaleToolStripMenuItem.Name = "rescaleToolStripMenuItem";
            this.rescaleToolStripMenuItem.Size = new System.Drawing.Size(185, 30);
            this.rescaleToolStripMenuItem.Text = "Rescale graph";
            this.rescaleToolStripMenuItem.Click += new System.EventHandler(this.Rescale);
            // 
            // tsbClear
            // 
            this.tsbClear.Image = global::PGS.Properties.Resources.clear;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.Size = new System.Drawing.Size(185, 30);
            this.tsbClear.Text = "Clear graph";
            this.tsbClear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // tsbSettings
            // 
            this.tsbSettings.Image = global::PGS.Properties.Resources.settings;
            this.tsbSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSettings.Name = "tsbSettings";
            this.tsbSettings.Padding = new System.Windows.Forms.Padding(4, 0, 10, 0);
            this.tsbSettings.Size = new System.Drawing.Size(108, 28);
            this.tsbSettings.Text = "Settings";
            this.tsbSettings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // tsbHelp
            // 
            this.tsbHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbHelp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tsbHelp.Image = global::PGS.Properties.Resources.help;
            this.tsbHelp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbHelp.Name = "tsbHelp";
            this.tsbHelp.Size = new System.Drawing.Size(78, 28);
            this.tsbHelp.Text = "Help";
            this.tsbHelp.Click += new System.EventHandler(this.Help_Click);
            // 
            // tsbRun
            // 
            this.tsbRun.Image = global::PGS.Properties.Resources.play;
            this.tsbRun.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRun.Name = "tsbRun";
            this.tsbRun.Padding = new System.Windows.Forms.Padding(4, 0, 10, 0);
            this.tsbRun.Size = new System.Drawing.Size(173, 28);
            this.tsbRun.Text = "Run Pebble game";
            this.tsbRun.Click += new System.EventHandler(this.Click_Run);
            // 
            // GraphBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(812, 436);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.drawboard);
            this.MainMenuStrip = this.menu;
            this.MinimumSize = new System.Drawing.Size(650, 400);
            this.Name = "GraphBuilder";
            this.Text = "PGS | Pebble-Game simulation";
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GraphDrawboard drawboard;
        private StatusStrip statusBar;
        private MenuStrip menu;
        private ToolStripStatusLabel statusLabel;
        private ToolStripMenuItem menuitemFile;
        private ToolStripMenuItem tsbSettings;
        private ToolStripTraceBarItem zoomBar;
        private ToolStripMenuItem tsmSave;
        private ToolStripMenuItem tsmLoad;
        private ToolStripMenuItem graph1ToolStripMenuItem;
        private ToolStripMenuItem graph2ToolStripMenuItem;
        private ToolStripMenuItem graph3ToolStripMenuItem;
        private ToolStripMenuItem graph4ToolStripMenuItem;
        private ToolStripMenuItem graph5ToolStripMenuItem;
        private ToolStripMenuItem fromFileToolStripMenuItem;
        private ToolStripMenuItem tsbHelp;
        private ToolStripMenuItem tsbClear;
        private ToolStripMenuItem tsbRun;
        private ToolStripMenuItem rescaleToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
    }
}