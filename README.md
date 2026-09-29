# Laboratorio 3 – Gestión de Productos (Windows Forms + SQL Server)

Aplicación de escritorio desarrollada en **C# con Windows Forms (.NET 10)** que permite administrar un catálogo de productos almacenados en una base de datos **SQL Server**. Cada producto tiene folio, nombre, precio, cantidad e imagen.

## Funcionalidades

- **Listar productos**: al iniciar, el formulario carga todos los productos de la base de datos en un `DataGridView`, incluyendo su imagen.
- **Guardar**: inserta un nuevo producto con los datos capturados en el formulario.
- **Modificar**: actualiza un producto existente identificado por su folio.
- **Cargar imagen**: permite seleccionar una imagen (`.jpg`, `.jpeg`, `.png`, `.bmp`) y previsualizarla en un `PictureBox`. La imagen se guarda en la base de datos como PNG en formato binario.
- **Validaciones** de los datos antes de insertarlos:
  - **Folio**: debe ser un entero mayor que cero; se ajusta automáticamente al siguiente ID disponible.
  - **Nombre**: no puede estar vacío ni contener números.
  - **Precio**: debe ser un decimal mayor que cero.
  - **Cantidad**: debe ser un entero mayor que cero.

> Los botones **Eliminar** y **Limpiar** están presentes en la interfaz pero aún no tienen funcionalidad implementada.

## Estructura del proyecto

```
Practica14-9-2026.slnx
Practica14-9-2026/
├── Program.cs          # Punto de entrada de la aplicación
├── Form1.cs            # Lógica del formulario (eventos de botones y carga de datos)
├── Form1.Designer.cs   # Definición de controles de la interfaz
├── BaseDeDatos.cs      # Conexión y operaciones con SQL Server (SELECT, INSERT, UPDATE)
├── Product.cs          # Modelo de producto y conversión imagen <-> bytes
├── Validaciones.cs     # Validación de campos e imágenes
└── Practica14-9-2026.csproj
```

## Requisitos

- Windows
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server (local o en red)
- Visual Studio 2022/2026 (opcional, recomendado)
- Paquete NuGet: `Microsoft.Data.SqlClient` 7.0.3 (se restaura automáticamente)

## Configuración de la base de datos

Crear la base de datos y la tabla que utiliza la aplicación:

```sql
CREATE DATABASE productosdb;
GO

USE productosdb;
GO

CREATE TABLE productos (
    id       INT IDENTITY(1,1) PRIMARY KEY,
    nombre   NVARCHAR(100)  NOT NULL,
    precio   DECIMAL(10, 2) NOT NULL,
    cantidad INT            NOT NULL,
    imagen   VARBINARY(MAX) NULL
);
```

Luego ajustar la cadena de conexión en `BaseDeDatos.cs` según el servidor utilizado:

```csharp
const string connectionString = "Data Source=Mateo;Initial Catalog=productosdb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
```

Reemplazar `Data Source=Mateo` por el nombre de la instancia de SQL Server (por ejemplo, `localhost` o `.\SQLEXPRESS`).

## Ejecución

Desde Visual Studio, abrir `Practica14-9-2026.slnx` y ejecutar con **F5**.

O desde la terminal:

```bash
dotnet run --project Practica14-9-2026/Practica14-9-2026.csproj
```

## Tecnologías

- C# / .NET 10
- Windows Forms
- SQL Server
- Microsoft.Data.SqlClient
