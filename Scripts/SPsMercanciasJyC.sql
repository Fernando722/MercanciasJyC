-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Luis Fernando Fernández Muñoz>
-- Create date: <Create 14/09/2024>
-- Description:	<Description, Procedimientos almacenados con la logica de negocio para Mercancias JyC>
-- =============================================
CREATE PROCEDURE CrearProducto
    @Nombre NVARCHAR(100),
    @Descripcion NVARCHAR(200),
    @Precio DECIMAL(18, 2),
    @Stock INT
AS
BEGIN
    INSERT INTO Productos (Nombre, Descripcion, Precio, Stock)
    VALUES (@Nombre, @Descripcion, @Precio, @Stock);
END
GO

CREATE PROCEDURE ObtenerProductos
AS
BEGIN
    SELECT * FROM Productos;
END

CREATE PROCEDURE ActualizarProducto
    @ProductoID INT,
    @Nombre NVARCHAR(100),
    @Descripcion NVARCHAR(200),
    @Precio DECIMAL(18, 2),
    @Stock INT
AS
BEGIN
    UPDATE Productos
    SET Nombre = @Nombre,
        Descripcion = @Descripcion,
        Precio = @Precio,
        Stock = @Stock
    WHERE ProductoID = @ProductoID;
END

CREATE PROCEDURE EliminarProducto
    @ProductoID INT
AS
BEGIN
    DELETE FROM Productos
    WHERE ProductoID = @ProductoID;
END

--Pedidos

CREATE PROCEDURE CrearPedido
    @ClienteID INT,
    @FechaPedido DATETIME,
    @Estado NVARCHAR(50),
    @FechaEntrega DATETIME,
    @Total DECIMAL(18, 2)
AS
BEGIN
    DECLARE @DiaEntrega INT;
    DECLARE @FechaMin DATETIME;
    DECLARE @FechaMax DATETIME;

    -- Determinar el día de la semana para la fecha de entrega
    SET @DiaEntrega = DATEPART(WEEKDAY, @FechaEntrega);

    -- Calcular el rango de fechas permitido para la recepción del pedido
    IF @DiaEntrega = 2 -- Lunes
    BEGIN
        SET @FechaMin = DATEADD(DAY, -3, DATEADD(HOUR, 12, DATEADD(DAY, DATEDIFF(DAY, 0, @FechaEntrega), 0)));
        SET @FechaMax = DATEADD(DAY, -2, DATEADD(HOUR, 12, DATEADD(DAY, DATEDIFF(DAY, 0, @FechaEntrega), 0)));
    END
    ELSE IF @DiaEntrega = 3 -- Martes
    BEGIN
        SET @FechaMin = DATEADD(DAY, -2, DATEADD(HOUR, 12, DATEADD(DAY, DATEDIFF(DAY, 0, @FechaEntrega), 0)));
        SET @FechaMax = DATEADD(DAY, -1, DATEADD(HOUR, 12, DATEADD(DAY, DATEDIFF(DAY, 0, @FechaEntrega), 0)));
    END
    ELSE IF @DiaEntrega = 4 -- Miércoles
    BEGIN
        SET @FechaMin = DATEADD(DAY, -1, DATEADD(HOUR, 12, DATEADD(DAY, DATEDIFF(DAY, 0, @FechaEntrega), 0)));
        SET @FechaMax = DATEADD(DAY, 0, DATEADD(HOUR, 12, DATEADD(DAY, DATEDIFF(DAY, 0, @FechaEntrega), 0)));
    END
    ELSE IF @DiaEntrega = 5 -- Jueves
    BEGIN
        SET @FechaMin = DATEADD(DAY, 0, DATEADD(HOUR, 12, DATEADD(DAY, DATEDIFF(DAY, 0, @FechaEntrega), 0)));
        SET @FechaMax = DATEADD(DAY, 1, DATEADD(HOUR, 12, DATEADD(DAY, DATEDIFF(DAY, 0, @FechaEntrega), 0)));
    END
    ELSE IF @DiaEntrega = 6 -- Viernes
    BEGIN
        SET @FechaMin = DATEADD(DAY, 1, DATEADD(HOUR, 12, DATEADD(DAY, DATEDIFF(DAY, 0, @FechaEntrega), 0)));
        SET @FechaMax = DATEADD(DAY, 2, DATEADD(HOUR, 12, DATEADD(DAY, DATEDIFF(DAY, 0, @FechaEntrega), 0)));
    END
    ELSE IF @DiaEntrega = 7 -- Sábado
    BEGIN
        SET @FechaMin = DATEADD(DAY, 2, DATEADD(HOUR, 12, DATEADD(DAY, DATEDIFF(DAY, 0, @FechaEntrega), 0)));
        SET @FechaMax = DATEADD(DAY, 3, DATEADD(HOUR, 12, DATEADD(DAY, DATEDIFF(DAY, 0, @FechaEntrega), 0)));
    END
    ELSE
    BEGIN
        -- No se permite la entrega en domingo
        RAISERROR('No se permite la entrega en domingo.', 16, 1);
        RETURN;
    END

    -- Verificar si la fecha del pedido está dentro del rango permitido
    IF @FechaPedido < @FechaMin OR @FechaPedido > @FechaMax
    BEGIN
        RAISERROR('El pedido no puede ser recibido en la fecha especificada.', 16, 1);
        RETURN;
    END

    -
    INSERT INTO Pedidos (ClienteID, FechaPedido, Estado, FechaEntrega, Total)
    VALUES (@ClienteID, @FechaPedido, @Estado, @FechaEntrega, @Total);
END

CREATE PROCEDURE ObtenerPedidos
AS
BEGIN
    SELECT * FROM Pedidos;
END

CREATE PROCEDURE EliminarPedido
    @PedidoID INT
AS
BEGIN
    DELETE FROM Pedidos
    WHERE PedidoID = @PedidoID;
END

CREATE PROCEDURE CrearEntrega
    @PedidoID INT,
    @FechaEntrega DATETIME,
    @EstadoEntrega NVARCHAR(50)
AS
BEGIN
    INSERT INTO Entregas (PedidoID, FechaEntrega, EstadoEntrega)
    VALUES (@PedidoID, @FechaEntrega, @EstadoEntrega);
END

CREATE PROCEDURE ObtenerEntregas
AS
BEGIN
    SELECT * FROM Entregas;
END

CREATE PROCEDURE EliminarEntrega
    @EntregaID INT
AS
BEGIN
    DELETE FROM Entregas
    WHERE EntregaID = @EntregaID;
END