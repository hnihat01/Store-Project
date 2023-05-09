using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Project
{
    public partial class Form1 : Form
    {
        private static MySqlConnection con;
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;
        public Form1()
        {
            
            InitializeComponent();
            
    }

        private void label2_Click(object sender, EventArgs e)
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
            

            string query = "INSERT INTO product (Brand,Description,Price,Expire_date,Count) VALUES (@Brand,@Description,@Price,@Expire_date,@Count)";
            MySqlCommand cmd = new MySqlCommand(query, con);

            String Brand = this.textBox1.Text;
            String DES = this.textBox2.Text;
            String date = this.dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
            int count = Int32.Parse(this.textBox5.Text);

            con.Open();
            cmd.Parameters.Add(new MySqlParameter("@Brand", Brand));
            cmd.Parameters.Add(new MySqlParameter("@Description", DES));
            cmd.Parameters.Add(new MySqlParameter("@Price", MySqlDbType.Float)).Value = float.Parse(this.textBox3.Text);
            cmd.Parameters.Add(new MySqlParameter("@Expire_date", date));
            cmd.Parameters.Add(new MySqlParameter("@Count", count));


            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        MessageBox.Show("Data Stored Successfully");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
        
    }
    
