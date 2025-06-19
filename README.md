# 🏪 Sistema de Gestión de Productos y Ventas

<div align="center">

**Aplicación full‑stack para la gestión de productos, clientes y ventas**

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet)
![Vue.js](https://img.shields.io/badge/Vue.js-3.0-4FC08D?style=for-the-badge&logo=vue.js)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server)
![TailwindCSS](https://img.shields.io/badge/Tailwind-38B2AC?style=for-the-badge&logo=tailwind-css)

</div>

---

## 🚀 Descripción del Proyecto

Sistema completo de gestión empresarial que combina un **backend** en .NET 8 con un **frontend** en Vue 3. Diseñado para manejar productos, clientes y ventas de manera eficiente y escalable.

### 🎯 Características Principales

- ✅ **.Net Core** completa con .Net 8
- ✅ **API REST** completa con autenticación JWT
- ✅ **Base de datos** SQL Server con Entity Framework Core
- ✅ **Autenticación y Autorización** completa con autenticación JWT
- ✅ **Frontend reactivo** con Vue 3 Composition API
- ✅ **Diseño responsive** con TailwindCSS
- ✅ **Pruebas unitarias** integradas
- ✅ **Documentación automática** con Swagger
- ✅ **Seeder de datos** para pruebas rápidas

---

## 🛠️ Stack Tecnológico

<table>
<tr>
<td width="50%">

### 🔧 Backend
- **Framework:** .NET 8 (C#)
- **API:** ASP.NET Core Web API
- **ORM:** Entity Framework Core
- **Base de Datos:** SQL Server
- **Autenticación:** JWT Identity
- **Mapeo:** AutoMapper
- **Testing:** xUnit
- **DI:** Microsoft.Extensions.DependencyInjection

</td>
<td width="50%">

### 🎨 Frontend
- **Framework:** Vue 3 (Composition API)
- **Build Tool:** Vite
- **Estilos:** TailwindCSS
- **HTTP Client:** Axios
- **Routing:** Vue Router
- **Documentación:** Swagger/Swashbuckle
- **Control de Versiones:** Git & GitHub

</td>
</tr>
</table>

---

## 📸 Capturas de Pantalla

### 🖥️ Vista General del Sistema
![image](https://github.com/user-attachments/assets/676cd9cc-783b-4f41-9f6f-5d4b6006969f)

### 📊 Dashboard Principal
![image](https://github.com/user-attachments/assets/f337137e-d0b1-4ae6-95fe-5d63eb140e8c)

### 📋 Gestión de Datos
![image](https://github.com/user-attachments/assets/47af733d-c1ea-4fac-b5dc-cd63b2dc9907)

---

## 🚀 Instalación y Configuración

### 📋 Prerrequisitos
- .NET 8 SDK
- Node.js (v16 o superior)
- SQL Server
- Git

### 1️⃣ Clonar el Repositorio

```bash
git clone https://github.com/Steilor/PruebaDGA.git
cd ClnArq
```

### 2️⃣ Configuración del Backend

#### 🔧 Configurar Base de Datos
Edita el archivo `ClnArq.API/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=TU_SERVIDOR;Database=AduanasDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

#### 🗄️ Aplicar Migraciones

```bash
cd ClnArq.API
dotnet ef database update
dotnet run
```

> 🌐 **La API estará disponible en:** `https://localhost:5001`

#### 🧪 Ejecutar Pruebas

```bash
dotnet test
```

---

## 🌱 Seeder de Datos Iniciales

> 💡 **¡No necesitas ingresar datos manualmente!**

El sistema incluye un **seeder automático** que detecta si las tablas están vacías y, en caso afirmativo, inserta aproximadamente **40 registros de ejemplo** en:

- 👥 **Clientes**
- 📦 **Productos** 
- 💰 **Ventas**
- 📋 **Detalles de Venta**

Esto permite probar todos los endpoints desde el primer `dotnet run`.

---

## 📚 Documentación API (Swagger)

### 🔍 Explorar Endpoints
Accede a la documentación interactiva en: **https://localhost:5001/swagger**

#### 📸 Capturas de Swagger

**Panel Principal:**
![image](https://github.com/user-attachments/assets/e6d10b90-728d-40d1-840a-d398469122ab)

**Endpoints de Productos y Ventas:**
![image](https://github.com/user-attachments/assets/119a6f35-8dd6-4b9e-bf4a-6f1744fc30b4)

**Endpoints de Identity:**
![image](https://github.com/user-attachments/assets/72d32000-ffd3-4a0b-8940-8279fdf3ac7f)

**Schema:**
![image](https://github.com/user-attachments/assets/f245987d-db28-45f1-8dda-be05dce0db86)

---

## 3️⃣ Configuración del Frontend

### 📦 Instalación de Dependencias

```bash
cd ../frontend
npm install
```

### 🚀 Comandos Disponibles

```bash
# Desarrollo
npm run dev

# Construcción para producción
npm run build
```

---

## 🖼️ Capturas del Frontend

### 🏠 Página Principal
![image](https://github.com/user-attachments/assets/7c86096f-b36e-4978-b57d-b370874698b8)

### 📊 Gestión de Productos
![image](https://github.com/user-attachments/assets/f6ee95c7-cb6d-4304-86c3-905543365333)

### 📋 Lista de Productos
![image](https://github.com/user-attachments/assets/37f2bf04-b92d-41f3-af1e-ce4d7cc24615)

### 👥 Gestión de Clientes
![image](https://github.com/user-attachments/assets/a6b253cb-1836-40ed-b3cc-697e97c96247)

### 💰 Registro de Ventas
![image](https://github.com/user-attachments/assets/8fde64a7-2a09-45ef-ad1b-d262bb5a6cbc)

### 📈  Gestión de Ventas
![image](https://github.com/user-attachments/assets/28ca823d-6cad-44d6-9a10-42d11d391032)

---


Desarrollado por [Steilor](https://github.com/Steilor)



