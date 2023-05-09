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
namespace Store_Project
{
    public partial class Form17 : Form
    {

        private static MySqlConnection con;
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;
        SqlDataAdapter adapt;
        DataTable dataTable = new DataTable();
        SqlCommandBuilder scb;
        public static List<int> list = new List<int>();
        MySqlDataReader mdr;
        MySqlDataReader mdr1;
        public Form17()
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

        private void Form17_Load(object sender, EventArgs e)
        {

            string date = "unpaid";
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
            string Query = "select  sales.idCustomer from sales; ";
            MySqlCommand sqlCommand = new MySqlCommand(Query, mySql);
            mySql.Open();
            mdr = sqlCommand.ExecuteReader();
            while (mdr.Read())
            {

                list.Add(Int32.Parse(mdr["idCustomer"].ToString()));

            }

            mySql.Close();



            IEnumerable<int> duplicates = list.GroupBy(x => x)
                                        .Where(g => g.Count() > 2)
                                        .Select(x => x.Key);


            string d = string.Join(", ", duplicates.ToList());
            List<int> list1 = duplicates.ToList();
            mySql.Close();



            string Query1 = "select  sales.idCustomer, customer.Customer_Name,customer.Number, customer.Email from sales " +
                "JOIN customer On customer.idCustomer=sales.idCustomer " +
                "WHERE sales.idCustomer=" + list1[0] + ";";
            MySqlCommand sqlCommand1 = new MySqlCommand(Query1, mySql);
            mySql.Open();
            MySqlDataAdapter sdr = new MySqlDataAdapter(sqlCommand1);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            MySqlCommand command1 = new MySqlCommand(Query1, con);
            mdr1 = sqlCommand1.ExecuteReader();

            mySql.Close();
        }
        private DataTable GetProductList()
        {
            DataTable product = new DataTable();

            return product;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }
    }
}
