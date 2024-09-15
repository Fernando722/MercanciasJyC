--Creacion DB
CREATE DATABASE MercanciasJyC
GO

USE MercanciasJyC

--Creación de tablas correspondientes a Cliente, Producto, Pedido, DetallePedido y Entrega

CREATE TABLE Cliente (
    ClienteID INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100) NOT NULL,
    Dirección NVARCHAR(200),
    Teléfono NVARCHAR(20),
    Email NVARCHAR(100)
);

CREATE TABLE Producto (
    ProductoID INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripción NVARCHAR(200),
    Precio DECIMAL(10, 2) NOT NULL,
    Stock INT NOT NULL
);

CREATE TABLE Pedido (
    PedidoID INT PRIMARY KEY IDENTITY,
    ClienteID INT NOT NULL,
    FechaPedido DATETIME NOT NULL,
    Estado NVARCHAR(50),
    FechaEntrega DATETIME,
    Total DECIMAL(10, 2),
    FOREIGN KEY (ClienteID) REFERENCES Cliente(ClienteID)
);


CREATE TABLE DetallePedido (
    DetalleID INT PRIMARY KEY IDENTITY,
    PedidoID INT NOT NULL,
    ProductoID INT NOT NULL,
    Cantidad INT NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (PedidoID) REFERENCES Pedido(PedidoID),
    FOREIGN KEY (ProductoID) REFERENCES Producto(ProductoID)
);


CREATE TABLE Entrega (
    EntregaID INT PRIMARY KEY IDENTITY,
    PedidoID INT NOT NULL,
    FechaEntrega DATETIME NOT NULL,
    EstadoEntrega NVARCHAR(50),
    FOREIGN KEY (PedidoID) REFERENCES Pedido(PedidoID)
);


