Feature: Task Management
    As a user
    I want to manage my tasks
    So that I can track my work efficiently

    Scenario: Adding a new task
        Given I have an empty task list
        When I add a task with name "Complete project documentation" and priority "High"
        Then the task should be added to the list
        And the task should have status "Pending"

    Scenario: Completing a task
        Given I have a task with name "Review code" and priority "Medium"
        When I complete the task
        Then the task status should be "Completed"

    Scenario: Tasks are ordered by priority
        Given I have the following tasks:
            | Name           | Priority |
            | Low priority   | Low      |
            | High priority  | High     |
            | Medium priority| Medium   |
        When I retrieve all tasks
        Then the tasks should be ordered with "High" priority first