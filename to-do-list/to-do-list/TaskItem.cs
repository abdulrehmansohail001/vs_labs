using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace to_do_list
{
    public class TaskItem
    {

        private int taskId;
        private string title;
        private bool isCompleted;
        private string description;
        private DateTime dueDate;
        public int TaskId {
            get { return taskId; }
            set { taskId = value; }
        }
       public string Title{
            get { return title; }
            set { title = value; }
        }
        public bool IsCompleted {            
            get { return isCompleted; }
            set { isCompleted = value; }
        }
        public string Description {
            get { return description; }
            set { description = value; }
        }

        public DateTime DueDate {
            get { return dueDate; }
            set { dueDate = value; }
        }

        public TaskItem(int taskId, string title, bool isCompleted, string description, DateTime dueDate)
        {
            TaskId = taskId;
            Title = title;
            IsCompleted = isCompleted;
            this.description = description;
            DueDate = dueDate;
        }
        public override string ToString()
        {
            string status = IsCompleted ? "(Done)" : "(Pending)";
            return $"{TaskId}. {Title} - {status}";
        }

    }
}
