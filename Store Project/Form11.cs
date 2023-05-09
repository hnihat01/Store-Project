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
    public partial class Form11 : Form
    {
        private static MySqlConnection con;
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;
        SqlDataAdapter adapt;
        DataTable dataTable = new DataTable();
        SqlCommandBuilder scb;
        public Form11()
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

        private void Form11_Load(object sender, EventArgs e)
        {


            DateTimePicker today = new DateTimePicker();
           // today.Value.ToString("yyyy-MM-dd");
                today.Value = DateTime.Now;
            DateTimePicker sevenDaysEarlier = new DateTimePicker();
          //  sevenDaysEarlier.Value.ToString("yyyy-MM-dd");
            sevenDaysEarlier.Value.AddDays(-7);
            string seven = sevenDaysEarlier.Value.ToString("yyyy-MM-dd");
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
            string Query = "select  customer.Customer_Name, customer.Number, customer.Email, product.Brand, product.Price, sales.Date_of_payment from sales "
                 + "JOIN customer ON customer.idCustomer=sales.idCustomer "
                 + "JOIN product ON product.idproduct=sales.idproduct " +
         //        "WHERE sales.Date_of_payment='22-12-10';";
                  "WHERE  sales.Date_of_payment<= '" + seven + "' " +
                 "ORDER BY sales.Date_of_payment;";
            MySqlCommand sqlCommand = new MySqlCommand(Query, mySql);
            mySql.Open();
            MySqlDataAdapter sdr = new MySqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            mySql.Close();

            /*
            try
            {


                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = "127.0.0.1";
                builder.UserID = "root";
                builder.Password = "5505667Sa";
                builder.Database = "store";
                builder.SslMode = MySqlSslMode.None;
                con = new MySqlConnection(builder.ToString());
                //This is my update query in which i am taking input from the user through windows forms and update the record.
                string Query = "select  customer.Customer_Name, customer.Number, customer.Email, product.Brand, product.Price, sales.Date_of_payment from sales "
                    + "JOIN customer ON customer.idCustomer=sales.idCustomer "
                    +"JOIN product ON product.idproduct=sales.idproduct "
                    + "WHERE  sales.Date_of_payment<= "+seven+" " +
                    "ORDER BY sales.Date_of_payment;";
                //This is  MySqlConnection here i have created the object and pass my connection string.
            //    MySqlConnection MyConn2 = new MySqlConnection(con);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, con);
                MySqlDataReader MyReader2;
                con.Open();
                MyReader2 = MyCommand2.ExecuteReader();
              //  MessageBox.Show("Data Updated");
                while (MyReader2.Read())
                {
                }
                con.Close();//Connection closed here
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            */
        }

        private DataTable GetProductList()
        {
            DataTable product = new DataTable();

            return product;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DateTimePicker today = new DateTimePicker();
              today.Value = DateTime.Now;
           //  today.Value.ToString("yyyy-MM-dd");
       
            DateTimePicker sevenDaysEarlier = new DateTimePicker();
            sevenDaysEarlier.Value.AddDays(-7);
          //  sevenDaysEarlier.Value.ToString("yyyy-MM-dd");
         
            try
            {
                string sql = "select  customer.Customer_Name, customer.Number, customer.Email, product.Brand, product.Price, sales.Date_of_payment from sales "
                        + "JOIN customer ON customer.idCustomer=sales.idCustomer "
                        + "JOIN product ON product.idproduct=sales.idproduct "
                        + "WHERE  sales.Date_of_payment>= TO_DATE('"+ sevenDaysEarlier + "','YYYY-MM-DD')   and sales.Date_of_payment<= " +today+
                        ";";

                con = new MySqlConnection(Properties.Settings.Default.ConnectionString);

                cmd = new MySqlCommand(sql, con);

                con.Open();

                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dataTable);
                }

                dataGridView1.DataSource = dataTable;
                dataGridView1.DataMember = dataTable.TableName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con != null) con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f3 = new Form2();
            f3.Show();
            this.Hide();
        }
    }
}
