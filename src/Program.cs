using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class MainForm : Form
    {
        private TaskService taskService;
        private DataGridView taskGrid;
        private TextBox taskNameBox;
        private ComboBox priorityBox;
        private Button addButton;
        private Button completeButton;

        public MainForm()
        {
            InitializeComponent();
            taskService = new TaskService();
            LoadTasks();
        }

        private void InitializeComponent()
        {
            this.Text = "Task Manager";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Task input controls
            var inputPanel = new Panel { Dock = DockStyle.Top, Height = 60 };
            
            taskNameBox = new TextBox { Location = new Point(10, 20), Width = 200 };
            priorityBox = new ComboBox { 
                Location = new Point(220, 20), 
                Width = 100,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            priorityBox.Items.AddRange(new[] { "Low", "Medium", "High" });
            priorityBox.SelectedIndex = 1;

            addButton = new Button { 
                Text = "Add Task", 
                Location = new Point(330, 18), 
                Width = 80 
            };
            addButton.Click += AddTask_Click;

            completeButton = new Button { 
                Text = "Complete", 
                Location = new Point(420, 18), 
                Width = 80 
            };
            completeButton.Click += CompleteTask_Click;

            inputPanel.Controls.AddRange(new Control[] { taskNameBox, priorityBox, addButton, completeButton });

            // Task grid
            taskGrid = new DataGridView {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };

            taskGrid.Columns.Add(new DataGridViewTextBoxColumn { 
                DataPropertyName = "Id", 
                HeaderText = "ID", 
                Width = 50 
            });
            taskGrid.Columns.Add(new DataGridViewTextBoxColumn { 
                DataPropertyName = "Name", 
                HeaderText = "Task", 
                Width = 300 
            });
            taskGrid.Columns.Add(new DataGridViewTextBoxColumn { 
                DataPropertyName = "Priority", 
                HeaderText = "Priority", 
                Width = 100 
            });
            taskGrid.Columns.Add(new DataGridViewTextBoxColumn { 
                DataPropertyName = "Status", 
                HeaderText = "Status", 
                Width = 100 
            });

            this.Controls.Add(taskGrid);
            this.Controls.Add(inputPanel);
        }

        private void AddTask_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(taskNameBox.Text)) return;

            var task = new TaskItem
            {
                Name = taskNameBox.Text,
                Priority = priorityBox.SelectedItem.ToString(),
                Status = "Pending"
            };

            taskService.AddTask(task);
            taskNameBox.Clear();
            LoadTasks();
        }

        private void CompleteTask_Click(object sender, EventArgs e)
        {
            if (taskGrid.SelectedRows.Count == 0) return;

            var taskId = (int)taskGrid.SelectedRows[0].Cells["Id"].Value;
            taskService.CompleteTask(taskId);
            LoadTasks();
        }

        private void LoadTasks()
        {
            taskGrid.DataSource = taskService.GetAllTasks();
        }
    }

    public class TaskItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }

    public class TaskService
    {
        private List<TaskItem> tasks = new List<TaskItem>();
        private int nextId = 1;

        public void AddTask(TaskItem task)
        {
            task.Id = nextId++;
            tasks.Add(task);
        }

        public List<TaskItem> GetAllTasks()
        {
            return tasks.OrderByDescending(t => t.Priority == "High")
                       .ThenByDescending(t => t.Priority == "Medium")
                       .ToList();
        }

        public void CompleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
                task.Status = "Completed";
        }

        public TaskItem GetTaskById(int id)
        {
            return tasks.FirstOrDefault(t => t.Id == id);
        }
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}