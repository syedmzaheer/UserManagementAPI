# UserManagementAPI

A RESTful Web API built with ASP.NET Core for managing users within an organization. This project includes custom middleware for logging, error handling, and token-based authentication, developed with assistance from Microsoft Copilot.

---

## 📌 Project Overview

**Client**: TechHive Solutions  
**Goal**: Create an internal API for HR and IT departments to perform CRUD operations on user data, while ensuring secure, auditable, and maintainable middleware-based request handling.

---

## 🚀 Features

- ✅ CRUD operations for users (Create, Read, Update, Delete)
- ✅ Middleware for:
  - **Logging** all incoming requests and outgoing responses
  - **Error handling** with consistent JSON error messages
  - **Token-based authentication** for securing endpoints
- ✅ Structured and modular ASP.NET Core Web API
- ✅ Tested with Postman for all scenarios

---

## 🛠️ Technologies Used

- ASP.NET Core 7 Web API
- Microsoft Copilot (for code generation)
- C#
- Postman (for API testing)

---

## 🔧 Setup Instructions

1. **Clone the Repository**
   ```bash
   git clone https://github.com/your-username/UserManagementAPI.git
   cd UserManagementAPI
   ```

2. **Open the Project in Visual Studio / VS Code**

3. **Build the Project**
   ```bash
   dotnet build
   ```

4. **Run the API**
   ```bash
   dotnet run
   ```

---

## 📂 Project Structure

```
UserManagementAPI/
│
├── Controllers/
│   └── UsersController.cs
│
├── Middleware/
│   ├── LoggingMiddleware.cs
│   ├── ErrorHandlingMiddleware.cs
│   └── TokenAuthenticationMiddleware.cs
│
├── Models/
│   └── User.cs
│
├── Program.cs
└── README.md
```

---

## ⚙️ Middleware Configuration Order

Middleware is configured in the correct order to ensure optimal performance and security:

1. `ErrorHandlingMiddleware` – handles exceptions globally
2. `TokenAuthenticationMiddleware` – ensures valid token is present
3. `LoggingMiddleware` – logs request method, path, and response status

---

## 🔒 Authentication

For demonstration purposes, token validation is simulated. Requests must include:

```http
Authorization: Bearer valid-token
```

In a real-world scenario, this should be replaced with JWT or OAuth authentication.

---

## 🧪 API Testing (Postman)

| Method | Endpoint         | Description            | Auth Required |
|--------|------------------|------------------------|---------------|
| GET    | `/api/users`     | Get all users          | ✅ Yes        |
| GET    | `/api/users/{id}`| Get user by ID         | ✅ Yes        |
| POST   | `/api/users`     | Create new user        | ✅ Yes        |
| PUT    | `/api/users/{id}`| Update user details    | ✅ Yes        |
| DELETE | `/api/users/{id}`| Delete user            | ✅ Yes        |

---

## 🤖 Copilot Usage Documentation

Microsoft Copilot was used to:
- Scaffold the API project
- Generate controller and middleware code
- Improve error handling logic
- Assist with proper ordering and configuration of middleware
- Speed up debugging and code documentation

---
