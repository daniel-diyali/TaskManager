# Task Manager Application

A C# WinForms application demonstrating professional software development practices including automated testing, CI/CD, and source control management.

## Features

- ✅ **C# WinForms Development**: Modern Windows desktop application
- ✅ **Task Management**: Add, complete, and prioritize tasks
- ✅ **Automated Testing**: NUnit unit tests and SpecFlow BDD tests
- ✅ **Source Control**: Git version control with GitHub integration
- ✅ **CI/CD Pipeline**: GitHub Actions for automated builds and testing
- ✅ **Requirements Documentation**: Formal requirements gathering and documentation

## Technologies Used

- **Framework**: .NET 6.0
- **UI**: Windows Forms
- **Testing**: NUnit, SpecFlow (Gherkin)
- **CI/CD**: GitHub Actions
- **Source Control**: Git

## Project Structure

```
TaskManager/
├── src/
│   ├── Program.cs              # Main application and WinForms UI
│   └── TaskManager.csproj      # Project file
├── tests/
│   ├── Features/
│   │   └── TaskManagement.feature    # Gherkin BDD tests
│   ├── StepDefinitions/
│   │   └── TaskManagementSteps.cs    # SpecFlow step definitions
│   ├── TaskServiceTests.cs           # NUnit unit tests
│   └── TaskManager.Tests.csproj      # Test project file
├── docs/
│   └── REQUIREMENTS.md               # Requirements documentation
├── .github/workflows/
│   └── ci.yml                       # GitHub Actions CI pipeline
└── .gitignore                       # Git ignore rules
```

## Getting Started

### Prerequisites
- .NET 6.0 SDK
- Windows 10/11
- Visual Studio 2022 or VS Code

### Running the Application
```bash
cd src
dotnet run
```

### Running Tests
```bash
# Run all tests
dotnet test

# Run only NUnit tests
dotnet test --filter "TestCategory!=SpecFlow"

# Run only SpecFlow tests
dotnet test --filter "TestCategory=SpecFlow"
```

## Skills Demonstrated

### 1. C# and WinForms Development
- Modern C# syntax with .NET 6.0
- Windows Forms UI with data binding
- Event-driven programming
- Object-oriented design patterns

### 2. Automated Testing
- **NUnit**: Unit testing with test cases and parameterized tests
- **SpecFlow/Gherkin**: Behavior-driven development (BDD) testing
- Test coverage for core business logic
- Test-driven development practices

### 3. Source Control Management
- Git version control
- GitHub repository hosting
- Proper .gitignore configuration
- Commit history and branching strategies

### 4. Requirements Gathering
- Formal requirements documentation
- User story mapping
- Acceptance criteria definition
- Technical requirements specification

### 5. Continuous Integration
- GitHub Actions workflow
- Automated build and test execution
- Test result reporting
- Cross-platform CI pipeline

## CI/CD Pipeline

The project includes a GitHub Actions workflow that:
- Triggers on push to main/develop branches
- Restores NuGet packages
- Builds the solution
- Runs all automated tests
- Reports test results

## Testing Strategy

### Unit Tests (NUnit)
- Service layer testing
- Business logic validation
- Edge case handling
- Parameterized test scenarios

### BDD Tests (SpecFlow)
- User behavior scenarios
- Gherkin feature files
- Step definition implementation
- End-to-end workflow testing

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests for new functionality
5. Ensure all tests pass
6. Submit a pull request

## License

This project is for demonstration purposes and portfolio development.