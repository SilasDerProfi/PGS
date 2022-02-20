namespace PGS.UI
{
    partial class SettingsWindow
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
            this.btnApply = new System.Windows.Forms.Button();
            this.pbSettingsDrawboard = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cpEdge = new PGS.UI.ColorPicker();
            this.cpPebble = new PGS.UI.ColorPicker();
            this.cpNodeBorder = new PGS.UI.ColorPicker();
            this.cpNodeFill = new PGS.UI.ColorPicker();
            this.cpText = new PGS.UI.ColorPicker();
            this.cbFonts = new System.Windows.Forms.ComboBox();
            this.lbl_Font = new System.Windows.Forms.Label();
            this.gpScaling = new System.Windows.Forms.GroupBox();
            this.cbRescalePebbleGame = new System.Windows.Forms.CheckBox();
            this.cbScaleOnResize = new System.Windows.Forms.CheckBox();
            this.cbScaleOnLoad = new System.Windows.Forms.CheckBox();
            this.gbSolver = new System.Windows.Forms.GroupBox();
            this.cbUseAxioms = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbSettingsDrawboard)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gpScaling.SuspendLayout();
            this.gbSolver.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(368, 500);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(61, 23);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.Apply_Click);
            // 
            // pbSettingsDrawboard
            // 
            this.pbSettingsDrawboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSettingsDrawboard.Location = new System.Drawing.Point(6, 212);
            this.pbSettingsDrawboard.Name = "pbSettingsDrawboard";
            this.pbSettingsDrawboard.Size = new System.Drawing.Size(405, 101);
            this.pbSettingsDrawboard.TabIndex = 3;
            this.pbSettingsDrawboard.TabStop = false;
            this.pbSettingsDrawboard.Paint += new System.Windows.Forms.PaintEventHandler(this.SettingsDrawboard_Paint);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(301, 500);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(61, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cpEdge);
            this.groupBox1.Controls.Add(this.cpPebble);
            this.groupBox1.Controls.Add(this.cpNodeBorder);
            this.groupBox1.Controls.Add(this.cpNodeFill);
            this.groupBox1.Controls.Add(this.cpText);
            this.groupBox1.Controls.Add(this.cbFonts);
            this.groupBox1.Controls.Add(this.lbl_Font);
            this.groupBox1.Controls.Add(this.pbSettingsDrawboard);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 320);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Graph appearance";
            // 
            // cpEdge
            // 
            this.cpEdge.Color = null;
            this.cpEdge.Label = "Edge Color:";
            this.cpEdge.Location = new System.Drawing.Point(6, 175);
            this.cpEdge.MaximumSize = new System.Drawing.Size(1000, 23);
            this.cpEdge.Name = "cpEdge";
            this.cpEdge.Size = new System.Drawing.Size(300, 23);
            this.cpEdge.TabIndex = 12;
            this.cpEdge.ColorChanged += new System.EventHandler(this.SettingChanged);
            // 
            // cpPebble
            // 
            this.cpPebble.Color = null;
            this.cpPebble.Label = "Pebble Color:";
            this.cpPebble.Location = new System.Drawing.Point(6, 146);
            this.cpPebble.MaximumSize = new System.Drawing.Size(1000, 23);
            this.cpPebble.Name = "cpPebble";
            this.cpPebble.Size = new System.Drawing.Size(300, 23);
            this.cpPebble.TabIndex = 11;
            this.cpPebble.ColorChanged += new System.EventHandler(this.SettingChanged);
            // 
            // cpNodeBorder
            // 
            this.cpNodeBorder.Color = null;
            this.cpNodeBorder.Label = "Node Border Color:";
            this.cpNodeBorder.Location = new System.Drawing.Point(6, 117);
            this.cpNodeBorder.MaximumSize = new System.Drawing.Size(1000, 23);
            this.cpNodeBorder.Name = "cpNodeBorder";
            this.cpNodeBorder.Size = new System.Drawing.Size(300, 23);
            this.cpNodeBorder.TabIndex = 10;
            this.cpNodeBorder.ColorChanged += new System.EventHandler(this.SettingChanged);
            // 
            // cpNodeFill
            // 
            this.cpNodeFill.Color = null;
            this.cpNodeFill.Label = "Node Fill Color:";
            this.cpNodeFill.Location = new System.Drawing.Point(6, 88);
            this.cpNodeFill.MaximumSize = new System.Drawing.Size(1000, 23);
            this.cpNodeFill.Name = "cpNodeFill";
            this.cpNodeFill.Size = new System.Drawing.Size(300, 23);
            this.cpNodeFill.TabIndex = 9;
            this.cpNodeFill.ColorChanged += new System.EventHandler(this.SettingChanged);
            // 
            // cpText
            // 
            this.cpText.Color = null;
            this.cpText.Label = "Text Color:";
            this.cpText.Location = new System.Drawing.Point(6, 59);
            this.cpText.MaximumSize = new System.Drawing.Size(1000, 23);
            this.cpText.Name = "cpText";
            this.cpText.Size = new System.Drawing.Size(300, 23);
            this.cpText.TabIndex = 8;
            this.cpText.ColorChanged += new System.EventHandler(this.SettingChanged);
            // 
            // cbFonts
            // 
            this.cbFonts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFonts.FormattingEnabled = true;
            this.cbFonts.Location = new System.Drawing.Point(163, 30);
            this.cbFonts.Name = "cbFonts";
            this.cbFonts.Size = new System.Drawing.Size(248, 24);
            this.cbFonts.TabIndex = 7;
            this.cbFonts.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbFonts_DrawItem);
            this.cbFonts.SelectedIndexChanged += new System.EventHandler(this.cbFonts_SelectedIndexChanged);
            this.cbFonts.SelectedValueChanged += new System.EventHandler(this.SettingChanged);
            // 
            // lbl_Font
            // 
            this.lbl_Font.AutoSize = true;
            this.lbl_Font.Location = new System.Drawing.Point(6, 33);
            this.lbl_Font.Name = "lbl_Font";
            this.lbl_Font.Size = new System.Drawing.Size(34, 15);
            this.lbl_Font.TabIndex = 5;
            this.lbl_Font.Text = "Font:";
            // 
            // gpScaling
            // 
            this.gpScaling.Controls.Add(this.cbRescalePebbleGame);
            this.gpScaling.Controls.Add(this.cbScaleOnResize);
            this.gpScaling.Controls.Add(this.cbScaleOnLoad);
            this.gpScaling.Location = new System.Drawing.Point(12, 338);
            this.gpScaling.Name = "gpScaling";
            this.gpScaling.Size = new System.Drawing.Size(417, 97);
            this.gpScaling.TabIndex = 6;
            this.gpScaling.TabStop = false;
            this.gpScaling.Text = "Graph scaling";
            // 
            // cbRescalePebbleGame
            // 
            this.cbRescalePebbleGame.AutoSize = true;
            this.cbRescalePebbleGame.Location = new System.Drawing.Point(6, 72);
            this.cbRescalePebbleGame.Name = "cbRescalePebbleGame";
            this.cbRescalePebbleGame.Size = new System.Drawing.Size(200, 19);
            this.cbRescalePebbleGame.TabIndex = 2;
            this.cbRescalePebbleGame.Text = "Rescale when pebble game starts";
            this.cbRescalePebbleGame.UseVisualStyleBackColor = true;
            this.cbRescalePebbleGame.CheckedChanged += new System.EventHandler(this.SettingChanged);
            // 
            // cbScaleOnResize
            // 
            this.cbScaleOnResize.AutoSize = true;
            this.cbScaleOnResize.Location = new System.Drawing.Point(6, 47);
            this.cbScaleOnResize.Name = "cbScaleOnResize";
            this.cbScaleOnResize.Size = new System.Drawing.Size(210, 19);
            this.cbScaleOnResize.TabIndex = 1;
            this.cbScaleOnResize.Text = "Rescale when windowsize changed";
            this.cbScaleOnResize.UseVisualStyleBackColor = true;
            this.cbScaleOnResize.CheckedChanged += new System.EventHandler(this.SettingChanged);
            // 
            // cbScaleOnLoad
            // 
            this.cbScaleOnLoad.AutoSize = true;
            this.cbScaleOnLoad.Location = new System.Drawing.Point(6, 22);
            this.cbScaleOnLoad.Name = "cbScaleOnLoad";
            this.cbScaleOnLoad.Size = new System.Drawing.Size(206, 19);
            this.cbScaleOnLoad.TabIndex = 0;
            this.cbScaleOnLoad.Text = "Rescale when new graph is loaded";
            this.cbScaleOnLoad.UseVisualStyleBackColor = true;
            this.cbScaleOnLoad.CheckedChanged += new System.EventHandler(this.SettingChanged);
            // 
            // gbSolver
            // 
            this.gbSolver.Controls.Add(this.cbUseAxioms);
            this.gbSolver.Location = new System.Drawing.Point(12, 441);
            this.gbSolver.Name = "gbSolver";
            this.gbSolver.Size = new System.Drawing.Size(417, 52);
            this.gbSolver.TabIndex = 7;
            this.gbSolver.TabStop = false;
            this.gbSolver.Text = "Solver";
            // 
            // cbUseAxioms
            // 
            this.cbUseAxioms.AutoSize = true;
            this.cbUseAxioms.Location = new System.Drawing.Point(6, 22);
            this.cbUseAxioms.Name = "cbUseAxioms";
            this.cbUseAxioms.Size = new System.Drawing.Size(217, 19);
            this.cbUseAxioms.TabIndex = 0;
            this.cbUseAxioms.Text = "Optimize the solver by using axioms";
            this.cbUseAxioms.UseVisualStyleBackColor = true;
            this.cbUseAxioms.CheckedChanged += new System.EventHandler(this.SettingChanged);
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 530);
            this.Controls.Add(this.gbSolver);
            this.Controls.Add(this.gpScaling);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(457, 513);
            this.Name = "SettingsWindow";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsWindow_FormClosing);
            this.Load += new System.EventHandler(this.SettingsWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSettingsDrawboard)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpScaling.ResumeLayout(false);
            this.gpScaling.PerformLayout();
            this.gbSolver.ResumeLayout(false);
            this.gbSolver.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Button btnApply;
        private PictureBox pbSettingsDrawboard;
        private Button btnCancel;
        private GroupBox groupBox1;
        private Label lbl_Font;
        private ComboBox cbFonts;
        private ColorPicker cpText;
        private ColorPicker cpEdge;
        private ColorPicker cpPebble;
        private ColorPicker cpNodeBorder;
        private ColorPicker cpNodeFill;
        private GroupBox gpScaling;
        private CheckBox cbScaleOnResize;
        private CheckBox cbScaleOnLoad;
        private CheckBox cbRescalePebbleGame;
        private GroupBox gbSolver;
        private CheckBox cbUseAxioms;
    }
}