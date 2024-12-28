namespace NNDSA_Sem02
{
    partial class ExperimentDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExperimentDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelMin = new System.Windows.Forms.Label();
            this.labelMax = new System.Windows.Forms.Label();
            this.labelModus = new System.Windows.Forms.Label();
            this.labelArithmeticMean = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownNodes = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownExperiments = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonRunFile = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.labelFile = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExperiments)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of nodes";
            // 
            // buttonOk
            // 
            this.buttonOk.Image = global::NNDSA_Sem02.Properties.Resources.caret_circle_right_fill;
            this.buttonOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOk.Location = new System.Drawing.Point(343, 11);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(86, 26);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Run Rnd";
            this.buttonOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.labelMin, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelMax, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelModus, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelArithmeticMean, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 20);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(312, 123);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMin.Location = new System.Drawing.Point(159, 90);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(150, 33);
            this.labelMin.TabIndex = 15;
            this.labelMin.Text = "0";
            this.labelMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMax.Location = new System.Drawing.Point(159, 60);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(150, 30);
            this.labelMax.TabIndex = 15;
            this.labelMax.Text = "0";
            this.labelMax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelModus
            // 
            this.labelModus.AutoSize = true;
            this.labelModus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelModus.Location = new System.Drawing.Point(159, 30);
            this.labelModus.Name = "labelModus";
            this.labelModus.Size = new System.Drawing.Size(150, 30);
            this.labelModus.TabIndex = 14;
            this.labelModus.Text = "0";
            this.labelModus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelArithmeticMean
            // 
            this.labelArithmeticMean.AutoSize = true;
            this.labelArithmeticMean.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelArithmeticMean.Location = new System.Drawing.Point(159, 0);
            this.labelArithmeticMean.Name = "labelArithmeticMean";
            this.labelArithmeticMean.Size = new System.Drawing.Size(150, 30);
            this.labelArithmeticMean.TabIndex = 12;
            this.labelArithmeticMean.Text = "0";
            this.labelArithmeticMean.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 30);
            this.label3.TabIndex = 7;
            this.label3.Text = "Arithmetic mean";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 30);
            this.label4.TabIndex = 8;
            this.label4.Text = "Modus";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 30);
            this.label5.TabIndex = 9;
            this.label5.Text = "Max";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 33);
            this.label6.TabIndex = 10;
            this.label6.Text = "Min";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownNodes
            // 
            this.numericUpDownNodes.Location = new System.Drawing.Point(200, 14);
            this.numericUpDownNodes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownNodes.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDownNodes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNodes.Name = "numericUpDownNodes";
            this.numericUpDownNodes.Size = new System.Drawing.Size(131, 23);
            this.numericUpDownNodes.TabIndex = 4;
            this.numericUpDownNodes.Value = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Number of experiments";
            // 
            // numericUpDownExperiments
            // 
            this.numericUpDownExperiments.Location = new System.Drawing.Point(200, 38);
            this.numericUpDownExperiments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownExperiments.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownExperiments.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownExperiments.Name = "numericUpDownExperiments";
            this.numericUpDownExperiments.Size = new System.Drawing.Size(131, 23);
            this.numericUpDownExperiments.TabIndex = 6;
            this.numericUpDownExperiments.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 63);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(319, 153);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Height stats";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 220);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(417, 9);
            this.progressBar1.TabIndex = 8;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // buttonSave
            // 
            this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSave.Location = new System.Drawing.Point(343, 98);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(86, 26);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Save File";
            this.buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Image = ((System.Drawing.Image)(resources.GetObject("buttonLoad.Image")));
            this.buttonLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLoad.Location = new System.Drawing.Point(343, 69);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(86, 26);
            this.buttonLoad.TabIndex = 9;
            this.buttonLoad.Text = "Load File";
            this.buttonLoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonRunFile
            // 
            this.buttonRunFile.Image = global::NNDSA_Sem02.Properties.Resources.caret_circle_right_fill;
            this.buttonRunFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRunFile.Location = new System.Drawing.Point(343, 127);
            this.buttonRunFile.Name = "buttonRunFile";
            this.buttonRunFile.Size = new System.Drawing.Size(86, 26);
            this.buttonRunFile.TabIndex = 11;
            this.buttonRunFile.Text = "Run file";
            this.buttonRunFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonRunFile.UseVisualStyleBackColor = true;
            this.buttonRunFile.Click += new System.EventHandler(this.buttonRunFile_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(343, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "File: ";
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Location = new System.Drawing.Point(343, 173);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(34, 15);
            this.labelFile.TabIndex = 13;
            this.labelFile.Text = "none";
            // 
            // ExperimentDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(439, 238);
            this.Controls.Add(this.labelFile);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonRunFile);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numericUpDownExperiments);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownNodes);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExperimentDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Experiment";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExperiments)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private Button buttonOk;
        private TableLayoutPanel tableLayoutPanel1;
        private Label labelMin;
        private Label labelMax;
        private Label labelModus;
        private Label labelArithmeticMean;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private NumericUpDown numericUpDownNodes;
        private Label label2;
        private NumericUpDown numericUpDownExperiments;
        private GroupBox groupBox1;
        private ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private BindingSource bindingSource1;
        private Button buttonSave;
        private Button buttonLoad;
        private Button buttonRunFile;
        private Label label7;
        private Label labelFile;
    }
}