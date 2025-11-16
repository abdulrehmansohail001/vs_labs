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
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-V9NA7TM\\SQLEXPRESS;Initial Catalog=dB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" ||
       textBox3.Text == "" || comboBox1.Text == "" ||
       comboBox2.Text == "")
            {
                MessageBox.Show("Please fill all fields!");
                return;
            }

            try
            {
                con.Open();

                string checkQuery = "SELECT COUNT(*) FROM Students WHERE RegId = '" + textBox1.Text + "'";
                SqlCommand checkCmd = new SqlCommand(checkQuery, con);

                int exists = (int)checkCmd.ExecuteScalar();
                if (exists == 0)
                {
                    MessageBox.Show("RegId not found!");
                    return;
                }
                string query = "UPDATE Students SET " +
                               "Name = '" + textBox2.Text + "', " +
                               "Address = '" + textBox3.Text + "', " +
                               "MatricGrade = '" + comboBox1.Text + "', " +
                               "InterGrade = '" + comboBox2.Text + "' " +
                               "WHERE RegId = '" + textBox1.Text + "'";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Record Updated Successfully!");
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

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
        }
    }
}
