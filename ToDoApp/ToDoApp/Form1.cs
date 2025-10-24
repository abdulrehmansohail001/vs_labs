using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using to_do_list;
namespace ToDoApp
{
    public partial class Form1 : Form
    {
        TaskManager manager = new TaskManager();
        int NextId = 1;
        public Form1()
        {
            InitializeComponent();
        }
        private void RefreshList()
        {
            listBox1.Items.Clear();
            List<TaskItem> tasks = manager.GetAllTasks();

            if (radioButton2.Checked)
                tasks = tasks.Where(t => t.IsCompleted).ToList();
            else if (radioButton3.Checked)
                tasks = tasks.Where(t => !t.IsCompleted).ToList();

            foreach (var task in tasks)
            {
                string status = task.IsCompleted ? "(Done)" : "(Pending)";
                listBox1.Items.Add($"{task.TaskId}. {task.Title} - {status}");
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;

            string selectedText = listBox1.SelectedItem.ToString();
            int selectedId = int.Parse(selectedText.Split('.')[0]);
            TaskItem task = manager.GetAllTasks().FirstOrDefault(t => t.TaskId == selectedId);
            if (task != null)
            {
                textBox1.Text = task.Title;
                textBox2.Text = task.Description;
                dateTimePicker1.Value = task.DueDate;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TaskItem task = new TaskItem(NextId++, textBox1.Text, false, textBox2.Text, dateTimePicker1.Value);
            manager.AddTask(task);
            RefreshList();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a task to update.");
                return;
            }

            string selectedText = listBox1.SelectedItem.ToString();
            int selectedId = int.Parse(selectedText.Split('.')[0]);

            TaskItem existingTask = manager.GetAllTasks().FirstOrDefault(t => t.TaskId == selectedId);
            if (existingTask == null)
            {
                MessageBox.Show("Task not found!");
                return;
            }

           
            manager.UpdateTask(
                selectedId,
                textBox1.Text,
                existingTask.IsCompleted, 
                textBox2.Text,
                dateTimePicker1.Value
            );

            RefreshList();
            MessageBox.Show("Task updated successfully!");
   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a task to delete.");
                return;
            }
            string selectedText = listBox1.SelectedItem.ToString();
            int selectedId = int.Parse(selectedText.Split('.')[0]);
            manager.RemoveTask(selectedId);
            RefreshList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Select a task to mark as completed.");
                return;
            }

            string selectedText = listBox1.SelectedItem.ToString();
            int selectedId = int.Parse(selectedText.Split('.')[0]);
            manager.MarkTaskAsCompleted(selectedId);
            RefreshList();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

    }
}
