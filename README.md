# ASPCoreWebAPICRUD
# Patient Management API (Week 7 - EF Core + SQL Integration)

##  Overview
This project is a backend API built using ASP.NET Core and Entity Framework Core following a clean architecture approach.

The purpose of this project is to understand how EF Core works internally, how it maps to SQL, and how to write efficient queries.

---

##  Architecture

The project follows a layered architecture:
# Controller → Service → Repository → DbContext → Database


- **Controller**: Handles HTTP requests
- **Service**: Contains business logic
- **Repository**: Handles data access using EF Core
- **DbContext**: Connects application with the database

---

##  Entities

The system includes the following entities:

- **Patient**
- **Doctor**
- **Appointment**

---

##  Relationships

The following relationships are implemented using Fluent API:

- **Patient → Appointments (One-to-Many)**
- **Doctor → Appointments (One-to-Many)**

### Behavior:
- Deleting a Patient → deletes related Appointments (Cascade)
- Deleting a Doctor → sets `DoctorId` to NULL in Appointment (SetNull)

---

##  Entity Configuration

Fluent API is used to configure entities:

- String fields use `HasMaxLength`
- Decimal fields use `HasPrecision(10,2)`
- Relationships are explicitly defined
- Navigation properties are properly mapped

---

##  LINQ vs SQL

LINQ is used to query data in C#, while EF Core translates it into SQL.

### Example 1: Get appointments for a doctor

**LINQ:**
```csharp
_context.Appointments
    .Where(a => a.DoctorId == 1)
```
**SQL:**
```sql
SELECT * FROM Appointments WHERE DoctorId = 1;
```
### Example 2: Get patients with no appointments
**LINQ:**
```csharp
_context.Patients
    .Where(p => !p.Appointments.Any())
```
**SQL:**
```sql
SELECT p.*
FROM Patients p
LEFT JOIN Appointments a ON p.PatientId = a.PatientId
WHERE a.PatientId IS NULL;
```
### Example 3: Get patient appointment count
```csharp
_context.Patients
    .Select(p => new {
        p.FirstName,
        Count = p.Appointments.Count
    })
```
**SQL:**
```sql
SELECT p.FirstName, COUNT(a.AppointmentId)
FROM Patients p
LEFT JOIN Appointments a ON p.PatientId = a.PatientId
GROUP BY p.FirstName;
```
---
## Tracking Decisions

By default, EF Core tracks entities which can affect performance.
For read-only queries, AsNoTracking() is used:
```csharp
_context.Patients
    .AsNoTracking()
    .ToListAsync();
```
### Benefits:
Improved performance
Reduced memory usage

Tracking is only used when updating or saving data.
--- 
### Performance Considerations
The following best practices were applied:

No Lazy Loading (avoids hidden queries)
No unnecessary Include
Use of Select for optimized data retrieval
Use of DTOs to control response size
Use of AsNoTracking for read-only queries
### Migrations
Migrations are used to keep the database schema in sync with code.

Commands used:
Add-Migration MigrationName
Update-Database

### ORM Understanding
Entity Framework Core (ORM) is used to map C# objects to database tables.

LINQ is written in code
SQL is generated internally
Understanding SQL helps optimize EF queries
### Conclusion
This project demonstrates:

Proper EF Core usage
Relationship handling
Efficient query writing
Understanding of LINQ to SQL translation
Avoidance of common ORM performance pitfalls

