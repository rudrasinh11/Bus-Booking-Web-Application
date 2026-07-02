# 🚌 Bus Booking Web Application
### ASP.NET Core MVC bus reservation system

---

## Overview
A complete ASP.NET Core MVC web application for bus reservation workflows. Users can register, search trips, book seats, and manage bookings while admins can manage buses, routes, and schedules.

---

## Key Features
- User registration, login, and logout
- Admin dashboard for buses, schedules, and routes
- Trip search, booking, and booking history
- Responsive UI with Bootstrap 5
- SQLite + Entity Framework Core for local data storage
- Session and role-aware behavior for customers and admins

---

## Tech Stack
| Layer | Technology |
|------|------------|
| Frontend | HTML, CSS, Bootstrap 5, Razor Views |
| Backend | ASP.NET Core MVC |
| Language | C# |
| Database | SQLite via Entity Framework Core |

---

## Project Structure
```
BusBookingWebApp/
├── Controllers/
├── Models/
├── Views/
│   ├── Account/
│   ├── Booking/
│   ├── Bus/
│   ├── Shared/
├── wwwroot/
│   ├── css/
│   ├── js/
│   └── lib/
├── Data/
├── Migrations/
├── Program.cs
└── BusBookingWebApp.csproj
```

---

## Setup & Run
### Prerequisites
- .NET 10 SDK
- Visual Studio or VS Code
- Optional: Git to clone the repo

### Run locally
1. Open PowerShell in the project folder:
   `E:\Bus Booking Application\Bus Booking Application`
2. Restore and run the app:
   ```powershell
   dotnet restore
   dotnet run --project "BusBookingWebApp.csproj"
   ```
3. Open the app in your browser:
   ```text
   http://localhost:5000
   ```

> If `dotnet` is not available in your current shell, use the full SDK path:
> `& "C:\Program Files\dotnet\dotnet.exe" run --project "BusBookingWebApp.csproj"`

---

## Configuration
Ensure `appsettings.json` includes the SQLite connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=busapp.db"
}
```

If the database file is missing, it will be created automatically when the app runs.

---

## Notes
- The app uses session-based state for authentication.
- Default data may be seeded via EF migrations.
- The footer and layout are managed in `Views/Shared/_Layout.cshtml`.

---

## Author
**Rudra Desai**

---

## Useful Commands
```powershell
# Restore dependencies
dotnet restore

# Run the web app
dotnet run --project "BusBookingWebApp.csproj"

# Stop the app
Ctrl+C
```

---

## Contact
For questions or updates, edit this repository README directly.
