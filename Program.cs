using Task_Management_App.Connections;
using Task_Management_App.Controllers;

DbConnection newConnection = new DbConnection();

// UserController newController = new UserController();
// newController.LandingPage();

ProjectController newProject = new ProjectController();
newProject.CreatProject();
