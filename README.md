**NAME:VEDANT RAKESHBHAI DESAI


CLASS/DIV: 5-E


EN.NO:202403103520020**

# 🚌 Bus Booking Web Application  
### A Modern ASP.NET Core MVC Project  

---

## 🚀 Overview
**BusBooking** is a fully functional and beautifully designed **ASP.NET Core MVC web application** that simulates an online bus reservation system.  
It features a clean UI, responsive layouts, session-based authentication, and a modern, travel-inspired design.

---

## ✨ Key Features
- 🔐 **User Authentication** – Secure Register, Login, Logout  
- 🧭 **Admin Dashboard** – Manage buses, schedules, and routes  
- 🚌 **Trip Search & Booking System**  
- 💳 **My Bookings Page** – View or cancel bookings easily  
- 🌈 **Modern UI/UX** – Gradient buttons, glassmorphic navbar, and animations  
- 💡 **Session Management** – Handles Admin and User roles  
- 📱 **Fully Responsive Design** using **Bootstrap 5**

---

## 🧰 Tech Stack
| Layer | Technology |
|-------|-------------|
| **Frontend** | HTML5, CSS3, Bootstrap 5 |
| **Backend** | ASP.NET Core MVC |
| **Language** | C# |
| **Database (Optional)** | SQLite Server / Entity Framework Core |
| **IDE** | Visual Studio / VS Code |

---

## 🗂 Folder Structure
Bus_Booking_Web_Application/
├── Controllers/
├── Models/
├── Views/
│ ├── Account/
│ ├── Booking/
│ ├── Bus/
│ ├── Shared/
├── wwwroot/
│ ├── css/
│ │ └── site.css
│ ├── js/
│ │ └── site.js
│ └── lib/
└── Program.cs

---

## 🎨 UI Highlights
- 🌐 Glassmorphic **Navbar & Footer**  
- 💎 Gradient text and animated buttons  
- 🪄 Smooth scroll and fade-in animations  
- 🧭 Responsive layout for all devices  

---

## ⚙️ How It Works
1. Users can **Register** and **Login** securely.  
2. Logged-in users can **browse trips**, **book buses**, and **view bookings**.  
3. Admins can **manage buses**, **routes**, and **user data** via a dashboard.  
4. The entire site uses a shared `_Layout.cshtml` file for unified design.  

---

## 📸 Screenshots (optional)
Add screenshots inside a `/screenshots` folder and reference them here:


---

## 🧑‍💻 Author
**Vedant Desai**  
💼 Full Stack .NET Developer  
📧 Email: [d24amtics@gmail.com]  

---



📦 Prerequisites

Before running the project, ensure you have installed:

* [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download)
* [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or VS Code
* Git (to clone the repository)

---

⚙️ Installation & Setup

1️⃣ Clone the Repository

```bash
git clone https://github.com/Rudrasinh03/Bus_Booking_Web_Application.git
cd Bus_Booking_Web_Application
```
2️⃣ Open the Project

* Open the solution in **Visual Studio 2022** or **VS Code**.

3️⃣ Check Database Connection

In your **`appsettings.json`**, ensure this connection string exists:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=busapp.db"
}
```

 4️⃣ Run the Application

```bash
dotnet run
```

 5️⃣ Access in Browser

Open your browser and go to:

```
https://localhost:5001
```

🧩 Key Models

| Model       | Description                                         |
| ----------- | --------------------------------------------------- |
| **Bus**     | Stores bus details such as name, type, and capacity |
| **Route**   | Defines source and destination locations            |
| **Booking** | Stores user booking details                         |
| **User**    | Represents registered users (Admin / Customer)      |

⭐ **If you like this project, give it a star on GitHub!** ⭐  
> “Connecting cities with comfort, reliability, and a touch of code 🚍💙”