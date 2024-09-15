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
git clone <https://github.com/Fernando722/MercanciasJyC>
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

# API

Pruebas de la API con Postman
Configuración de Postman
Descargar e Instalar Postman:

Descárgalo desde Postman e instálalo.
Abrir Postman:

Lanza la aplicación Postman.
Probar Endpoints de la API
Productos
Obtener Lista de Productos

Método: GET
URL: http://localhost:5000/api/productos
Descripción: Lista todos los productos.
Crear un Nuevo Producto

Método: POST

URL: http://localhost:5000/api/productos

Body (JSON):

json
Copiar código
{
  "nombre": "Producto Ejemplo",
  "descripcion": "Descripción del producto",
  "precio": 50.00,
  "stock": 10
}
Actualizar un Producto

Método: PUT

URL: http://localhost:5000/api/productos/{id}

Body (JSON):

json
Copiar código
{
  "nombre": "Producto Actualizado",
  "descripcion": "Descripción actualizada",
  "precio": 60.00,
  "stock": 15
}
Eliminar un Producto

Método: DELETE
URL: http://localhost:5000/api/productos/{id}
Pedidos
Obtener Lista de Pedidos

Método: GET
URL: http://localhost:5000/api/pedidos
Crear un Nuevo Pedido

Método: POST

URL: http://localhost:5000/api/pedidos

Body (JSON):

json
Copiar código
{
  "clienteID": 1,
  "fechaPedido": "2024-09-10T10:00:00",
  "estado": "Pendiente",
  "fechaEntrega": "2024-09-15T10:00:00",
  "total": 200.00
}
Actualizar un Pedido

Método: PUT

URL: http://localhost:5000/api/pedidos/{id}

Body (JSON):

json
Copiar código
{
  "estado": "Enviado"
}
Eliminar un Pedido

Método: DELETE
URL: http://localhost:5000/api/pedidos/{id}
Entregas
Obtener Lista de Entregas

Método: GET
URL: http://localhost:5000/api/entregas
Crear una Nueva Entrega

Método: POST

URL: http://localhost:5000/api/entregas

Body (JSON):

json
Copiar código
{
  "pedidoID": 1,
  "fechaEntrega": "2024-09-10T10:00:00",
  "estado": "En tránsito"
}
Actualizar una Entrega

Método: PUT

URL: http://localhost:5000/api/entregas/{id}

Body (JSON):

json
Copiar código
{
  "estado": "Completado"
}
Eliminar una Entrega

Método: DELETE
URL: http://localhost:5000/api/entregas/{id}
