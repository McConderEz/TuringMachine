namespace TuringMachine
{
    partial class StartButton
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.OutPutBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.InputWordBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.OutPutManyBox = new System.Windows.Forms.TextBox();
            this.CreateGraph = new System.Windows.Forms.Button();
            this.DiffGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.DiffGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // OutPutBox
            // 
            this.OutPutBox.Location = new System.Drawing.Point(15, 102);
            this.OutPutBox.Multiline = true;
            this.OutPutBox.Name = "OutPutBox";
            this.OutPutBox.ReadOnly = true;
            this.OutPutBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutPutBox.Size = new System.Drawing.Size(333, 248);
            this.OutPutBox.TabIndex = 0;
            this.OutPutBox.TextChanged += new System.EventHandler(this.OutPutBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "L={wcv|w,v ∈ {0,1} * & |x| = 2k & |v| = 2n+1 & k!=n & k,n >= 0}";
            // 
            // InputWordBox
            // 
            this.InputWordBox.Location = new System.Drawing.Point(12, 34);
            this.InputWordBox.Name = "InputWordBox";
            this.InputWordBox.Size = new System.Drawing.Size(294, 20);
            this.InputWordBox.TabIndex = 2;
            this.InputWordBox.TextChanged += new System.EventHandler(this.InputButton_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "Запуск ОМТ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(99, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 30);
            this.button2.TabIndex = 4;
            this.button2.Text = "Запуск ММТ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // OutPutManyBox
            // 
            this.OutPutManyBox.Location = new System.Drawing.Point(352, 102);
            this.OutPutManyBox.Multiline = true;
            this.OutPutManyBox.Name = "OutPutManyBox";
            this.OutPutManyBox.ReadOnly = true;
            this.OutPutManyBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutPutManyBox.Size = new System.Drawing.Size(333, 248);
            this.OutPutManyBox.TabIndex = 5;
            // 
            // CreateGraph
            // 
            this.CreateGraph.Location = new System.Drawing.Point(186, 61);
            this.CreateGraph.Name = "CreateGraph";
            this.CreateGraph.Size = new System.Drawing.Size(120, 30);
            this.CreateGraph.TabIndex = 6;
            this.CreateGraph.Text = "Построить График";
            this.CreateGraph.UseVisualStyleBackColor = true;
            this.CreateGraph.Click += new System.EventHandler(this.CreateGraph_Click);
            // 
            // DiffGraph
            // 
            chartArea1.Name = "ChartArea1";
            this.DiffGraph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.DiffGraph.Legends.Add(legend1);
            this.DiffGraph.Location = new System.Drawing.Point(15, 356);
            this.DiffGraph.Name = "DiffGraph";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Сложность ОМТ";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Red;
            series2.LabelForeColor = System.Drawing.Color.Bisque;
            series2.Legend = "Legend1";
            series2.MarkerBorderColor = System.Drawing.Color.Red;
            series2.Name = "Сложность ММТ";
            this.DiffGraph.Series.Add(series1);
            this.DiffGraph.Series.Add(series2);
            this.DiffGraph.Size = new System.Drawing.Size(479, 300);
            this.DiffGraph.TabIndex = 7;
            this.DiffGraph.Text = "chart1";
            // 
            // StartButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 732);
            this.Controls.Add(this.DiffGraph);
            this.Controls.Add(this.CreateGraph);
            this.Controls.Add(this.OutPutManyBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.InputWordBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OutPutBox);
            this.Name = "StartButton";
            this.Text = "TuringMachine";
            this.Load += new System.EventHandler(this.StartButton_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DiffGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox OutPutBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InputWordBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox OutPutManyBox;
        private System.Windows.Forms.Button CreateGraph;
        private System.Windows.Forms.DataVisualization.Charting.Chart DiffGraph;
    }
}

