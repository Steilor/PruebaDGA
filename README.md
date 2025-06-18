## Sistema de Gestión de Productos y Ventas
## Tecnologías utilizadas

| Capa         | Tecnología / Librería                  |
|--------------|----------------------------------------|
| **Backend**  | .NET 8 (C#), ASP.NET Core Web API      |
|              | Entity Framework Core                  |
|              | Identity                               |
|              | SQL Server                             |
|              | AutoMapper                             |
|              | XuNit                                  |
|              | Microsoft.Extensions.DependencyInjection |
| **Frontend** | Vue 3 (Composition API)                |
|              | Vite + Tailwind CSS                    |
|              | Axios                                  |
|              | Vue Router                             |
| **General**  | Git, GitHub                            |
|              | Swagger / Swashbuckle                  |





![image](https://github.com/user-attachments/assets/676cd9cc-783b-4f41-9f6f-5d4b6006969f)





![image](https://github.com/user-attachments/assets/f337137e-d0b1-4ae6-95fe-5d63eb140e8c)



![image](https://github.com/user-attachments/assets/47af733d-c1ea-4fac-b5dc-cd63b2dc9907)



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

Para aplicar los test: Simplemente "dotnet test" en la raiz del proyecto

### 3.Swagger
Abrir en el navegador https://localhost:5001/swagger para explorar y probar los endpoints

![image](https://github.com/user-attachments/assets/e6d10b90-728d-40d1-840a-d398469122ab)

![image](https://github.com/user-attachments/assets/119a6f35-8dd6-4b9e-bf4a-6f1744fc30b4)

![image](https://github.com/user-attachments/assets/72d32000-ffd3-4a0b-8940-8279fdf3ac7f)

![image](https://github.com/user-attachments/assets/f245987d-db28-45f1-8dda-be05dce0db86)


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
