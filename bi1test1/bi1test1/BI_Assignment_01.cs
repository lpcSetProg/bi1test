/*
* FILE : BI_Assignment_01.cs
* PROJECT : PROG3240 - Business Intelligence - Assignment 1
* PROGRAMMERS : Lev Cocarell
* FIRST VERSION : 2018-09-12
* DESCRIPTION :
* This file contains the source code for an Win Forms application that demonstrates the 
* use of the Chart control to visualize data. It demonstrates the following four charts: pie chart,
* line chart, control chart, Pareto Diagram. Pareto chart. Pareto chart creation was based on example from Microsoft: 
* https://code.msdn.microsoft.com/Samples-Environments-for-b01e9c61
*/

using System;
using System.ComponentModel;
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
        * Description: Initialize form, create and format charts and data grid views (which control chart)
        */
        public BusinessIntelligenceCharts()
        {
            // Format form with UI controls
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

            // Initialize data for charts
            InitializeComponent();
            InitializeCharts();
            InitializeDataGrids();
        }

        /*
        * Method     : InitializeCharts()
        * Description: Initialize charts for all four tabs.
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
        * Description: Initialize each data for match chart
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
        * Description: Format pie chart in first tab. Set UI controls and add title and chart type. 
        */
        private void InitializePieChart()
        {
            chart_PieChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            chart_PieChart.Titles.Add("Pie Chart");
            chart_PieChart.Titles[0].Alignment = ContentAlignment.TopCenter;
            chart_PieChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
        }

        /*
       * Method     : InitializeLineChart()
       * Description: Format and set chart as a line chart in second tab.  Set UI controls and add title and chart type. 
       */
        private void InitializeLineChart()
        {
            chart_LineChart.Titles.Add("Line Chart");
            chart_LineChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart_LineChart.Series[0].MarkerStyle = MarkerStyle.Circle;
        }

        /*
        * Method     : InitializeControlChart()
        * Description: Format and set chart as a Control chart in third tab. In order to initialize the control chart, I used horizontal strip 
        * lines as control lines. These can be manually controlled by user via the use of numeric up down controllers. 
        * This method was sourced from https://stackoverflow.com/questions/21990022/add-horizontal-line-to-chart-in-c-sharp
        */
        private void InitializeControlChart()
        {
            // Initialize control lines for control chart via numeric up down controls. This allows 
            // user to have a better idea of what approx values they should input. 
            numericUpDown_ControlLine.Value = 45;
            numericUpDown_UpperControlLimit.Value = 90;
            numericUpDown_LowerControlLimit.Value = 10;

            // Control line numeric up down controls are labeled to correlate with color on bar 
            label_ControlLine.ForeColor = System.Drawing.Color.Black;
            label_LowerControlLimit.ForeColor = System.Drawing.Color.Green;
            label_UpperControlLimit.ForeColor = System.Drawing.Color.Red;

            chart_ControlChart.Titles.Add("Control Chart");

            // Set base chart for control chart as line chart  
            chart_ControlChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            // add circle style marks to line 
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

            // subscribe method to numericUpDown events to allow user to control strip lines on charts manually
            numericUpDown_ControlLine.ValueChanged += NumericUpDown_ControlLine_ValueChanged;
            numericUpDown_LowerControlLimit.ValueChanged += NumericUpDown_LowerControlLimit_ValueChanged;
            numericUpDown_UpperControlLimit.ValueChanged += NumericUpDown_UpperControlLimit_ValueChanged;
        }

        /*
        * Method     : InitializeParetoChart()
        * Description: Format and set chart as a Pareto chart in third tab. 
        * Add series to chart (column) which will be used to construct Pareto source chart (for line chart).
        */
        private void InitializeParetoChart()
        { 
            // Ensure source chart for Pareto is a column chart 
            chart_ParetoChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            // Add other series (Target Line) to chart 
            chart_ParetoChart.Series.Add("Target Line");

            // Format appearance of 'control line' for Pareto chart 
            chart_ParetoChart.Series["Target Line"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart_ParetoChart.Series["Target Line"].IsValueShownAsLabel = true;
            chart_ParetoChart.Series["Target Line"].MarkerColor = Color.Red;
            chart_ParetoChart.Series["Target Line"].MarkerStyle = MarkerStyle.Circle;
            chart_ParetoChart.Series["Target Line"].MarkerBorderColor = Color.MidnightBlue;
            chart_ParetoChart.Series["Target Line"].MarkerSize = 8;
            chart_ParetoChart.Series["Target Line"].LabelFormat = "0.#";  // format with one decimal and leading zero
        }

        /*
        * Method     : initializeDataGridView_PieChart()
        * Description: Initialize data and bind datagrid view to pie chart. This happens in a row changed event 
        * which is added in this method as well.
        */
        private void initializeDataGridView_PieChart()
        {
            // Create X and Y value members for pie chart series 
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

            // add a RowChanging event handler for the table 
            dataTable_Pie.RowChanged += DataTable_Pie_RowChanged;
        }

        /*
        * Method     : initializeDataGridView_LineChart()
        * Description: Initialize data and bind datagrid view to line chart. This happens in a row changed event 
        * which is added in this method as well.
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
        * Description: Initialize data and bind datagrid view to control chart. This happens in a row changed event 
        * which is added in this method as well. NOTES: Control lines are handles in numeric up controls.
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
        * Description: Initialize data and bind datagrid view to Pareto chart.
        */
        private void initializeDataGridView_ParetoChart()
        {
            // Set Pareto "column" chart 
            chart_ParetoChart.Series[0].XValueMember = "X";
            chart_ParetoChart.Series[0].YValueMembers = "Y";

            // Label chart area axis titles 
            chart_ParetoChart.ChartAreas[0].AxisX.Title = "Defect Categpry";
            chart_ParetoChart.ChartAreas[0].AxisY.Title = "Freq.";
            chart_ParetoChart.ChartAreas[0].AxisY2.Title = "Cumulative.%";

            // add column chart component 
            dataTable_Pareto.Columns.Add("X");
            dataTable_Pareto.Columns.Add("Y");

            dataGridView_ParetoChart.Anchor = AnchorStyles.Top;
            dataGridView_ParetoChart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // connect data grid view control to data 
            dataGridView_ParetoChart.DataSource = dataTable_Pareto;
            chart_ParetoChart.DataSource = dataTable_Pareto;

            // Bind data 
            chart_ParetoChart.DataBind();

            // Sort column series in descending order.
            chart_ParetoChart.DataManipulator.Sort(PointSortOrder.Descending, "Series1");

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
       */
        private void DataTable_Control_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            chart_ControlChart.DataBind();
        }

        /*
         * Method     : calculateParetoTargetLine()
         * Description:  Find total of all in points in column chart, derive cumulative frequency percentage, and over lay
         * Target Line series on column chart. This will create a Pareto chart. Based on example from Microsoft: 
         * https://code.msdn.microsoft.com/Samples-Environments-for-b01e9c61.
         */
        private void calculateParetoTargetLine()
        {
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

            // Need to clear points in chart series in orde to ensure Target Line does not format incorrectly. 
            chart_ParetoChart.Series["Target Line"].Points.Clear();

            // for each point in the source series find % of total and assign to series
            double percentage = 0.0;

            // for every point in series 1 in you have a point in series 2 
            foreach (DataPoint pt in chart_ParetoChart.Series[0].Points)
            {
                // Calculate cumulative frequency percentage: 
                percentage += (pt.YValues[0] / total * 100.0);
                chart_ParetoChart.Series["Target Line"].Points.Add(Math.Round(percentage, 2));
            }     
        }

        /*
        * Method     : DataTable_Pareto_RowChanged()
        * Description: Calculate Pareto target line, then bind data, then sort data descending. 
        */
        private void DataTable_Pareto_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            // Calculate cumulative frequency percentage for target line when user enters in values to 
            // data grid view.
            calculateParetoTargetLine();

            // Bind data from gridview to Pareto chart 
            chart_ParetoChart.DataBind();

            // Sort the data in the series to be by values in descending order. 
            // Note: This has to be done here and in initalization or column chart will not order correctly. 
            chart_ParetoChart.DataManipulator.Sort(PointSortOrder.Descending, "Series1");
        }


        /*
        * Method     : NumericUpDown_UpperControlLimit_ValueChanged
        * Description: Access numeric up down value inputed by user, then assign it's value to be an interval for stripline on 
        * control chart.  In this case it is the Upper Control Limit for control chart. 
        */
        private void NumericUpDown_UpperControlLimit_ValueChanged(object sender, EventArgs e)
        {
            decimal upperLineLimitValue = numericUpDown_UpperControlLimit.Value;
            chart_ControlChart.ChartAreas[0].AxisY.StripLines[2].IntervalOffset = decimal.ToDouble(upperLineLimitValue); 

        }

        /*
        * Method     : 
        * Description:  Access numeric up down value inputed by user, then assign it's value to be an interval for stripline on 
        * control chart. In this case it is the Lower Control Limit for control chart. 
        */
        private void NumericUpDown_LowerControlLimit_ValueChanged(object sender, EventArgs e)
        {
            decimal lowerLineLimitValue = numericUpDown_LowerControlLimit.Value;
            chart_ControlChart.ChartAreas[0].AxisY.StripLines[1].IntervalOffset = decimal.ToDouble(lowerLineLimitValue); 
        }

        /*
        * Method     : NumericUpDown_ControlLine_ValueChanged
        * Description: Access numeric up down value inputed by user, then assign it's value to be an interval for stripline on 
        * control chart.  In this case it is the Center Control for control chart. 
        */
        private void NumericUpDown_ControlLine_ValueChanged(object sender, EventArgs e)
        {
            decimal controlLineValue = numericUpDown_ControlLine.Value;
            chart_ControlChart.ChartAreas[0].AxisY.StripLines[0].IntervalOffset = decimal.ToDouble(controlLineValue); 
        }

        /*
        * Method     : button_ClearCharts_Click()
        * Description: Allow users to clear all charts in tabs with button. Functions by clearing series points in charts 
        * and binding them to respective charts again.
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
