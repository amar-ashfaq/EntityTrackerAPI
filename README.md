# EntityTrackerAPI

A simple **in-memory RESTful API** built with **ASP.NET Core**, demonstrating a **clean, layered architecture** with strong separation of concerns.  
Ideal for learning backend fundamentals, experimenting with architectural patterns, or using as a foundation for a more advanced API.

## 🔧 What is this project?

EntityTrackerAPI is a minimal, self-contained Web API that allows clients to **Create, Read, Update, and Delete (CRUD)** “Entity” records.  
Instead of relying on a database, the application uses an **in-memory list**, making it easy to experiment without setup overhead.

### 🎯 Goals

- Build a fully functional REST API supporting CRUD operations  
- Apply correct HTTP semantics (200, 201, 204, 400, 404, etc.)  
- Demonstrate clean layering with **Controllers → Services → Repositories**  
- Use **Dependency Injection** to decouple components  
- Keep code easy to maintain, extend, and test  
- Provide a base for future additions (DTOs, validation, database integration)

---

## 🏗 Architecture & Patterns

EntityTrackerAPI follows a layered architecture inspired by **Clean Architecture** and **Domain-Driven Design** principles.

### 📚 Layers

| Layer | Responsibility | Example Classes / Folders |
|-------|----------------|--------------------------|
| **API / Controller Layer** | Handles HTTP requests/responses, routing, status codes | `Controllers/EntityController.cs` |
| **Service Layer (Business Logic)** | Contains all domain rules: ID generation, validation, existence checks, update/delete logic | `Services/IEntityService.cs` `Services/EntityService.cs` |
| **Repository Layer (Data Access)** | Manages data storage and retrieval; currently backed by an in-memory list | `Repositories/IEntityRepository.cs` `Repositories/EntityRepository.cs` |
| **Domain Models (Entities)** | Defines the structure of core objects in the system | `Entities/Entity.cs` |

### 🔍 Why this matters

This architecture ensures:

- **Controllers remain thin**, focusing only on HTTP concerns  
- **Services handle all business logic**, keeping it reusable and testable  
- **Repository layer abstracts persistence**, allowing you to replace the in-memory store with a real database later  
- **Dependency Injection** cleanly connects the layers while keeping them decoupled  

This results in a codebase that is **maintainable, scalable, and easy to understand** — very similar in philosophy to Clean Architecture, even if kept in a single project for simplicity.

