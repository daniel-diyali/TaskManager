using NUnit.Framework;
using TaskManager;

namespace TaskManager.Tests
{
    [TestFixture]
    public class TaskServiceTests
    {
        private TaskService taskService;

        [SetUp]
        public void Setup()
        {
            taskService = new TaskService();
        }

        [Test]
        public void AddTask_ShouldAddTaskToCollection()
        {
            // Arrange
            var task = new TaskItem { Name = "Test Task", Priority = "High" };

            // Act
            taskService.AddTask(task);
            var tasks = taskService.GetAllTasks();

            // Assert
            Assert.AreEqual(1, tasks.Count);
            Assert.AreEqual("Test Task", tasks[0].Name);
            Assert.AreEqual("High", tasks[0].Priority);
        }

        [Test]
        public void CompleteTask_ShouldUpdateTaskStatus()
        {
            // Arrange
            var task = new TaskItem { Name = "Test Task", Priority = "Medium" };
            taskService.AddTask(task);
            var addedTask = taskService.GetAllTasks()[0];

            // Act
            taskService.CompleteTask(addedTask.Id);

            // Assert
            var completedTask = taskService.GetTaskById(addedTask.Id);
            Assert.AreEqual("Completed", completedTask.Status);
        }

        [Test]
        [TestCase("High", "Medium", "Low")]
        [TestCase("High", "Low", "Medium")]
        public void GetAllTasks_ShouldOrderByPriority(string first, string second, string third)
        {
            // Arrange
            taskService.AddTask(new TaskItem { Name = "Task 1", Priority = second });
            taskService.AddTask(new TaskItem { Name = "Task 2", Priority = third });
            taskService.AddTask(new TaskItem { Name = "Task 3", Priority = first });

            // Act
            var tasks = taskService.GetAllTasks();

            // Assert
            Assert.AreEqual("High", tasks[0].Priority);
        }

        [Test]
        public void GetTaskById_WithValidId_ShouldReturnTask()
        {
            // Arrange
            var task = new TaskItem { Name = "Test Task", Priority = "Low" };
            taskService.AddTask(task);
            var addedTask = taskService.GetAllTasks()[0];

            // Act
            var result = taskService.GetTaskById(addedTask.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Test Task", result.Name);
        }

        [Test]
        public void GetTaskById_WithInvalidId_ShouldReturnNull()
        {
            // Act
            var result = taskService.GetTaskById(999);

            // Assert
            Assert.IsNull(result);
        }
    }
}