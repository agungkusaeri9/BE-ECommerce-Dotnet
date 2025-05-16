# 🛒 E-Commerce Backend - .NET 8

Proyek ini adalah backend REST API untuk aplikasi e-commerce, dibangun dengan **ASP.NET Core 8**, menggunakan arsitektur bersih dan mengikuti best practices modern. Proyek ini mengelola otentikasi pengguna serta fitur manajemen kategori dan brand.

## ✅ Fitur yang Sudah Selesai

- ✅ User Registration
- ✅ User Login (JWT Auth)
- ✅ Brand Management (CRUD)
- ✅ Product Category Management (CRUD)

---

## 🧱 Tech Stack

- **.NET 8**
- **MySQL** (via Pomelo.EntityFrameworkCore.MySql)
- **Entity Framework Core**
- **JWT Authentication**
- **FluentValidation**
- **Clean Architecture (Service & Repository Pattern)**

---

## 📁 Struktur Folder

backend-dotnet/
│
├── Controllers/ # Endpoint definitions
├── Data/ # DbContext
├── DTOs/ # Data Transfer Objects
├── Entities/ # Entity models
├── Interfaces/ # Service & Repository interfaces
├── Repositories/ # Implementation of data access
├── Services/ # Business logic
├── Validators/ # FluentValidation schemas
├── Extensions/ # Service registration extensions
├── wwwroot/ # File uploads (e.g. brand/category images)
└── Program.cs # App configuration entry point

## 🚀 Menjalankan Proyek

### 1. Persiapan Environment

Rename file `.env.example` menjadi .env kemudian sesuaikan :

JWT_KEY=kx5G4DcUDuU3drxBXPNChA48502v6Zh7NZbZQcqtQV9hdGWgAHf02DdpYzRuKPhYiRMTb3jkngBbYjcTtdCVdW1zkv8tqEAsHLHX
JWT_ISSUER=example.com
JWT_AUDIENCE=example.com
DEFAULT_CONNECTION=server=localhost;port=3306;database=dotnet_ecommerce;user=root;password=

### 2. Restore dan Run

```bash
dotnet restore
dotnet ef database update
dotnet run

```
