# 🎓 Training Management System

A full-stack **Training Management System** developed using **ASP.NET Core Web API** and **React**. The project provides a modern web application for managing departments, users, and training courses with secure authentication and a clean multi-layer architecture.

---

# 🚀 Features

### Authentication

- JWT Authentication
- User Login
- Password Encryption using BCrypt

### Department Management

- View Departments
- Create Department
- Update Department
- Delete Department

### User Management

- View Users
- Create User
- Update User
- Delete User

### Course Management

- View Courses
- Create Course
- Update Course
- Delete Course

---

# 🏗️ Project Architecture

```
TrainingManagementSystem
│
├── backend
│   ├── Controllers
│   ├── Models
│   ├── DTOs
│   ├── Services
│   ├── Data
│   └── Migrations
│
├── frontend
│   ├── src
│   ├── components
│   ├── pages
│   ├── services
│   ├── api
│   └── routes
│
└── README.md
```

---

# 🛠️ Tech Stack

## Backend

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server
- JWT Authentication
- BCrypt
- Dependency Injection
- DTO Pattern

## Frontend

- React
- React Router
- Axios
- JavaScript
- HTML
- CSS

## Tools

- Git
- GitHub
- Visual Studio
- Visual Studio Code

---

# 📂 Database

Current entities

- User
- Department
- Course

Relationships

```
Department
    │
    ├──── User
    │
    └──── Course
```

---

# 🔐 Authentication

The system uses

- JWT Token
- BCrypt Password Hashing
- Authorization Middleware

---

# 📡 REST APIs

## Authentication

```
POST /api/Auth/login
POST /api/Auth/register
```

## Users

```
GET
POST
PUT
DELETE
```

## Departments

```
GET
POST
PUT
DELETE
```

## Courses

```
GET
POST
PUT
DELETE
```

---

# 📷 Screenshots

## Login

> Coming Soon

## Dashboard

> Coming Soon

## Users Management

> Coming Soon

## Departments Management

> Coming Soon

## Courses Management

> Coming Soon

---

# ⚙️ Installation

## Clone Repository

```bash
git clone https://github.com/YOUR_USERNAME/training-management-system.git
```

---

## Backend

```bash
cd backend

dotnet restore

dotnet build

dotnet run
```

Backend runs at

```
http://localhost:5128
```

Swagger

```
http://localhost:5128/swagger
```

---

## Frontend

```bash
cd frontend

npm install

npm run dev
```

Frontend

```
http://localhost:5173
```

---

# 📖 Project Status

Current Progress

- ✅ Authentication
- ✅ Department CRUD
- ✅ User CRUD
- ✅ Course CRUD
- ✅ React Login
- ✅ Dashboard
- 🚧 Frontend Management Pages
- 🚧 UI Improvements

---

# 🎯 Future Improvements

- Student Management
- Instructor Management
- Training Schedule
- Role-Based Authorization
- Dashboard Statistics
- Responsive UI
- Search & Filter
- Pagination
- Export Excel
- File Upload

---

# 👨‍💻 Author

**Truong Tuan Dung**

Software Developer Intern

GitHub

https://github.com/dungtruong282

---

# 📄 License

This project is developed for learning purposes.
