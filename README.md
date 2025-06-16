-Sistema de Gestión de Productos y Ventas
## Tecnologías utilizadas

| Capa         | Tecnología / Librería                  |
|--------------|----------------------------------------|
| **Backend**  | .NET 8 (C#), ASP.NET Core Web API      |
|              | Entity Framework Core                  |
|              | SQL Server                             |
|              | AutoMapper                             |
|              | xUnit + Moq (pruebas unitarias)        |
|              | Microsoft.Extensions.DependencyInjection |
|              | System.IdentityModel.Tokens.Jwt (JWT)  |
| **Frontend** | Vue 3 (Composition API)                |
|              | Vite + Tailwind CSS                    |
|              | Axios                                  |
|              | Vue Router                             |
| **General**  | Git, GitHub                            |
|              | Swagger / Swashbuckle                  |

## Instrucciones

### 1. Clonar el repositorio
bash
-git clone https://github.com/Steilor/PruebaDGA.git
cd ClnArq

### 2.Backend (.NET API)
Configurar cadena de conexión
En ClnArq.API/appsettings.json, modifica "DefaultConnection":

"ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVIDOR;Database=AduanasDb;Trusted_Connection=True;TrustServerCertificate=True;"
}

Aplicar migraciones y poblar BD

cd ClnArq.API
dotnet ef database update
dotnet run

La API quedará disponible en https://localhost:5001 (por defecto).

### 3.Swagger
Abre en el navegador https://localhost:5001/swagger para explorar y probar los endpoints
![image](https://github.com/user-attachments/assets/e6bec304-c5e3-4659-a36a-2645b1e15b4c)

### 4.Frontend (Vue.js)
cd ../frontend
npm install

npm run dev

npm run build

![image](https://github.com/user-attachments/assets/7c86096f-b36e-4978-b57d-b370874698b8)

![image](https://github.com/user-attachments/assets/f6ee95c7-cb6d-4304-86c3-905543365333)

![image](https://github.com/user-attachments/assets/37f2bf04-b92d-41f3-af1e-ce4d7cc24615)


![image](https://github.com/user-attachments/assets/a6b253cb-1836-40ed-b3cc-697e97c96247)

![image](https://github.com/user-attachments/assets/8fde64a7-2a09-45ef-ad1b-d262bb5a6cbc)

![image](https://github.com/user-attachments/assets/28ca823d-6cad-44d6-9a10-42d11d391032)
