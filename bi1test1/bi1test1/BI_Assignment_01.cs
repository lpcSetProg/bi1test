/*
* FILE : .cs
* PROJECT : PROG3240 - Business Intelligence - Assignment 1
* PROGRAMMERS : Lev Cocarell
* FIRST VERSION : 2018-09-12
* DESCRIPTION :
* This file contains the source code for the 
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        * Method     : 
        * Description: 
        * Parameters : N/A
        * Returns    : N?A
        */
        public BusinessIntelligenceCharts()
        {
            InitializeComponent();
            InitializeCharts();
            InitializeDataGrids();
        }

        /*
        * Method     : 
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
        * Method     : 
        * Description: 
        * Parameters : N/A
        * Returns    : N?A
        */
        private void InitializeDataGrids()
        {
            initializeDataGridView_PieChart();
            initializeDataGridView_LineChart();
            initializeDataGridView_ParetoChart();
        }

        /*
        * Method     : 
        * Description: 
        * Parameters : N/A
        * Returns    : N?A
        */
        private void InitializePieChart()
        {
            chart_PieChart.Titles.Add("Pie Chart");
            chart_PieChart.Titles[0].Alignment = ContentAlignment.MiddleCenter;
            //chart_PieChart.Titles.Add("Second");
            chart_PieChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
        }

        /*
        * Method     : InitializeControlChart
        * Description: 
        * Parameters : N/A
        * Returns    : N?A
        */
        private void InitializeControlChart()
        {
           // https://www.codeproject.com/Articles/796278/Control-Chart-Using-Net
        }

        /*
        * Method     : InitializeParetoChart
        * Description: 
        * Parameters : N/A
        * Returns    : N?A
        */
        private void InitializeParetoChart()
        {
            //https://stackoverflow.com/questions/30662584/percent-value-in-y-axis-of-column-chart-microsoft-chart-control
            //https://www.codeproject.com/Articles/802845/Pareto-Chart-Csharp

            chart_ParetoChart.Titles.Add("Pareto Chart");
            //chart_LineChart.Titles.Add("Second");
            chart_ParetoChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            // add series
       
        }

        /*
    
        /*
        * Method     : InitializeLineChart
        * Description: 
        * Parameters : N/A
        * Returns    : N?A
        */
        private void InitializeLineChart()
        {
            chart_LineChart.Titles.Add("Line Chart");
            //chart_LineChart.Titles.Add("Second");
            chart_LineChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }

        /*
        * Method     : initializeDataGridView_PieChart
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
        * Method     : initializeDataGridView_LineChart
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

            // name of c
            chart_LineChart.DataBind();
            //// bind chart view to datasource as well
            //!!!! ondatachange event handler for row changed data table; 
            ////dataGridView_LineChart.DataSource = dt.AutoGenerateColumns = false;
            //dataGridView_LineChart.AutoSize = true;
            //dataGridView_LineChart.DataSource = bindingSource1;
            dataTable_Line.RowChanged += Dt_RowChanged;

          
        }

      

        /*
        * Method     : initializeDataGridView_ParetoChart
        * Description: 
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

           // dataTable_Pareto.

        }

     


        // Events 
        /*
        * Method     : 
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
        * Method     : 
        * Description: 
        * Parameters : N/A
        * Returns    : N?A
        */
        private void DataTable_Pie_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            chart_PieChart.DataBind();
        }

        /*
        * Method     : 
        * Description: 
        * Parameters : N/A
        * Returns    : N?A
        */
        private void button_ClearCharts_Click(object sender, EventArgs e)
        {
            foreach (var series in chart_LineChart.Series)
            {
                series.Points.Clear();
                //while (chart1.Series.Count > 0) { chart1.Series.RemoveAt(0); }
            }

        }
    }
}
