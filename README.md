DVLD — Driving & Vehicle License Department

A desktop-based Driving & Vehicle License Department (DVLD) management system built with C# and later evolved into a client-server architecture using ASP.NET Core Web API.

The project manages different operations related to people, drivers, applications, licenses, tests, and vehicle license department workflows.

📌 Project Overview

The project was initially developed as a C# Windows Forms application using ADO.NET and SQL Server.

It was later refactored into a client-server architecture:

Windows Forms Client
        │
        │ HTTP / JSON
        ▼
ASP.NET Core Web API
        │
        ▼
Application Services
        │
        ▼
Entity Framework Core
        │
        ▼
SQL Server

The goal of the transition was to separate the client application from the backend and apply modern backend development practices.

🚀 Main Features
👤 People Management
Add, update, delete and search people
Manage personal information
Country management
Person-related operations
🚗 Drivers & Licenses
Driver management
License management
License renewal
License replacement
International licenses
📝 Applications
Manage different application types
Application status management
Application processing
🧪 Tests
Vision tests
Written tests
Street tests
Test scheduling and management
🚔 Detain & Release
Detain licenses
Release detained licenses
Manage detention records
🔐 Authentication & Authorization

The API includes a security layer based on JWT.

Authentication
JWT Bearer Authentication
Login endpoint
Access Tokens
Refresh Tokens
Automatic access-token renewal
Authorization
Role-Based Authorization
Policy-Based Authorization
Resource-Based Authorization

For example, an administrator can access users globally, while a normal user can only access resources belonging to themselves.

🛡️ API Security

The project also implements:

Rate Limiting
JWT validation
Role and policy authorization
Resource ownership validation
Refresh Token Revocation
Global Exception Handling
Application Logging
🧰 Technologies
Technology	Usage
C#	Main programming language
.NET	Application framework
ASP.NET Core Web API	Backend
Entity Framework Core	Data Access
SQL Server	Database
Windows Forms	Client Application
JWT	Authentication
HttpClient	API communication
Swagger / OpenAPI	API testing and documentation
🏗️ Architecture

The application follows a client-server architecture.

Client

The Windows Forms application communicates with the API through HTTP requests using HttpClient.

The client is responsible for:

User interface
Sending API requests
Handling API responses
Managing authentication tokens
Automatically refreshing expired access tokens
API

The ASP.NET Core Web API is responsible for:

Business operations
Authentication
Authorization
Validation
Security
Data access
Logging
Exception handling

The client does not directly access the database.

🔑 Authentication Flow
Login
  │
  ▼
ASP.NET Core API
  │
  ├── Access Token
  │
  └── Refresh Token
          │
          ▼
        Client

When the access token expires:

Client Request
      │
      ▼
   401 Unauthorized
      │
      ▼
Refresh Token Endpoint
      │
      ▼
New Access Token
+ New Refresh Token
      │
      ▼
Retry Original Request
📊 Database

The project uses SQL Server as the database.

Entity Framework Core is used by the API for database access and entity management.

Refresh tokens are stored and managed server-side to support:

Expiration
Revocation
Rotation
Multiple user sessions
🧪 API Documentation

Swagger / OpenAPI is used to test and document the API endpoints during development.

🎥 Demo

A short demo video is available on the project's LinkedIn post, showing the main application features and authentication flow.

📚 What I Learned

Through this project, I practiced and applied:

RESTful API development
Client-server architecture
Entity Framework Core
DTO-based communication
Dependency Injection
Async programming
JWT Authentication
Authorization and Policies
Role-Based Access Control
Resource-Based Authorization
Refresh Token Rotation
Rate Limiting
Logging
Exception Handling
HTTP communication between applications
