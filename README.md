# Mercancías JyC

 Descripción
Mercancías JyC es una aplicación de gestión de pedidos y productos que permite a los usuarios crear, modificar, eliminar y listar productos y pedidos. La aplicación también gestiona las entregas con restricciones específicas basadas en la fecha y hora.

 Estructura del Proyecto
 Frontend: Angular 18.2.4
 Backend: ASP.NET Core 8
 Base de Datos: SQL Server
 Funcionalidades
 Productos:
 Crear nuevos productos
 Listar productos existentes
 Modificar información de productos
 Eliminar productos
 Pedidos:

 Crear nuevos pedidos (con validaciones de fecha para entregas)
 Listar pedidos existentes
 Eliminar pedidos
 Entregas:

 Crear nuevas entregas
 Listar entregas existentes
 Eliminar entregas
 Requisitos
 Node.js: 20.11.0
 Angular CLI: 18.2.4
 .NET SDK: 8.0
 SQL Server
 Instalación y Configuración
Backend (ASP.NET Core)

Clona el repositorio:

bash
Copiar código
git clone <URL_DEL_REPOSITORIO>
cd mercanciasjyc-backend
Restaura las dependencias:

bash
Copiar código
dotnet restore
Configura la base de datos:

Asegúrate de actualizar la cadena de conexión en appsettings.json con los detalles de tu servidor SQL Server.
Ejecuta la aplicación:

bash
Copiar código
dotnet run
Frontend (Angular)
Clona el repositorio:

bash
Copiar código
git clone <URL_DEL_REPOSITORIO>
cd mercanciasjyc-frontend
Instala las dependencias:

bash
Copiar código
npm install
Configura las variables de entorno:

Actualiza src/environments/environment.ts con la URL de tu API.
typescript
Copiar código
export const environment = {
  production: false,
  apiUrl: 'http://localhost:5000/api'
};
Ejecuta la aplicación:

bash
Copiar código
ng serve
Accede a la aplicación en http://localhost:4200.

Estructura de la Base de Datos
Tablas
Productos

ProductoID (int, PK)
Nombre (nvarchar(100))
Descripción (nvarchar(200))
Precio (decimal(18, 2))
Stock (int)
Pedidos

PedidoID (int, PK)
ClienteID (int)
FechaPedido (datetime)
Estado (nvarchar(50))
FechaEntrega (datetime)
Total (decimal(18, 2))
Entregas

EntregaID (int, PK)
PedidoID (int)
FechaEntrega (datetime)
Estado (nvarchar(50))
Procedimientos Almacenados
Productos:

CrearProducto
ObtenerProductos
ActualizarProducto
EliminarProducto
Pedidos:

CrearPedido
ObtenerPedidos
EliminarPedido
Entregas:

CrearEntrega
ObtenerEntregas
EliminarEntrega
