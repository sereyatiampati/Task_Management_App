using Task_Management_App.Connections;
using Task_Management_App.Controllers;

DbConnection newConnection = new DbConnection();

AuthController newController = new AuthController();
newController.LandingPage();

// ProjectController newProject = new ProjectController();
// newProject.UpdateProject();
// TaskControllers newTaskController = new TaskControllers();
// newTaskController.GetAllTasks();
