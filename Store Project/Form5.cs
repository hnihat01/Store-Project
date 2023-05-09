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
    public partial class Form5 : Form
    {
        private static MySqlConnection con;
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;
        public Form5()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {



            try {           
                
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "127.0.0.1";
            builder.UserID = "root";
            builder.Password = "123456";
            builder.Database = "store";
            builder.SslMode = MySqlSslMode.None;
            con = new MySqlConnection(builder.ToString());
            string query = "INSERT INTO customer (Customer_Name,Personal_ID, Sity, Adress,Number,Email) VALUES('" + this.textBox2.Text + "','" + Int32.Parse(this.textBox3.Text) + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "','" + this.textBox4.Text + "','" + this.textBox7.Text + "');";


            //  string query = "INSERT INTO customer (Customer_Name,Personal_ID, Sity, Adress,Number,Email) VALUES (@Custmer_Name,@Personal_ID, @Sity, @Adress,@Number,@Email)";
            MySqlCommand cmd = new MySqlCommand(query, con);

            string customer = this.textBox2.Text;
            int pid = Int32.Parse(this.textBox3.Text);
            string city = this.textBox5.Text;
            string adress = this.textBox6.Text;
            string num = this.textBox4.Text;
            string email = this.textBox7.Text;


            con.Open();
            cmd.Parameters.Add(new MySqlParameter("@Customer_Name", customer));
            cmd.Parameters.Add(new MySqlParameter("@Personal_ID", pid));
            cmd.Parameters.Add(new MySqlParameter("@Sity", city));
            cmd.Parameters.Add(new MySqlParameter("@Adress", adress));
            cmd.Parameters.Add(new MySqlParameter("@Number", num));
            cmd.Parameters.Add(new MySqlParameter("@Email", email));


            cmd.ExecuteNonQuery();
            con.Close();
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

    MessageBox.Show("Data Stored Successfully");
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
            this.Hide();
        }
    }
         
    } 
  


