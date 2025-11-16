using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        SqlConnection con= new SqlConnection("Data Source=DESKTOP-V9NA7TM\\SQLEXPRESS;Initial Catalog=dB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"); 
        public Form3()
        {
            InitializeComponent();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void view_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string query = "SELECT * FROM Students";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();  
            form5.Show();
        }
    }
}
