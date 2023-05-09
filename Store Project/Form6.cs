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
namespace Store_Project
{
    public partial class Form6 : Form
    {
        private static MySqlConnection con;
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = "127.0.0.1";
                builder.UserID = "root";
                builder.Password = "123456";
                builder.Database = "store";
                builder.SslMode = MySqlSslMode.None;
                con = new MySqlConnection(builder.ToString());
                string query = "INSERT INTO sales (idCustomer, idproduct, Date_of_order, Date_of_payment,IsPayed,IsReturned) VALUES('" + int.Parse(this.textBox2.Text) + "','" + int.Parse(this.textBox3.Text) + "','" + this.dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "','" + this.dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "','" + this.textBox4.Text + "','" + this.textBox7.Text + "');";


                //  string query = "INSERT INTO customer (Customer_Name,Personal_ID, Sity, Adress,Number,Email) VALUES (@Custmer_Name,@Personal_ID, @Sity, @Adress,@Number,@Email)";
                MySqlCommand cmd = new MySqlCommand(query, con);


                int cid = int.Parse(this.textBox2.Text);
                int pid = int.Parse(this.textBox3.Text);
                String date1 = this.dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
                String date2 = this.dateTimePicker2.Value.Date.ToString("yyyy-MM-dd");
                String payed = this.textBox4.Text;
                String returned = this.textBox7.Text;


                con.Open();
                cmd.Parameters.Add(new MySqlParameter("@idCustomer", cid));
                cmd.Parameters.Add(new MySqlParameter("@idproduct", pid));
                cmd.Parameters.Add(new MySqlParameter("@Date_of_order", date1));
                cmd.Parameters.Add(new MySqlParameter("@Date_of_payment", date2));
                cmd.Parameters.Add(new MySqlParameter("@IsPayed", payed));
                cmd.Parameters.Add(new MySqlParameter("@IsReturned", returned));


                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            MessageBox.Show("Data Stored Successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
            this.Hide();
        }
    }
}
