namespace PGS.UI
{
    partial class PebbleGameDataViewer
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
            this.lblPebblesInUse = new System.Windows.Forms.Label();
            this.lblMaxPebbles = new System.Windows.Forms.Label();
            this.tbCurrentPebbles = new System.Windows.Forms.TextBox();
            this.tbMaxPebbles = new System.Windows.Forms.TextBox();
            this.lblSteps = new System.Windows.Forms.Label();
            this.tbStepNumber = new System.Windows.Forms.TextBox();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.trackBarSimulationSpeed = new System.Windows.Forms.TrackBar();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.lblSolverStrategy = new System.Windows.Forms.Label();
            this.cbStrategy = new System.Windows.Forms.ComboBox();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.groupBoxLog = new System.Windows.Forms.GroupBox();
            this.btnMinMax = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSimulationSpeed)).BeginInit();
            this.groupBoxSettings.SuspendLayout();
            this.groupBoxLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPebblesInUse
            // 
            this.lblPebblesInUse.AutoSize = true;
            this.lblPebblesInUse.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPebblesInUse.Location = new System.Drawing.Point(10, 50);
            this.lblPebblesInUse.Name = "lblPebblesInUse";
            this.lblPebblesInUse.Size = new System.Drawing.Size(111, 21);
            this.lblPebblesInUse.TabIndex = 0;
            this.lblPebblesInUse.Text = "Pebbles in use:";
            // 
            // lblMaxPebbles
            // 
            this.lblMaxPebbles.AutoSize = true;
            this.lblMaxPebbles.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMaxPebbles.Location = new System.Drawing.Point(10, 80);
            this.lblMaxPebbles.Name = "lblMaxPebbles";
            this.lblMaxPebbles.Size = new System.Drawing.Size(141, 21);
            this.lblMaxPebbles.TabIndex = 1;
            this.lblMaxPebbles.Text = "Maximum pebbles:";
            // 
            // tbCurrentPebbles
            // 
            this.tbCurrentPebbles.BackColor = System.Drawing.Color.White;
            this.tbCurrentPebbles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCurrentPebbles.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbCurrentPebbles.Location = new System.Drawing.Point(162, 49);
            this.tbCurrentPebbles.Name = "tbCurrentPebbles";
            this.tbCurrentPebbles.ReadOnly = true;
            this.tbCurrentPebbles.Size = new System.Drawing.Size(219, 22);
            this.tbCurrentPebbles.TabIndex = 2;
            this.tbCurrentPebbles.Text = "0";
            this.tbCurrentPebbles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbMaxPebbles
            // 
            this.tbMaxPebbles.BackColor = System.Drawing.Color.White;
            this.tbMaxPebbles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMaxPebbles.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbMaxPebbles.Location = new System.Drawing.Point(162, 79);
            this.tbMaxPebbles.Name = "tbMaxPebbles";
            this.tbMaxPebbles.ReadOnly = true;
            this.tbMaxPebbles.Size = new System.Drawing.Size(219, 22);
            this.tbMaxPebbles.TabIndex = 3;
            this.tbMaxPebbles.Text = "0";
            this.tbMaxPebbles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSteps
            // 
            this.lblSteps.AutoSize = true;
            this.lblSteps.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSteps.Location = new System.Drawing.Point(10, 110);
            this.lblSteps.Name = "lblSteps";
            this.lblSteps.Size = new System.Drawing.Size(130, 21);
            this.lblSteps.TabIndex = 4;
            this.lblSteps.Text = "Number of Steps:";
            // 
            // tbStepNumber
            // 
            this.tbStepNumber.BackColor = System.Drawing.Color.White;
            this.tbStepNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbStepNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbStepNumber.Location = new System.Drawing.Point(162, 109);
            this.tbStepNumber.Name = "tbStepNumber";
            this.tbStepNumber.ReadOnly = true;
            this.tbStepNumber.Size = new System.Drawing.Size(219, 22);
            this.tbStepNumber.TabIndex = 5;
            this.tbStepNumber.Text = "0";
            this.tbStepNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSpeed.Location = new System.Drawing.Point(10, 140);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(133, 21);
            this.lblSpeed.TabIndex = 6;
            this.lblSpeed.Text = "Simulation speed:";
            // 
            // trackBarSimulationSpeed
            // 
            this.trackBarSimulationSpeed.Location = new System.Drawing.Point(200, 137);
            this.trackBarSimulationSpeed.Maximum = 20;
            this.trackBarSimulationSpeed.Name = "trackBarSimulationSpeed";
            this.trackBarSimulationSpeed.Size = new System.Drawing.Size(181, 45);
            this.trackBarSimulationSpeed.TabIndex = 7;
            this.trackBarSimulationSpeed.ValueChanged += new System.EventHandler(this.TrackBarSimulationSpeed_ValueChanged);
            // 
            // rtbLog
            // 
            this.rtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbLog.BackColor = System.Drawing.Color.White;
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLog.Location = new System.Drawing.Point(6, 22);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(699, 159);
            this.rtbLog.TabIndex = 8;
            this.rtbLog.Text = "";
            this.rtbLog.WordWrap = false;
            // 
            // lblSolverStrategy
            // 
            this.lblSolverStrategy.AutoSize = true;
            this.lblSolverStrategy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSolverStrategy.Location = new System.Drawing.Point(10, 20);
            this.lblSolverStrategy.Name = "lblSolverStrategy";
            this.lblSolverStrategy.Size = new System.Drawing.Size(57, 21);
            this.lblSolverStrategy.TabIndex = 9;
            this.lblSolverStrategy.Text = "Solver:";
            // 
            // cbStrategy
            // 
            this.cbStrategy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStrategy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbStrategy.FormattingEnabled = true;
            this.cbStrategy.Location = new System.Drawing.Point(162, 17);
            this.cbStrategy.Name = "cbStrategy";
            this.cbStrategy.Size = new System.Drawing.Size(219, 29);
            this.cbStrategy.TabIndex = 10;
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxSettings.Controls.Add(this.lblSolverStrategy);
            this.groupBoxSettings.Controls.Add(this.lblPebblesInUse);
            this.groupBoxSettings.Controls.Add(this.cbStrategy);
            this.groupBoxSettings.Controls.Add(this.lblMaxPebbles);
            this.groupBoxSettings.Controls.Add(this.tbCurrentPebbles);
            this.groupBoxSettings.Controls.Add(this.trackBarSimulationSpeed);
            this.groupBoxSettings.Controls.Add(this.tbMaxPebbles);
            this.groupBoxSettings.Controls.Add(this.lblSpeed);
            this.groupBoxSettings.Controls.Add(this.lblSteps);
            this.groupBoxSettings.Controls.Add(this.tbStepNumber);
            this.groupBoxSettings.Location = new System.Drawing.Point(3, 7);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(391, 187);
            this.groupBoxSettings.TabIndex = 11;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Control and Overview";
            // 
            // groupBoxLog
            // 
            this.groupBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxLog.Controls.Add(this.rtbLog);
            this.groupBoxLog.Location = new System.Drawing.Point(400, 7);
            this.groupBoxLog.Name = "groupBoxLog";
            this.groupBoxLog.Size = new System.Drawing.Size(711, 187);
            this.groupBoxLog.TabIndex = 12;
            this.groupBoxLog.TabStop = false;
            this.groupBoxLog.Text = "Simulation log";
            // 
            // btnMinMax
            // 
            this.btnMinMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinMax.Location = new System.Drawing.Point(1116, 14);
            this.btnMinMax.Name = "btnMinMax";
            this.btnMinMax.Size = new System.Drawing.Size(75, 23);
            this.btnMinMax.TabIndex = 13;
            this.btnMinMax.Text = "minimize";
            this.btnMinMax.UseVisualStyleBackColor = true;
            this.btnMinMax.Click += new System.EventHandler(this.MinMax_Click);
            // 
            // PebbleGameDataViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnMinMax);
            this.Controls.Add(this.groupBoxLog);
            this.Controls.Add(this.groupBoxSettings);
            this.Name = "PebbleGameDataViewer";
            this.Size = new System.Drawing.Size(1200, 200);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSimulationSpeed)).EndInit();
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.groupBoxLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblPebblesInUse;
        private Label lblMaxPebbles;
        private TextBox tbCurrentPebbles;
        private TextBox tbMaxPebbles;
        private Label lblSteps;
        private TextBox tbStepNumber;
        private Label lblSpeed;
        private TrackBar trackBarSimulationSpeed;
        private RichTextBox rtbLog;
        private Label lblSolverStrategy;
        private ComboBox cbStrategy;
        private GroupBox groupBoxSettings;
        private GroupBox groupBoxLog;
        private Button btnMinMax;
    }
}
