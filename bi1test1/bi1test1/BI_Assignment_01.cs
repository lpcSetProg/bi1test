﻿/*
* FILE : BI_Assignment_01.cs
* PROJECT : PROG3240 - Business Intelligence - Assignment 1
* PROGRAMMERS : Lev Cocarell
* FIRST VERSION : 2018-09-12
* DESCRIPTION :
* This file contains the source code for an Win Forms application that demonstrates the 
* use of the Chart control to visualize data. It demonstrates the following four charts: pie chart,
* line chart, control chart, Pareto Diagram.
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
        * Returns    : N/A
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
            chart_PieChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            chart_PieChart.Titles.Add("Pie Chart");
            chart_PieChart.Titles[0].Alignment = ContentAlignment.TopCenter;
            chart_PieChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
        }

        /*
        * Method     : InitializeControlChart()
        * Description: In ortder to initialize the control chart, I used horizontal strip lines Sourced from https://stackoverflow.com/questions/21990022/add-horizontal-line-to-chart-in-c-sharp
        * Parameters : N/A
        * Returns    : N?A
        */
        private void InitializeControlChart()
        {
            label_ControlLine.ForeColor = System.Drawing.Color.Black;
            label_LowerControlLimit.ForeColor = System.Drawing.Color.Green;
            label_UpperControlLimit.ForeColor = System.Drawing.Color.Red;

            chart_ControlChart.Titles.Add("Control Chart");

            // rename series one 
            chart_ControlChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            // add circle style marks 
            chart_ControlChart.Series[0].MarkerStyle = MarkerStyle.Circle;

            // Add center control line (using horizontal strip line) to chart
            StripLine stripline_ControlLine = new StripLine();
            stripline_ControlLine.Interval = 0;
            stripline_ControlLine.IntervalOffset = 35;
            stripline_ControlLine.StripWidth = 1;
            stripline_ControlLine.BackColor = Color.Black;
            chart_ControlChart.ChartAreas[0].AxisY.StripLines.Add(stripline_ControlLine);

            // Add Lower Control Limit strip line to chart 
            StripLine stripline_LowerControlLimit = new StripLine();
            stripline_LowerControlLimit.Interval = 0;
            stripline_LowerControlLimit.IntervalOffset = 10;
            stripline_LowerControlLimit.StripWidth = 1;
            stripline_LowerControlLimit.BackColor = Color.Green;
            chart_ControlChart.ChartAreas[0].AxisY.StripLines.Add(stripline_LowerControlLimit);

            // Add Upper Control Limit strip line to chart 
            StripLine stripline_UpperControlLimit = new StripLine();
            stripline_UpperControlLimit.Interval = 0;
            stripline_UpperControlLimit.IntervalOffset = 60; 
            stripline_UpperControlLimit.StripWidth = 1;
            stripline_UpperControlLimit.BackColor = Color.Red;
            chart_ControlChart.ChartAreas[0].AxisY.StripLines.Add(stripline_UpperControlLimit);

            // subscribe method to numericUpDown events to control strip lines on charts
            numericUpDown_ControlLine.ValueChanged += NumericUpDown_ControlLine_ValueChanged;
            numericUpDown_LowerControlLimit.ValueChanged += NumericUpDown_LowerControlLimit_ValueChanged;
            numericUpDown_UpperControlLimit.ValueChanged += NumericUpDown_UpperControlLimit_ValueChanged;
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
            numericUpDown_ControlLine.Value = 45;
            numericUpDown_UpperControlLimit.Value = 90;
            numericUpDown_LowerControlLimit.Value = 10;
        }

        /*
        * Method     : InitializeParetoChart()
        * Description: Add series to chart which will be used to construct Pareto chart. Based on example from
        * Microsoft : 
        * Parameters : N/A
        * Returns    : N/A
        */
        private void InitializeParetoChart()
        {
            // Add visual effects to Pareto chart 
            chart_ParetoChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
         
            // Ensure source chart for Pareto is a column chart 
            chart_ParetoChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            // Add other series (Target Line) to chart 
            chart_ParetoChart.Series.Add("Target Line");

            // Format appearance of 'control line'
            chart_ParetoChart.Series["Target Line"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart_ParetoChart.Series["Target Line"].IsValueShownAsLabel = true;
            chart_ParetoChart.Series["Target Line"].MarkerColor = Color.Red;
            chart_ParetoChart.Series["Target Line"].MarkerStyle = MarkerStyle.Circle;
            chart_ParetoChart.Series["Target Line"].MarkerBorderColor = Color.MidnightBlue;
            chart_ParetoChart.Series["Target Line"].MarkerSize = 8;
            chart_ParetoChart.Series["Target Line"].LabelFormat = "0.#";  // format with one decimal and leading zero
        }


        /*
        * Method     : InitializeLineChart()
        * Description: Format and set chart as a line chart.
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

            // connect data grid view control to data
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

            // Label chart area axis 
            chart_LineChart.ChartAreas[0].AxisX.Title = "Time";
            chart_LineChart.ChartAreas[0].AxisY.Title = "Sales";

            dataTable_Line.Columns.Add("X");
            dataTable_Line.Columns.Add("Y");

            dataGridView_LineChart.Anchor = AnchorStyles.Top;
            dataGridView_LineChart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // connect data grid view control to data
            dataGridView_LineChart.DataSource = dataTable_Line;

            // bind chart view to datasource as well
            chart_LineChart.DataSource = dataTable_Line;

            chart_LineChart.DataBind();
       
            // add a RowChanging event handler for the table 
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

            // Label chart area axis 
            chart_ControlChart.ChartAreas[0].AxisX.Title = "Sample Number";
            chart_ControlChart.ChartAreas[0].AxisY.Title = "Percent Recovery";

            dataTable_Control.Columns.Add("X");
            dataTable_Control.Columns.Add("Y");

            dataGridView_ControlChart.Anchor = AnchorStyles.Top;
            dataGridView_ControlChart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // connect data grid view control to data
            dataGridView_ControlChart.DataSource = dataTable_Control;
            chart_ControlChart.DataSource = dataTable_Control;

            // Bind data 
            chart_ControlChart.DataBind();

            // add a RowChanging event handler for the table 
            dataTable_Control.RowChanged += DataTable_Control_RowChanged;
        }

        /*
        * Method     : initializeDataGridView_ParetoChart()
        * Description: https://www.youtube.com/watch?v=R_VOAu2BqCk
        * Parameters : N/A
        * Returns    : N?A
        */
        private void initializeDataGridView_ParetoChart()
        {
            // Set Pareto "column" chart 
            chart_ParetoChart.Series[0].XValueMember = "X";
            chart_ParetoChart.Series[0].YValueMembers = "Y";

            // Label chart area axis 
            chart_ParetoChart.ChartAreas[0].AxisX.Title = "Time";
            chart_ParetoChart.ChartAreas[0].AxisY.Title = "Sales";

            dataTable_Pareto.Columns.Add("X");
            dataTable_Pareto.Columns.Add("Y");
           

            dataGridView_ParetoChart.Anchor = AnchorStyles.Top;
            dataGridView_ParetoChart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // connect data grid view control to data 
            dataGridView_ParetoChart.DataSource = dataTable_Pareto;
            chart_ParetoChart.DataSource = dataTable_Pareto;

           
            // Bind data 
            chart_ParetoChart.DataBind();

            // add a RowChanging event handler for the table 
            dataTable_Pareto.RowChanged += DataTable_Pareto_RowChanged;
        }

      
        // Events //

        /*
        * Method     : DT_RowChanged()
        * Description: Bind data on row changing event. 
        */
        private void Dt_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            chart_LineChart.DataBind();
        }

        /*
        * Method     : DataTable_Pie_RowChanged()
        * Description: Bind data on row changing event. 
        */
        private void DataTable_Pie_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            chart_PieChart.DataBind();
        }

        /*
       * Method     : DataTable_Control_RowChanged()
       * Description: Bind data on row changing event. 
       * Parameters : N/A
       * Returns    : N?A
       */
        private void DataTable_Control_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            chart_ControlChart.DataBind();
        }



        /*
        * Method     : DataTable_Pareto_RowChanged()
        * Description: Bind data on row changing event. Sourced from example from ___ 
        * Parameters : N/A
        * Returns    : N?A
        */
        private void DataTable_Pareto_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            // sort the data in the series to be by values in descending order
            chart_ParetoChart.DataManipulator.Sort(PointSortOrder.Descending, "Series1");

            // find the total of all points in the source series
            double total = 0.0;
            foreach (DataPoint pt in chart_ParetoChart.Series[0].Points)
                total += pt.YValues[0];

            // set the max value on the primary axis to total
            chart_ParetoChart.ChartAreas["ChartArea1"].AxisY.Maximum = total;

            // assign the series to the same chart area as the column chart
            chart_ParetoChart.Series["Target Line"].ChartArea = chart_ParetoChart.Series[0].ChartArea;

            // Set Pareto "target line" component 
            chart_ParetoChart.Series["Target Line"].YAxisType = AxisType.Secondary;
            chart_ParetoChart.ChartAreas[0].AxisY2.Maximum = 100;

            // locale specific percentage format with no decimals
            chart_ParetoChart.ChartAreas[0].AxisY2.LabelStyle.Format = "P0";

            // turn off the end point values of the primary X axis
            chart_ParetoChart.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;

            // for each point in the source series find % of total and assign to series
            double percentage = 0.0;

            foreach (DataPoint pt in chart_ParetoChart.Series[0].Points)
            {
                // data point y values 
                percentage += (pt.YValues[0] / total * 100.0);
                chart_ParetoChart.Series["Target Line"].Points.Add(Math.Round(percentage, 2));
            }

            chart_ParetoChart.DataBind();
        }


        /*
        * Method     : 
        * Description: NumericUpDown_UpperControlLimit_ValueChanged
        * Parameters : N/A
        * Returns    : N?A
        */
        private void NumericUpDown_UpperControlLimit_ValueChanged(object sender, EventArgs e)
        {
            decimal upperLineLimitValue = numericUpDown_UpperControlLimit.Value;
            chart_ControlChart.ChartAreas[0].AxisY.StripLines[2].IntervalOffset = decimal.ToDouble(upperLineLimitValue); // average value of the

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
            chart_ControlChart.ChartAreas[0].AxisY.StripLines[0].IntervalOffset = decimal.ToDouble(controlLineValue); // average value of the y axis; eg:
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
