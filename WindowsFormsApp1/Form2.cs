using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        SqlConnection con= new SqlConnection("Data Source=DESKTOP-V9NA7TM\\SQLEXPRESS;Initial Catalog=dB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        public Form2()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" ||
       comboBox1.Text == "" || comboBox2.Text == "" || textBox4.Text == "" ||
       comboBox3.Text == "" || comboBox4.Text == "")
            {
                MessageBox.Show("Please fill all fields!");
                return;
            }

            try
            {
                con.Open();

                string query = "INSERT INTO Students (Name, FatherName, CNIC, Gender, DOB, Address, DegreeProgram, MatricGrade, InterGrade) " +
                               "VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" +
                               comboBox1.Text + "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', '" + textBox4.Text +
                               "', '" + comboBox2.Text + "', '" + comboBox3.Text + "', '" + comboBox4.Text + "')";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Student Added Successfully!");
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

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }
    }
}
