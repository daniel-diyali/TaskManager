using NUnit.Framework;
using TechTalk.SpecFlow;
using TaskManager;

namespace TaskManager.Tests.StepDefinitions
{
    [Binding]
    public class TaskManagementSteps
    {
        private TaskService taskService;
        private TaskItem lastAddedTask;
        private List<TaskItem> retrievedTasks;

        [BeforeScenario]
        public void Setup()
        {
            taskService = new TaskService();
        }

        [Given(@"I have an empty task list")]
        public void GivenIHaveAnEmptyTaskList()
        {
            // Task service starts empty by default
        }

        [Given(@"I have a task with name ""(.*)"" and priority ""(.*)""")]
        public void GivenIHaveATaskWithNameAndPriority(string name, string priority)
        {
            var task = new TaskItem { Name = name, Priority = priority };
            taskService.AddTask(task);
            lastAddedTask = taskService.GetAllTasks().Last();
        }

        [Given(@"I have the following tasks:")]
        public void GivenIHaveTheFollowingTasks(Table table)
        {
            foreach (var row in table.Rows)
            {
                var task = new TaskItem 
                { 
                    Name = row["Name"], 
                    Priority = row["Priority"] 
                };
                taskService.AddTask(task);
            }
        }

        [When(@"I add a task with name ""(.*)"" and priority ""(.*)""")]
        public void WhenIAddATaskWithNameAndPriority(string name, string priority)
        {
            var task = new TaskItem { Name = name, Priority = priority };
            taskService.AddTask(task);
            lastAddedTask = taskService.GetAllTasks().Last();
        }

        [When(@"I complete the task")]
        public void WhenICompleteTheTask()
        {
            taskService.CompleteTask(lastAddedTask.Id);
        }

        [When(@"I retrieve all tasks")]
        public void WhenIRetrieveAllTasks()
        {
            retrievedTasks = taskService.GetAllTasks();
        }

        [Then(@"the task should be added to the list")]
        public void ThenTheTaskShouldBeAddedToTheList()
        {
            var tasks = taskService.GetAllTasks();
            Assert.IsTrue(tasks.Any(t => t.Name == lastAddedTask.Name));
        }

        [Then(@"the task should have status ""(.*)""")]
        public void ThenTheTaskShouldHaveStatus(string expectedStatus)
        {
            Assert.AreEqual(expectedStatus, lastAddedTask.Status);
        }

        [Then(@"the task status should be ""(.*)""")]
        public void ThenTheTaskStatusShouldBe(string expectedStatus)
        {
            var updatedTask = taskService.GetTaskById(lastAddedTask.Id);
            Assert.AreEqual(expectedStatus, updatedTask.Status);
        }

        [Then(@"the tasks should be ordered with ""(.*)"" priority first")]
        public void ThenTheTasksShouldBeOrderedWithPriorityFirst(string priority)
        {
            Assert.AreEqual(priority, retrievedTasks.First().Priority);
        }
    }
}