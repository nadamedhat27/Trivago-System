using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using sweee;

namespace SWE
{
    public partial class Form1 : Form
    {
        string ordb = "Data Source =ORCL;User Id=scott; Password=tiger;";
        OracleConnection conn;
        public Form1()
        {
             
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             
            conn = new OracleConnection(ordb);

        }



        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Dispose();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select EMAIL from USERS where NAME=:name";
            cmd.Parameters.Add("name", textBox1.Text.ToString());


            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            dr.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into   USERS values ( :name,:Email,:Password,:natio)";
            cmd.Parameters.Add("name", textBox2.Text.ToString());
            cmd.Parameters.Add("Email", textBox3.Text.ToString());
            cmd.Parameters.Add("Password", textBox4.Text.ToString());
            cmd.Parameters.Add("natio", textBox5.Text.ToString());
            cmd.CommandType = CommandType.Text;
            int r = cmd.ExecuteNonQuery();

            if (r != -1)
            {
                MessageBox.Show("SignUp successfully");
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();


        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
        }
    }
    }
 