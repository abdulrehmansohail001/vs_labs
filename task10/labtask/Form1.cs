using System.Xml.Linq;

namespace labtask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            EmployeeContext db = new EmployeeContext();
            dataGridView1.DataSource = db.Employees.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Name cannot be empty");
                return;
            }

            if (textBox4.Text.Length != 13)
            {
                MessageBox.Show("CNIC must be 13 digits");
                return;
            }

            if (!decimal.TryParse(textBox6.Text, out decimal salary))
            {
                MessageBox.Show("Salary must be numeric");
                return;
            }

            Employee emp = new Employee
            {
                Name = textBox2.Text,
                FatherName = textBox3.Text,
                CNIC = textBox4.Text,
                Designation = textBox5.Text,
                Salary = salary,
                Department = comboBox1.Text,
                HireDate = dateTimePicker1.Value
            };

            EmployeeContext db = new EmployeeContext();
            db.Employees.Add(emp);
            db.SaveChanges();

            MessageBox.Show("Record Inserted Successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int empId))
            {
                MessageBox.Show("Enter valid EmpId");
                return;
            }

            using (EmployeeContext db = new EmployeeContext())
            {
                Employee emp = db.Employees.Find(empId);

                if (emp == null)
                {
                    MessageBox.Show("Employee not found.");
                    return;
                }

                db.Employees.Remove(emp);
                db.SaveChanges();
            }

            MessageBox.Show("Record Deleted Successfully");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int empId))
            {
                MessageBox.Show("Enter valid EmpId");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Name cannot be empty");
                return;
            }

            if (textBox4.Text.Length != 13)
            {
                MessageBox.Show("CNIC must be 13 digits");
                return;
            }

            if (!decimal.TryParse(textBox6.Text, out decimal salary))
            {
                MessageBox.Show("Salary must be numeric");
                return;
            }

            using (EmployeeContext db = new EmployeeContext())
            {
                Employee emp = db.Employees.Find(empId);

                if (emp == null)
                {
                    MessageBox.Show("Employee not found.");
                    return;
                }
                emp.Name = textBox2.Text;
                emp.FatherName = textBox3.Text;
                emp.CNIC = textBox4.Text;
                emp.Designation = textBox5.Text;
                emp.Salary = salary;
                emp.Department = comboBox1.Text;
                emp.HireDate = dateTimePicker1.Value;

                db.SaveChanges();
            }

            MessageBox.Show("Record Updated Successfully");
        }
    }
}
