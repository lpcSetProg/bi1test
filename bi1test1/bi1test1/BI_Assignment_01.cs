/*
* FILE : BI_Assignment_01.cs
* PROJECT : PROG3240 - Business Intelligence - Assignment 1
* PROGRAMMERS : Lev Cocarell
* FIRST VERSION : 2018-09-12
* DESCRIPTION :
* This file contains the source code for the 
* TITLE LEGEND
*/

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace bi1test1
{
    public partial class BusinessIntelligenceCharts : Form
    {
        // Create new global DataTables for each chart style.
        DataTable dataTable_Pie = new DataTable();
        DataTable dataTable_Line = new DataTable();
        DataTable dataTable_Control = new DataTable();
        DataTable dataTable_Pareto = new DataTable();

  
        /*
        * Method     : BusinessIntelligenceCharts()
        * Description: 
        * Parameters : N/A
        * Returns    : N?A
        */
        public BusinessIntelligenceCharts()
        {
            // Format form for UI controls
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

            // Initialize data
            InitializeComponent();
            InitializeCharts();
            InitializeDataGrids();
            InitializeControlLimits(); 

        }

        /*
         * Method     : InitializeControlLimits()
         * Description: Assign initial values to control chart (strip lines) to provide a 
         * guideline for user to start. 
         * Parameters : N/A
         * Returns    : N?A
        */
        private void InitializeControlLimits()
        {
            numericUpDown_ControlLine.Value = 35;
            numericUpDown_UpperControlLimit.Value = 90;
            numericUpDown_LowerControlLimit.Value = 10;
        }

        /*
        * Method     : InitializeCharts()
        * Description: 
        * Parameters : N/A
        * Returns    : N?A
        */
        private void InitializeCharts()
        {
            InitializePieChart();
            InitializeLineChart();
            InitializeControlChart();
            InitializeParetoChart();
        }

        /*
        * Method     : InitializeDataGrids()
        * Description: 
        * Parameters : N/A
        * Returns    : N?A
        */
        private void InitializeDataGrids()
        {
            initializeDataGridView_PieChart();
            initializeDataGridView_LineChart();
            initializeDataGridView_ControlChart();
            initializeDataGridView_ParetoChart();
        }

        /*
        * Method     : InitializePieChart()
        * Description: 
        * Parameters : N/A
        * Returns    : N?A
        */
        private void InitializePieChart()
        {
            chart_PieChart.Titles.Add("Pie Chart");
            chart_PieChart.Titles[0].Alignment = ContentAlignment.TopCenter;
            chart_PieChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
        }

        /*
        * Method     : InitializeControlChart()
        * Description: Sourced from https://stackoverflow.com/questions/21990022/add-horizontal-line-to-chart-in-c-sharp
        * Parameters : N/A
        * Returns    : N?A
        */
        private void InitializeControlChart()
        {
            chart_ControlChart.Titles.Add("Control Chart");

            // rename series one 
            chart_ControlChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            // add circle style marks 
            chart_ControlChart.Series[0].MarkerStyle = MarkerStyle.Circle;

            // Add mean control line (using horizontal strip line) to chart
            StripLine stripline_ControlLine = new StripLine();
            stripline_ControlLine.Interval = 0;
            stripline_ControlLine.IntervalOffset = 50; // average value of the y axis; eg:
            stripline_ControlLine.StripWidth = 1;
            stripline_ControlLine.BackColor = Color.Black;
            chart_ControlChart.ChartAreas[0].AxisY.StripLines.Add(stripline_ControlLine);

            // Add Lower Control Limit strip line to chart 
            StripLine stripline_LowerControlLimit = new StripLine();
            stripline_LowerControlLimit.Interval = 0;
            stripline_LowerControlLimit.IntervalOffset = 30; // average value of the y axis; eg:
            stripline_LowerControlLimit.StripWidth = 1;
            stripline_LowerControlLimit.BackColor = Color.Yellow;
            chart_ControlChart.ChartAreas[0].AxisY.StripLines.Add(stripline_LowerControlLimit);

            // Add Upper Control Limit strip line to chart 
            StripLine stripline_UpperControlLimit = new StripLine();
            stripline_UpperControlLimit.Interval = 0;
            stripline_UpperControlLimit.IntervalOffset = 50; // average value of the y axis; eg:
            stripline_UpperControlLimit.StripWidth = 1;
            stripline_UpperControlLimit.BackColor = Color.Red;
            chart_ControlChart.ChartAreas[0].AxisY.StripLines.Add(stripline_UpperControlLimit);

            // x axis is called POINT PABELS
            // y axis is called TIME ORDER of PRoduction

            // subscribe method to numericUpDown events to control strip lines on charts
            numericUpDown_ControlLine.ValueChanged += NumericUpDown_ControlLine_ValueChanged;
            numericUpDown_LowerControlLimit.ValueChanged += NumericUpDown_LowerControlLimit_ValueChanged;
            numericUpDown_UpperControlLimit.ValueChanged += NumericUpDown_UpperControlLimit_ValueChanged;
        }

        /*
        * Method     : InitializeParetoChart()
        * Description: 
        * Parameters : N/A
        * Returns    : N?A
        */
        private void InitializeParetoChart()
        {
            //https://stackoverflow.com/questions/30662584/percent-value-in-y-axis-of-column-chart-microsoft-chart-control
            //https://www.codeproject.com/Articles/802845/Pareto-Chart-Csharp

            chart_ParetoChart.Titles.Add("Pareto Chart");
            chart_ParetoChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;


            chart_ParetoChart.Series.Add("Target Line");
            chart_ParetoChart.Series["Target Line"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

        }

        /*
        * Method     : InitializeLineChart()
        * Description: 
        * Parameters : N/A
        * Returns    : N?A
        */
        private void InitializeLineChart()
        {
            chart_LineChart.Titles.Add("Line Chart");
            chart_LineChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart_LineChart.Series[0].MarkerStyle = MarkerStyle.Circle;
        }

        /*
        * Method     : initializeDataGridView_PieChart()
        * Description: 
        * Parameters : N/A
        * Returns    : N?A
        */
        private void initializeDataGridView_PieChart()
        {
            chart_PieChart.Series[0].XValueMember = "X";
            chart_PieChart.Series[0].YValueMembers = "Y";

            dataTable_Pie.Columns.Add("X");
            dataTable_Pie.Columns.Add("Y");

            dataGridView_PieChart.Anchor = AnchorStyles.Top;
            dataGridView_PieChart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView_PieChart.DataSource = dataTable_Pie;
            chart_PieChart.DataSource = dataTable_Pie;

            // Bind data 
            chart_PieChart.DataBind();

            dataTable_Pie.RowChanged += DataTable_Pie_RowChanged;
        }

        /*
        * Method     : initializeDataGridView_LineChart()
        * Description: 
        * Parameters : N/A
        * Returns    : N?A
        */
        private void initializeDataGridView_LineChart()
        {
            chart_LineChart.Series[0].XValueMember = "X";
            chart_LineChart.Series[0].YValueMembers = "Y";

            dataTable_Line.Columns.Add("X");
            dataTable_Line.Columns.Add("Y");

            dataGridView_LineChart.Anchor = AnchorStyles.Top;
            dataGridView_LineChart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView_LineChart.DataSource = dataTable_Line;
            chart_LineChart.DataSource = dataTable_Line;

            chart_LineChart.DataBind();
            //// bind chart view to datasource as well
            //!!!! ondatachange event handler for row changed data table; 
            ////dataGridView_LineChart.DataSource = dt.AutoGenerateColumns = false;
            //dataGridView_LineChart.AutoSize = true;
            //dataGridView_LineChart.DataSource = bindingSource1;
            dataTable_Line.RowChanged += Dt_RowChanged;

        }

        /*
        * Method     : initializeDataGridView_ControlChart()
        * Description: 
        * Parameters : N/A
        * Returns    : N?A
        */
        private void initializeDataGridView_ControlChart()
        {
            chart_ControlChart.Series[0].XValueMember = "X";
            chart_ControlChart.Series[0].YValueMembers = "Y";

            dataTable_Control.Columns.Add("X");
            dataTable_Control.Columns.Add("Y");

            dataGridView_ControlChart.Anchor = AnchorStyles.Top;
            dataGridView_ControlChart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView_ControlChart.DataSource = dataTable_Control;
            chart_ControlChart.DataSource = dataTable_Control;

            // Bind data 
            chart_ControlChart.DataBind();

            dataTable_Control.RowChanged += DataTable_Control_RowChanged;

            // strip line 


        }

        /*
        * Method     : initializeDataGridView_ParetoChart()
        * Description: https://www.youtube.com/watch?v=R_VOAu2BqCk
        * Parameters : N/A
        * Returns    : N?A
        */
        private void initializeDataGridView_ParetoChart()
        {
            chart_ParetoChart.Series[0].XValueMember = "X";
            chart_ParetoChart.Series[0].YValueMembers = "Y";

            dataTable_Pareto.Columns.Add("X");
            dataTable_Pareto.Columns.Add("Y");

            dataGridView_ParetoChart.Anchor = AnchorStyles.Top;
            dataGridView_ParetoChart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView_ParetoChart.DataSource = dataTable_Pareto;
            chart_ParetoChart.DataSource = dataTable_Pareto;

            // Bind data 
            chart_ParetoChart.DataBind();

            dataTable_Pareto.RowChanged += DataTable_Pareto_RowChanged;
        }

      
        // Events //

        /*
        * Method     : DT_RowChanged()
        * Description: 
        * Parameters : N/A
        * Returns    : N?A
        */
        private void Dt_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            chart_LineChart.DataBind();
            //throw new System.NotImplementedException();
        }

        /*
        * Method     : DataTable_Pie_RowChanged()
        * Description: 
        * Parameters : N/A
        * Returns    : N?A
        */
        private void DataTable_Pie_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            chart_PieChart.DataBind();
        }

        /*
       * Method     : DataTable_Control_RowChanged()
       * Description: 
       * Parameters : N/A
       * Returns    : N?A
       */
        private void DataTable_Control_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            chart_ControlChart.DataBind();
        }

        /*
        * Method     : DataTable_Pareto_RowChanged()
        * Description: 
        * Parameters : N/A
        * Returns    : N?A
        */
        private void DataTable_Pareto_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            chart_ParetoChart.DataBind();
        }

        /*
        * Method     : 
        * Description: 
        * Parameters : N/A
        * Returns    : N?A
        */
        private void NumericUpDown_UpperControlLimit_ValueChanged(object sender, EventArgs e)
        {
            decimal upperLineLimitValue = numericUpDown_UpperControlLimit.Value;
            chart_ControlChart.ChartAreas[0].AxisY.StripLines[0].IntervalOffset = decimal.ToDouble(upperLineLimitValue); // average value of the

        }

        /*
        * Method     : 
        * Description: 
        * Parameters : N/A
        * Returns    : N?A
        */
        private void NumericUpDown_LowerControlLimit_ValueChanged(object sender, EventArgs e)
        {
            decimal lowerLineLimitValue = numericUpDown_LowerControlLimit.Value;
            chart_ControlChart.ChartAreas[0].AxisY.StripLines[1].IntervalOffset = decimal.ToDouble(lowerLineLimitValue); // average value of the y axis; eg:
        }

        /*
        * Method     : 
        * Description: 
        * Parameters : N/A
        * Returns    : N?A
        */
        private void NumericUpDown_ControlLine_ValueChanged(object sender, EventArgs e)
        {
            decimal controlLineValue = numericUpDown_ControlLine.Value;
            chart_ControlChart.ChartAreas[0].AxisY.StripLines[2].IntervalOffset = decimal.ToDouble(controlLineValue); // average value of the y axis; eg:
            // figure out where to add in index 
        }

        /*
        * Method     : button_ClearCharts_Click()
        * Description: 
        * Parameters : N/A
        * Returns    : N?A
        */
        private void button_ClearCharts_Click(object sender, EventArgs e)
        {
            foreach (var series in chart_LineChart.Series)
            {
                series.Points.Clear();
            }

            dataTable_Line.Rows.Clear();
            chart_LineChart.DataBind();


            foreach (var series in chart_PieChart.Series)
            {
                series.Points.Clear();
            }

            dataTable_Pie.Rows.Clear();
            chart_PieChart.DataBind();

            foreach (var series in chart_ControlChart.Series)
            {
                series.Points.Clear();
            }

            dataTable_Control.Rows.Clear();
            chart_ControlChart.DataBind();


            foreach (var series in chart_ParetoChart.Series)
            {
                series.Points.Clear();
            }

            dataTable_Pareto.Rows.Clear();
            chart_ParetoChart.DataBind();
        }
    }
}
