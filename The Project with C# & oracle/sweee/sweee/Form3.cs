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
    public partial class Form3 : Form
    {
        string ordb = "Data Source =orcl;User Id=scott; Password=tiger;";
        OracleDataAdapter Adapter;
        OracleCommandBuilder builder;
        DataSet ds ;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
              string comm =" Select    H.hotel_name    , H.LOCATION,H.rating,   H.SPONSOR_NAME FROM HOTELS H WHERE H.RATING = :rate    ";
            //  string comm = "Select  H.hotel_name  from HOTELS H  WHERE  H.RATING=:rate ";
            Adapter = new OracleDataAdapter(comm, ordb);
                Adapter.SelectCommand.Parameters.Add("rate", textBox1.Text);

                ds = new DataSet();
                Adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

            

             
        }
        private void button2_Click(object sender, EventArgs e)
        {

            builder = new OracleCommandBuilder(Adapter);
            Adapter.Update(ds.Tables[0]);
            MessageBox.Show(" Data Successfully Updated ");
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }
}
