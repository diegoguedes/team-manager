## Instructions

The goal of this exercise is to create a backend using C# using the REST arquitecture. That backend application will be help to manage the team.

### Features and Requirements
- A member has a name and a type the late one can be an employee or a contractor.
- - If it's a contractor, we want to store the the duration of the contract as an integer.
- - If it's an employee, we need to store their role, for instance: Software Engineer, Project Manager and so on.
- A member can be tagged, for instance: C#, Angular, General Frontend, Seasoned Leader and so on.
- We need to offer a REST CRUD for all the information above.

## Tecnologies

- _Architectural pattern:_ Clean Architecture
- _Database:_ Postgres 
- _ORM tool:_ Entity Framework Core with Code-First to create the database (the migration is in the Migrations folder in the TeamManager.Infra.Data project)
- _Database Provider:_ Npgsql.EntityFrameworkcore.PostgreSQL
- _Migration tool:_ Microsoft.EntityFrameworkcore.Tools
- _ORM acess:_ Repository Pattern
- _Unit tests:_ XUnit

## Project structure (TeamManager)

- _TeamManager.Domain:_ domain model, business rules and interfaces
- _TeamManager.Application:_ application domain rules, mappings, services, DTOs
- _TeamManager.Infra.Data:_ EF Core, Context, Configurations, Migrations, Repository
- _TeamManager.Infra.IoC:_ Dependency Injection and service registration
- _TeamManager.Web:_ Controllers

## Run Application
**Requirements:**
- Instaled postgres database
- C# environment configured
- C# IDE like Rider or Visual Studio

**How to run the TeamManager Application**
- In file (backend/TeamManager.Web/appsettings.json) change "USERNAME" and "PASSWORD" to your postgres database username and password
- In project (TeamManager.Infra.Data), run the following command in Console (Terminal, PowerShell, CMD, etc ) to create database structure and datas
 
 ```console
dotnet ef --startup-project ..\TeamManager.Web\ database update
```  
- Open TeamManager.sln in a C# IDE
- Include TeamManager.Web like "Started Project", press Run and be happy! :-)
