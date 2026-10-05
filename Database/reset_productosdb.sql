/* =====================================================================
   reset_productosdb.sql  -  Laboratorio 4 (CRUD con imágenes)
   ---------------------------------------------------------------------
   Formatea la tabla productos y la vuelve a cargar con los 3 PRIMEROS
   registros que tiene actualmente (ordenados por id), imagen incluida.

   - Los folios quedan otra vez como 1, 2 y 3 (IDENTITY reiniciado).
   - Si la tabla no existe o tiene menos de 3 registros, se completa
     con los datos de ejemplo del laboratorio (sin imagen).
   - Todo se ejecuta en una transacción: si algo falla, la base de
     datos queda exactamente como estaba.

   Uso:  SSMS -> abrir este archivo -> Ejecutar (F5)
         o doble clic en reset_productosdb.cmd
   ===================================================================== */

SET NOCOUNT ON;
GO

IF DB_ID(N'productosdb') IS NULL
    CREATE DATABASE productosdb;
GO

USE productosdb;
GO

SET XACT_ABORT ON;

-- Variable de tabla: guarda los 3 registros mientras se recrea la tabla
DECLARE @respaldo TABLE (
    orden    INT IDENTITY(1, 1) PRIMARY KEY,
    nombre   NVARCHAR(100)  NOT NULL,
    precio   DECIMAL(10, 2) NOT NULL,
    cantidad INT            NOT NULL,
    imagen   VARBINARY(MAX) NULL
);

BEGIN TRY
    BEGIN TRANSACTION;

    -- 1) Respaldar los 3 primeros productos y borrar la tabla
    IF OBJECT_ID(N'dbo.productos', N'U') IS NOT NULL
    BEGIN
        INSERT INTO @respaldo (nombre, precio, cantidad, imagen)
        SELECT TOP (3)
               LEFT(ISNULL(CAST(nombre AS NVARCHAR(MAX)), N'(sin nombre)'), 100),
               CAST(ISNULL(precio, 0) AS DECIMAL(10, 2)),
               CAST(ISNULL(cantidad, 0) AS INT),
               imagen
        FROM dbo.productos
        ORDER BY id;

        DROP TABLE dbo.productos;
    END

    -- 2) Crear la tabla limpia
    CREATE TABLE dbo.productos (
        id       INT IDENTITY(1, 1) NOT NULL CONSTRAINT PK_productos PRIMARY KEY,
        nombre   NVARCHAR(100)  NOT NULL,
        precio   DECIMAL(10, 2) NOT NULL,
        cantidad INT            NOT NULL,
        imagen   VARBINARY(MAX) NULL
    );

    -- 3) Si había menos de 3 registros, completar con los datos de ejemplo del PDF
    DECLARE @faltan INT = 3 - (SELECT COUNT(*) FROM @respaldo);

    INSERT INTO @respaldo (nombre, precio, cantidad, imagen)
    SELECT TOP (@faltan) ejemplo.nombre, ejemplo.precio, ejemplo.cantidad, NULL
    FROM (VALUES
            (1, N'Teclado',  CAST(20.00  AS DECIMAL(10, 2)), 2),
            (2, N'Mouse',    CAST(15.70  AS DECIMAL(10, 2)), 2),
            (3, N'Portátil', CAST(700.70 AS DECIMAL(10, 2)), 2)
         ) AS ejemplo (n, nombre, precio, cantidad)
    ORDER BY ejemplo.n;

    -- 4) Volver a cargar en el mismo orden -> folios 1, 2, 3
    INSERT INTO dbo.productos (nombre, precio, cantidad, imagen)
    SELECT nombre, precio, cantidad, imagen
    FROM @respaldo
    ORDER BY orden;

    COMMIT TRANSACTION;
    PRINT N'productosdb reiniciada: 3 productos cargados.';
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    PRINT N'Error: no se modificó la base de datos.';
    THROW;
END CATCH;
GO

-- Verificación
SELECT id, nombre, precio, cantidad, DATALENGTH(imagen) AS bytes_imagen
FROM dbo.productos
ORDER BY id;
GO
