## BlogApp - Real-time Notification Web Application

## Overview

**BlogApp** is a web application that provides a platform for users to create, edit, and view blog posts. The application features real-time notifications using SignalR to keep users updated with the latest posts and activities. It is built with .NET 7 and Entity Framework Core, leveraging JWT for authentication and authorization.

## Features

- User Registration and Authentication
- JWT-based Authentication
- CRUD Operations for Blog Posts
- Real-time Notifications with SignalR
- API Documentation with Swagger

## Technologies Used

- **Backend:** ASP.NET Core 7, Entity Framework Core
- **Frontend:** HTML, JavaScript
- **Real-time Communication:** SignalR
- **Authentication:** JWT (JSON Web Tokens)
- **Database:** SQL Server

## Prerequisites

- .NET SDK 7.x
- SQL Server
- Node.js and npm (for frontend development)
- Visual Studio Code (recommended for frontend development)

## Getting Started

### Backend Setup

1. **Clone the repository:**
   ~~~bash
   git clone https://github.com/your-username/BlogApp.git
   cd BlogApp
   ~~~
   
2. **Set up the database:**
- Update the connection string in appsettings.json to point to your SQL Server instance.
- Apply migrations to create the database schema:
  ~~~bash
    dotnet ef database update
  ~~~

3. **Run the application:**
  ~~~bash
  dotnet run
  ~~~
### Frontend Setup

1. **Serve the HTML file:**
- Use a live server extension in your IDE (e.g., Live Server in VS Code) to serve the Index.html file located in the Testes directory.
- Alternatively, you can use a simple HTTP server:
  ~~~bash
  npx http-server ./Testes
  ~~~

## API Endpoints
### Authentication
- Register:

  - POST /api/auth/register
  - Request Body:
    ~~~json
    {
    "username": "string",
    "password": "string"
    }
    ~~~

- Login:

  - POST /api/auth/login
  - Request Body:
    ~~~json
    {
    "username": "string",
    "password": "string"
    }
    ~~~

- Posts
  - Get All Posts:
  
    - GET /api/posts
  - Get User Posts:
  
    - GET /api/posts/user
    - Requires Authorization header with JWT token
  - Create Post:
  
    - POST /api/posts
    - Requires Authorization header with JWT token
    - Request Body:
      ~~~json
      {
      "title": "string",
      "content": "string"
      }
      ~~~
  - Edit Post:

    - PUT /api/posts/{id}
    - Requires Authorization header with JWT token
    - Request Body:
    ~~~json
    {
    "idPost": "int",
    "title": "string",
    "content": "string"
    }
    ~~~
- Real-time Notifications
  - Test Notoification
      To test the notification feature, you can use the `index.html` file located in the `Testes` folder, adjusting the hub URL if necessary. You may also need to allow the URL for the hub in the `Program.cs` file.
      To run the `index.html`, I used the Live Server extension in Visual Studio Code.
      ~~~C#
      builder.Services.AddCors(options =>
      {
          options.AddPolicy("CorsPolicy",
              builder => builder
                  .WithOrigins("http://127.0.0.1:5500")
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials());
      });
      ~~~
  



