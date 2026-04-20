# ASPCoreWebAPICRUD
# Patient Management API (Week 7 - EF Core + SQL Integration)

## 📌 Overview
This project is a backend API built using ASP.NET Core and Entity Framework Core following a clean architecture approach.

The purpose of this project is to understand how EF Core works internally, how it maps to SQL, and how to write efficient queries.

---

## 🧱 Architecture

The project follows a layered architecture:
# Controller → Service → Repository → DbContext → Database


- **Controller**: Handles HTTP requests
- **Service**: Contains business logic
- **Repository**: Handles data access using EF Core
- **DbContext**: Connects application with the database

---

## 🗂️ Entities

The system includes the following entities:

- **Patient**
- **Doctor**
- **Appointment**

---

## 🔗 Relationships

The following relationships are implemented using Fluent API:

- **Patient → Appointments (One-to-Many)**
- **Doctor → Appointments (One-to-Many)**

### Behavior:
- Deleting a Patient → deletes related Appointments (Cascade)
- Deleting a Doctor → sets `DoctorId` to NULL in Appointment (SetNull)

---

## ⚙️ Entity Configuration

Fluent API is used to configure entities:

- String fields use `HasMaxLength`
- Decimal fields use `HasPrecision(10,2)`
- Relationships are explicitly defined
- Navigation properties are properly mapped

---

## 🔍 LINQ vs SQL

LINQ is used to query data in C#, while EF Core translates it into SQL.

### Example 1: Get appointments for a doctor

**LINQ:**
```csharp
_context.Appointments
    .Where(a => a.DoctorId == 1)
csharp```
**SQL:**
SELECT * FROM Appointments WHERE DoctorId = 1;

