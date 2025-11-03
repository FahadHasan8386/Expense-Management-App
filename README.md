# 💰 Expense Management Application

## 📋 Overview

The **Expense Management Application** is a full-stack solution designed to help users efficiently manage, track, and analyze their personal or organizational expenses. It allows you to record deposits and expenses, categorize transactions, and view reports for better financial decision-making.

This project follows a **clean architecture** with separate layers for API, Web UI, and Shared models, ensuring scalability, maintainability, and reusability.

---

## 🚀 Features

* ✅ Add, edit, and delete **expenses and deposits**
* 📂 Manage **expense categories** dynamically
* 🗃️ Track total spending and income
* ⚙️ **Soft delete** (InActive flag) for logical record deletion
* 🔗 Shared models for seamless communication between API and frontend
* 🧩 Follows the **MVC + Service Layer** pattern
* 📊 Responsive web interface with clear data presentation
* 💾 Database backup and restore support

---

## 🧠 Architecture

The project is structured into three main layers:

### 1. **ExpenseManagement.Api**

* Built using **ASP.NET Core Web API**
* Handles all backend operations, including data access and business logic
* Uses **Entity Framework Core** for database interaction
* Provides clean RESTful endpoints for frontend communication

### 2. **ExpenseManagement.Web**

* Built with **Blazor WebAssembly / ASP.NET MVC (depending on setup)**
* Provides an interactive and modern UI
* Communicates with API endpoints using HTTP calls

### 3. **ExpenseManagement.Shared**

* Contains **Data Transfer Objects (DTOs)** and shared models
* Ensures consistency between backend and frontend

---

## 🛠️ Tech Stack

| Layer           | Technology                         |
| --------------- | ---------------------------------- |
| Backend         | ASP.NET Core Web API               |
| Frontend        | Blazor / ASP.NET Core MVC          |
| Language        | C#                                 |
| Database        | SQL Server (Entity Framework Core) |
| IDE             | Visual Studio 2022                 |
| Version Control | Git & GitHub                       |

---


## 🧰 Folder Structure

```
Expense-Management-App/
│
├── ExpenseManagement.Api/        # ASP.NET Core Web API backend
├── ExpenseManagement.Web/        # Frontend Web Application
├── ExpenseManagement.Shared/     # Shared models and DTOs
├── DatabaseBackup/               # SQL database backup files
├── ExpenseManagement.sln         # Visual Studio solution file
└── README.md                     # Project documentation
```

## 🧩 Future Improvements

* 📈 Add user authentication (JWT / Identity)
* 💳 Include detailed reports and visual charts
* ☁️ Deploy to Azure or AWS for cloud hosting
* 🔐 Add role-based access control

---

## 👨‍💻 Author

**Fahad Hasan**
🎓 Computer Science Student at American International University–Bangladesh (AIUB)
🌐 [GitHub](https://github.com/FahadHasan8386) | [LinkedIn](https://www.linkedin.com/in/fahad-hasan-2969a3282/)

