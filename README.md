# WebAPIDemoProject
Creating A Web API Project In Visual Studio 2019


Introduction
In this article I’m trying to explain, creating API with GET, POST, PUT and DELETE. These are basic CRUD operations which we need while creating APIs. Also, I'll explain how to connect the database using the Scaffold DB context and creating a model to process the API request and response.



The basic things we need to understand before start writing WebAPI’s,

Database.
HTTP Methods.
Router.
HTTP Status Code.
Model.
WebAPI acts as a middleware between the client-side and server-side. For example, When the user hits a button, it will call an API from the client-side,  Get user details. Now API will process the request and get the data from the database based on logic.

Creating A WEB API Project In Visual Studio 2019

Database
The database is a collection of data in an organized way so that users can easily access, manage, and update.

HTTP Methods

Get: To get data from a database, we use Get Method.
Post: To insert data to a database in the form of a payload in the request body to create/update.
Put: It is similar to Post, mainly meant for updates.
Delete: To delete data from the database.
Router
In the Web API controller, we have different types of action methods [get, post, put, delete ] the router takes this incoming request and routes this request to the appropriate action method in the API controller.

WEB API supports two types of routing

Convention-based Routing - It should have at least one route template using that template it identifies controller and action method to execute.
Attribute Routing - We can define routing directly at the Controller or action level using route attributes Route[()].
In this article, we are using Attribute Routing to define the route of an action method. 

Example

[Route("api/User/GetUserById")]
C#
Here User is Controller Name and GetUserById is an API name.

HTTP Status Code
These are most commonly used status codes are listed here,

200 OK: When request successfully returned the response. 
201 Created: When record inserted to database successfully.
202 Accepted: When a request is accepted for processing.
204 No content: When response returned with no content.
400 BadRequest: When there is a problem with request sending from the client-side.
401 Unauthorized: When authentication or authorization fails.
500 Internal Server Error: When the server doesn't fulfill the request[ exceptions or errors in API code].
Model

Model is a class that has a set of properties with getters and setters, that represents the data to process the API request. 

Let's start with coding,

Create a Model Folder and Model class file as shown below.

Right click on project => Add => NewFolder [Folder Name : Model]

Right click on Folder => Add => New File [File name : Controller Name ]

Creating A WEB API Project In Visual Studio 2019

Creating A WEB API Project In Visual Studio 2019

Sample Model

GetUserModel is a model name. 

public class GetUserModel
{
     public int UserID { get; set; }
     public string Name { get; set; }
     public string Address { get; set; }
     public string Email { get;  set; }
     public string PhoneNumber { get; set; }
     public bool IsActive { get; set; }
}
C#
Scaffold-DbContext Command

Select menu Tools -> NuGet Package Manager -> Package Manager Console and run the following command:

PM> Scaffold-DbContext "Server=(LocalDb)\MSSQLLocalDB;Initial Catalog=DemoDatabase;Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DataModel
C#
Here I'm trying to connect the local database. 

Server=.\SQLExpress; refers to local SQLEXPRESS database server.

Database= DemoDatabase

Specifies the database name " DemoDatabase" for which we are going to create classes.

Trusted_Connection=True

Specifies the Windows authentication. It will use Windows credentials to connect to the SQL Server.

Microsoft.EntityFrameworkCore.SqlServer

It is the provider's name. We use a provider for the SQL Server, so it is Microsoft.EntityFrameworkCore.SqlServer.

-OutputDir

Parameter specifies the directory where we want to generate all the classes which is the Models folder in this case.

Below Image shows Folder DataModel => DemoDatabaseContext.cs is the DbContext file. Users.cs file is the table model. Database as only one table.

Creating A WEB API Project In Visual Studio 2019

Let's start creating the API.

Try-Catch block

Always add try-catch block if API fails in the middle of the process you can return BadRequest with exception details.

DbContext

DemoDatabaseContext db = new DemoDatabaseContext();
C#
DemoDatabaseContext is database context name. DemoDatabaseContext is used to access database tables.

Route("api/[controllerName]")]

We have this outside controller class. This means we are setting path: api/User

Linq (Language Integrated Query)

It is used to get data from a database based on conditions. In the below example, we are trying to get user details using userId.

var user = db.Set<Users>().Where(w => w.Id == id);
C#
Get API

Gets user details by user Id.

API Name

GetUserById

[Route("api/[GetUserById]")]

For every API we have routing. Each name should be unique. API path : api/User/GetUserById

Post API / Put API

Both post and put are done in the same API.

Delete API

In this, we are just setting IsActive to false.
