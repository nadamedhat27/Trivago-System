using SWE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace sweee
{
    public partial class Form2 : Form
    {
        string ordb = "Data Source =ORCL;User Id=scott; Password=tiger;";
        OracleConnection conn;
        public Form2()
            
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Dispose();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
             
            cmd.CommandText = "RETURN_RATING";
            cmd.Parameters.Add("hname", textBox1.Text.ToString());
            cmd.Parameters.Add("rating", OracleDbType.Int16, ParameterDirection.Output);



            cmd.CommandType = CommandType.StoredProcedure;
              cmd.ExecuteNonQuery();
            label2.Text = cmd.Parameters["rating"].Value.ToString();            


             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SITESHOTELS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("siteName", textBox2.Text.ToString() );
            cmd.Parameters.Add("Hotel_name", OracleDbType.RefCursor, ParameterDirection.Output);



            
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            dr.Close();
             

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
