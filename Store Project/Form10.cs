﻿using System;
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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //This is my connection string i have assigned the database file address path
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=123456";
                //This is my update query in which i am taking input from the user through windows forms and update the record.
                string Query = "update store.sales set idSales='" + int.Parse(this.textBox1.Text) + "', idCustomer='" + int.Parse(this.textBox2.Text) + "', idproduct='" + int.Parse(this.textBox3.Text) + "', Date_of_order='" + this.dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "',  Date_of_payment='" + this.dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "', isPayed='" + this.textBox4.Text +"', isReturned='" + this.textBox7.Text+ "' where idSales='" + int.Parse(this.textBox6.Text) + "';";
                //This is  MySqlConnection here i have created the object and pass my connection string.
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Data Updated");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();//Connection closed here
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Form9 f9 = new Form9();
            f9.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }
    }
}
