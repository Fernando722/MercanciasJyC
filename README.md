# Mercancías JyC
Descripción
Aplicación para gestionar productos, pedidos y entregas con restricciones específicas de entrega.

Tecnologías
Frontend: Angular 18.2.4
Backend: ASP.NET Core 8
Base de Datos: SQL Server
Funcionalidades
Productos: Crear, listar, modificar, eliminar.
Pedidos: Crear, listar, eliminar.
Entregas: Crear, listar, eliminar.
Requisitos
Node.js: 20.11.0
Angular CLI: 18.2.4
.NET SDK: 8.0
SQL Server
Instalación
Backend
Clona el repositorio y navega a la carpeta:

bash
Copiar código
git clone https://github.com/Fernando722/MercanciasJyC
cd mercanciasjyc-backend
Restaura dependencias y ejecuta:

bash
Copiar código
dotnet restore
dotnet run
Frontend
Clona el repositorio y navega a la carpeta:

bash
Copiar código
git clone https://github.com/Fernando722/MercanciasJyC
cd mercanciasjyc-frontend
Instala dependencias y ejecuta:

bash
Copiar código
npm install
ng serve
Base de Datos
Productos: ProductoID, Nombre, Descripción, Precio, Stock
Pedidos: PedidoID, ClienteID, FechaPedido, Estado, FechaEntrega, Total
Entregas: EntregaID, PedidoID, FechaEntrega, Estado
API
Productos
GET 
/api/productos
POST 
/api/productos
PUT 
/api/productos/{id}
DELETE 
/api/productos/{id}
Pedidos
GET 
/api/pedidos
POST 
/api/pedidos
PUT 
/api/pedidos/{id}
DELETE 
/api/pedidos/{id}
Entregas
GET 
/api/entregas
POST 
/api/entregas
PUT 
/api/entregas/{id}
DELETE 
/api/entregas/{id}
