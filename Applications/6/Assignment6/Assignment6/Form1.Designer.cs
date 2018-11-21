namespace Assignment6
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label_generation_size = new System.Windows.Forms.Label();
            this.inputSampleSize = new System.Windows.Forms.TextBox();
            this.startDistribution = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.outputLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.inputProb = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_generation_size
            // 
            this.label_generation_size.AutoSize = true;
            this.label_generation_size.Location = new System.Drawing.Point(20, 20);
            this.label_generation_size.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_generation_size.Name = "label_generation_size";
            this.label_generation_size.Size = new System.Drawing.Size(76, 20);
            this.label_generation_size.TabIndex = 0;
            this.label_generation_size.Text = "Gen size:";
            // 
            // inputSampleSize
            // 
            this.inputSampleSize.Location = new System.Drawing.Point(128, 15);
            this.inputSampleSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.inputSampleSize.Name = "inputSampleSize";
            this.inputSampleSize.Size = new System.Drawing.Size(148, 26);
            this.inputSampleSize.TabIndex = 1;
            // 
            // startDistribution
            // 
            this.startDistribution.Location = new System.Drawing.Point(639, 12);
            this.startDistribution.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.startDistribution.Name = "startDistribution";
            this.startDistribution.Size = new System.Drawing.Size(135, 34);
            this.startDistribution.TabIndex = 2;
            this.startDistribution.Text = "Generate";
            this.startDistribution.UseVisualStyleBackColor = true;
            this.startDistribution.Click += new System.EventHandler(this.StartDistribution_Click);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(430, 86);
            this.chart1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Distributions";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(752, 534);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Distribution growth:";
            // 
            // outputLabel
            // 
            this.outputLabel.Location = new System.Drawing.Point(18, 86);
            this.outputLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(404, 534);
            this.outputLabel.TabIndex = 5;
            this.outputLabel.Text = " ";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(286, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 35);
            this.label3.TabIndex = 0;
            this.label3.Text = "Probability of success:";
            // 
            // inputProb
            // 
            this.inputProb.Location = new System.Drawing.Point(464, 15);
            this.inputProb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.inputProb.Name = "inputProb";
            this.inputProb.Size = new System.Drawing.Size(148, 26);
            this.inputProb.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.inputProb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.startDistribution);
            this.Controls.Add(this.inputSampleSize);
            this.Controls.Add(this.label_generation_size);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Growth distribution";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_generation_size;
        private System.Windows.Forms.TextBox inputSampleSize;
        private System.Windows.Forms.Button startDistribution;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox inputProb;
    }
}

