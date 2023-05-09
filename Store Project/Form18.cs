using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace Store_Project
{
    public partial class Form18 : Form
    {
        private static MySqlConnection con;
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;
        SqlDataAdapter adapt;
        DataTable dataTable = new DataTable();
        SqlCommandBuilder scb;
        MySqlDataReader mdr;
        MySqlDataReader mdr1;
        public Form18()
        {
            InitializeComponent();
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "127.0.0.1";
            builder.UserID = "root";
            builder.Password = "123456";
            builder.Database = "store";
            builder.SslMode = MySqlSslMode.None;
            con = new MySqlConnection(builder.ToString());
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "127.0.0.1";
            builder.UserID = "root";
            builder.Password = "123456";
            builder.Database = "store";
            builder.SslMode = MySqlSslMode.None;
            con = new MySqlConnection(builder.ToString());

            dataGridView1.DataSource = GetProductList();
            string mcon = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            MySqlConnection mySql = new MySqlConnection(mcon);
            string Query = "Select product.Brand, sales.IsPayed, sales.Date_of_payment from product join sales On sales.idproduct=product.idproduct WHERE sales.IsPayed='payed' and sales.Date_of_payment>='2022-12-08' and sales.Date_of_order<='2022-12-11';";
            MySqlCommand sqlCommand = new MySqlCommand(Query, mySql);
            mySql.Open();
            MySqlDataAdapter sdr = new MySqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            mdr = sqlCommand.ExecuteReader();
            while (mdr.Read())
            {
                int index= chart1.Series["Name"].Points.AddXY(mdr.GetString("isPayed"),"10");
                chart1.Series["Name"].Points[index].Label = mdr.GetString("Brand");
                //    chart1.Series["Name"].Points[index].Label = mdr.GetString("Brand")+ ":" + mdr.GetString("isPayed");
                //  this.chart1.Series["Name"].CustomProperties= "PieLabelStyle=Outside";
                //  this.chart1.Series["Name"].Label= "#LEGENDTEXT" + "#PERCENT";
                //  this.chart1.Series["Name"].Points.AddXY("sales.IsPayed", mdr[1]);,mdr.GetString("isPayed")
                //this.chart1.Series["Name"].ChartType=(

            }
            //   var chartArea = new ChartArea();
            //   chart1.ChartAreas.Add(chartArea);

            chart1.ChartAreas.Add("50, 50");
            mdr.Close();
            mySql.Close();



        }

        private DataTable GetProductList()
        {
            DataTable product = new DataTable();

            return product;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }
    }
    
}
