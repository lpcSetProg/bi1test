﻿namespace bi1test1
{
    partial class BusinessIntelligenceCharts
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tabPage_PieChart = new System.Windows.Forms.TabPage();
            this.dataGridView_PieChart = new System.Windows.Forms.DataGridView();
            this.chart_PieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage_LineChart = new System.Windows.Forms.TabPage();
            this.dataGridView_LineChart = new System.Windows.Forms.DataGridView();
            this.chart_LineChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage_ControlChart = new System.Windows.Forms.TabPage();
            this.tabPage_ParetoChart = new System.Windows.Forms.TabPage();
            this.dataGridView_ControlChart = new System.Windows.Forms.DataGridView();
            this.chart_ControlChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView_ParetoChart = new System.Windows.Forms.DataGridView();
            this.chart_ParetoChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl_Main.SuspendLayout();
            this.tabPage_PieChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PieChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_PieChart)).BeginInit();
            this.tabPage_LineChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LineChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_LineChart)).BeginInit();
            this.tabPage_ControlChart.SuspendLayout();
            this.tabPage_ParetoChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ControlChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_ControlChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ParetoChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_ParetoChart)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Controls.Add(this.tabPage_PieChart);
            this.tabControl_Main.Controls.Add(this.tabPage_LineChart);
            this.tabControl_Main.Controls.Add(this.tabPage_ControlChart);
            this.tabControl_Main.Controls.Add(this.tabPage_ParetoChart);
            this.tabControl_Main.Location = new System.Drawing.Point(-4, -1);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(676, 406);
            this.tabControl_Main.TabIndex = 0;
            // 
            // tabPage_PieChart
            // 
            this.tabPage_PieChart.Controls.Add(this.dataGridView_PieChart);
            this.tabPage_PieChart.Controls.Add(this.chart_PieChart);
            this.tabPage_PieChart.Location = new System.Drawing.Point(4, 22);
            this.tabPage_PieChart.Name = "tabPage_PieChart";
            this.tabPage_PieChart.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_PieChart.Size = new System.Drawing.Size(668, 380);
            this.tabPage_PieChart.TabIndex = 0;
            this.tabPage_PieChart.Text = "Pie Chart";
            this.tabPage_PieChart.UseVisualStyleBackColor = true;
            // 
            // dataGridView_PieChart
            // 
            this.dataGridView_PieChart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_PieChart.Location = new System.Drawing.Point(350, 0);
            this.dataGridView_PieChart.Name = "dataGridView_PieChart";
            this.dataGridView_PieChart.Size = new System.Drawing.Size(317, 378);
            this.dataGridView_PieChart.TabIndex = 1;
            // 
            // chart_PieChart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_PieChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_PieChart.Legends.Add(legend1);
            this.chart_PieChart.Location = new System.Drawing.Point(3, 0);
            this.chart_PieChart.Name = "chart_PieChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_PieChart.Series.Add(series1);
            this.chart_PieChart.Size = new System.Drawing.Size(350, 378);
            this.chart_PieChart.TabIndex = 0;
            this.chart_PieChart.Text = "chart1";
            // 
            // tabPage_LineChart
            // 
            this.tabPage_LineChart.Controls.Add(this.dataGridView_LineChart);
            this.tabPage_LineChart.Controls.Add(this.chart_LineChart);
            this.tabPage_LineChart.Location = new System.Drawing.Point(4, 22);
            this.tabPage_LineChart.Name = "tabPage_LineChart";
            this.tabPage_LineChart.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_LineChart.Size = new System.Drawing.Size(668, 380);
            this.tabPage_LineChart.TabIndex = 1;
            this.tabPage_LineChart.Text = "Line Chart";
            this.tabPage_LineChart.UseVisualStyleBackColor = true;
            // 
            // dataGridView_LineChart
            // 
            this.dataGridView_LineChart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_LineChart.Location = new System.Drawing.Point(350, 0);
            this.dataGridView_LineChart.Name = "dataGridView_LineChart";
            this.dataGridView_LineChart.Size = new System.Drawing.Size(317, 378);
            this.dataGridView_LineChart.TabIndex = 3;
            // 
            // chart_LineChart
            // 
            chartArea2.Name = "ChartArea1";
            this.chart_LineChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart_LineChart.Legends.Add(legend2);
            this.chart_LineChart.Location = new System.Drawing.Point(3, 0);
            this.chart_LineChart.Name = "chart_LineChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart_LineChart.Series.Add(series2);
            this.chart_LineChart.Size = new System.Drawing.Size(350, 378);
            this.chart_LineChart.TabIndex = 2;
            this.chart_LineChart.Text = "chart2";
            // 
            // tabPage_ControlChart
            // 
            this.tabPage_ControlChart.Controls.Add(this.dataGridView_ControlChart);
            this.tabPage_ControlChart.Controls.Add(this.chart_ControlChart);
            this.tabPage_ControlChart.Location = new System.Drawing.Point(4, 22);
            this.tabPage_ControlChart.Name = "tabPage_ControlChart";
            this.tabPage_ControlChart.Size = new System.Drawing.Size(668, 380);
            this.tabPage_ControlChart.TabIndex = 2;
            this.tabPage_ControlChart.Text = "Control Chart";
            this.tabPage_ControlChart.UseVisualStyleBackColor = true;
            // 
            // tabPage_ParetoChart
            // 
            this.tabPage_ParetoChart.Controls.Add(this.dataGridView_ParetoChart);
            this.tabPage_ParetoChart.Controls.Add(this.chart_ParetoChart);
            this.tabPage_ParetoChart.Location = new System.Drawing.Point(4, 22);
            this.tabPage_ParetoChart.Name = "tabPage_ParetoChart";
            this.tabPage_ParetoChart.Size = new System.Drawing.Size(668, 380);
            this.tabPage_ParetoChart.TabIndex = 3;
            this.tabPage_ParetoChart.Text = "Pareto Chart";
            this.tabPage_ParetoChart.UseVisualStyleBackColor = true;
            // 
            // dataGridView_ControlChart
            // 
            this.dataGridView_ControlChart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ControlChart.Location = new System.Drawing.Point(349, 1);
            this.dataGridView_ControlChart.Name = "dataGridView_ControlChart";
            this.dataGridView_ControlChart.Size = new System.Drawing.Size(317, 378);
            this.dataGridView_ControlChart.TabIndex = 3;
            // 
            // chart_ControlChart
            // 
            chartArea3.Name = "ChartArea1";
            this.chart_ControlChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart_ControlChart.Legends.Add(legend3);
            this.chart_ControlChart.Location = new System.Drawing.Point(2, 1);
            this.chart_ControlChart.Name = "chart_ControlChart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart_ControlChart.Series.Add(series3);
            this.chart_ControlChart.Size = new System.Drawing.Size(350, 378);
            this.chart_ControlChart.TabIndex = 2;
            this.chart_ControlChart.Text = "chart1";
            // 
            // dataGridView_ParetoChart
            // 
            this.dataGridView_ParetoChart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ParetoChart.Location = new System.Drawing.Point(349, 1);
            this.dataGridView_ParetoChart.Name = "dataGridView_ParetoChart";
            this.dataGridView_ParetoChart.Size = new System.Drawing.Size(317, 378);
            this.dataGridView_ParetoChart.TabIndex = 3;
            // 
            // chart_ParetoChart
            // 
            chartArea4.Name = "ChartArea1";
            this.chart_ParetoChart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart_ParetoChart.Legends.Add(legend4);
            this.chart_ParetoChart.Location = new System.Drawing.Point(2, 1);
            this.chart_ParetoChart.Name = "chart_ParetoChart";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart_ParetoChart.Series.Add(series4);
            this.chart_ParetoChart.Size = new System.Drawing.Size(350, 378);
            this.chart_ParetoChart.TabIndex = 2;
            this.chart_ParetoChart.Text = "chart1";
            // 
            // BusinessIntelligenceCharts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 402);
            this.Controls.Add(this.tabControl_Main);
            this.Name = "BusinessIntelligenceCharts";
            this.Text = "Business Intelligence Chart Demo";
            this.tabControl_Main.ResumeLayout(false);
            this.tabPage_PieChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PieChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_PieChart)).EndInit();
            this.tabPage_LineChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LineChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_LineChart)).EndInit();
            this.tabPage_ControlChart.ResumeLayout(false);
            this.tabPage_ParetoChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ControlChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_ControlChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ParetoChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_ParetoChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_Main;
        private System.Windows.Forms.TabPage tabPage_PieChart;
        private System.Windows.Forms.TabPage tabPage_LineChart;
        private System.Windows.Forms.DataGridView dataGridView_PieChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_PieChart;
        private System.Windows.Forms.DataGridView dataGridView_LineChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_LineChart;
        private System.Windows.Forms.TabPage tabPage_ControlChart;
        private System.Windows.Forms.TabPage tabPage_ParetoChart;
        private System.Windows.Forms.DataGridView dataGridView_ControlChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_ControlChart;
        private System.Windows.Forms.DataGridView dataGridView_ParetoChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_ParetoChart;
    }
}
