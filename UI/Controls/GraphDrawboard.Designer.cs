namespace PGS.UI
{
    partial class GraphDrawboard
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.drawboard = new System.Windows.Forms.PictureBox();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmaAddNode = new System.Windows.Forms.ToolStripMenuItem();
            this.cmaDeleteNodeOrEdge = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmaRename = new System.Windows.Forms.ToolStripMenuItem();
            this.cmaRenameDescription = new System.Windows.Forms.ToolStripMenuItem();
            this.cmtbNewName = new System.Windows.Forms.ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.drawboard)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawboard
            // 
            this.drawboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawboard.Location = new System.Drawing.Point(0, 0);
            this.drawboard.Name = "drawboard";
            this.drawboard.Size = new System.Drawing.Size(150, 150);
            this.drawboard.TabIndex = 0;
            this.drawboard.TabStop = false;
            this.drawboard.Paint += new System.Windows.Forms.PaintEventHandler(this.Drawboard_Paint);
            this.drawboard.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Drawboard_MouseMove);
            this.drawboard.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Drawboard_Scroll);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmaAddNode,
            this.cmaDeleteNodeOrEdge,
            this.toolStripSeparator1,
            this.cmaRename});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(129, 76);
            // 
            // cmaAddNode
            // 
            this.cmaAddNode.Image = global::PGS.Properties.Resources.add;
            this.cmaAddNode.Name = "cmaAddNode";
            this.cmaAddNode.Size = new System.Drawing.Size(128, 22);
            this.cmaAddNode.Text = "Add Node";
            this.cmaAddNode.Click += new System.EventHandler(this.AddNode);
            // 
            // cmaDeleteNodeOrEdge
            // 
            this.cmaDeleteNodeOrEdge.Image = global::PGS.Properties.Resources.delete;
            this.cmaDeleteNodeOrEdge.Name = "cmaDeleteNodeOrEdge";
            this.cmaDeleteNodeOrEdge.Size = new System.Drawing.Size(128, 22);
            this.cmaDeleteNodeOrEdge.Text = "Delete";
            this.cmaDeleteNodeOrEdge.Click += new System.EventHandler(this.DeleteNodeOrEdge);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(125, 6);
            // 
            // cmaRename
            // 
            this.cmaRename.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmaRenameDescription,
            this.cmtbNewName});
            this.cmaRename.Image = global::PGS.Properties.Resources.edit;
            this.cmaRename.Name = "cmaRename";
            this.cmaRename.Size = new System.Drawing.Size(128, 22);
            this.cmaRename.Text = "Rename";
            // 
            // cmaRenameDescription
            // 
            this.cmaRenameDescription.Enabled = false;
            this.cmaRenameDescription.Name = "cmaRenameDescription";
            this.cmaRenameDescription.Size = new System.Drawing.Size(470, 22);
            this.cmaRenameDescription.Text = "Insert new Identifier and press Enter to rename:";
            // 
            // cmtbNewName
            // 
            this.cmtbNewName.AutoSize = false;
            this.cmtbNewName.Name = "cmtbNewName";
            this.cmtbNewName.Size = new System.Drawing.Size(410, 23);
            this.cmtbNewName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RenameNode);
            // 
            // GraphDrawboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.drawboard);
            this.Name = "GraphDrawboard";
            ((System.ComponentModel.ISupportInitialize)(this.drawboard)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox drawboard;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem cmaAddNode;
        private ToolStripMenuItem cmaRename;
        private ToolStripTextBox cmtbNewName;
        private ToolStripMenuItem cmaDeleteNodeOrEdge;
        private ToolStripMenuItem cmaRenameDescription;
        private ToolStripSeparator toolStripSeparator1;
    }
}
