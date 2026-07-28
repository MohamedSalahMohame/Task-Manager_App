# Task Manager

A simple Task Management application built with ASP.NET Core Web API and Angular.

## Features

### Projects
- View all projects
- Create a new project
- Edit an existing project
- Delete a project

### Tasks
- View tasks for a specific project
- Create a new task
- Edit an existing task
- Delete a task
- Filter tasks by project

---

# Technologies

## Backend

- ASP.NET Core 9 Web API
- Clean Architecture
- Entity Framework Core
- SQL Server
- AutoMapper
- FluentValidation
- Swagger

## Frontend

- Angular 21
- Angular Material
- Reactive Forms
- Standalone Components

---



---

# Getting Started

## Backend

1. Open the solution in Visual Studio.
2. Update the database:

```bash
Update-Database
```

or

```bash
dotnet ef database update
```

3. Run the API.

Swagger will be available at:

```
https://localhost:xxxxx/swagger
```

---

## Frontend

Install dependencies:

```bash
npm install
```

Run the Angular application:

```bash
ng serve --port 53630
```

Open:

```
http://localhost:53630
```

---

# API Endpoints

## Projects

- GET /api/projects
- GET /api/projects/{id}
- POST /api/projects
- PUT /api/projects/{id}
- DELETE /api/projects/{id}

## Tasks

- GET /api/tasks
- GET /api/tasks/{id}
- GET /api/tasks/project/{projectId}
- GET /api/tasks/status/{status}
- POST /api/tasks
- PUT /api/tasks/{id}
- DELETE /api/tasks/{id}

---

# Screenshots

You can add screenshots of:

- Projects page
- Create Project dialog
- Tasks page
- Create Task dialog

---

# Author

**Mohamed Salah**

Full Stack Developer (.NET | Angular)