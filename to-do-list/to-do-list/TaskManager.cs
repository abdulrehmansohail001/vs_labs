using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace to_do_list
{
    public class TaskManager
    {
        private List<TaskItem> tasks;
        public TaskManager()
        {
            tasks = new List<TaskItem>();
        }
        public void AddTask(TaskItem task)
        {
            tasks.Add(task);
        } 
        public void UpdateTask(int taskId, string title, bool isCompleted, string description, DateTime dueDate)
        {
            var task = tasks.FirstOrDefault(t => t.TaskId == taskId);
            if (task != null)
            {
                task.Title = title;
                task.IsCompleted = isCompleted;
                task.Description = description;
                task.DueDate = dueDate;
            }
        }
        public void RemoveTask(int taskId)
        {
            var task = tasks.FirstOrDefault(t => t.TaskId == taskId);
            if (task != null)
            {
                tasks.Remove(task);
            }
        }
        public List<TaskItem> GetAllTasks()
        {
                return tasks;
        }
        public void MarkTaskAsCompleted(int taskId)
        {
            var task = tasks.FirstOrDefault(t => t.TaskId == taskId);
            if (task != null)
            {
                task.IsCompleted = true;
            }
        }

    }
}
