# Laboratorio 4 – CRUD de Productos con imágenes (Windows Forms + SQL Server)

Aplicación de escritorio en **C# / Windows Forms (.NET 10)** que administra un inventario de productos (folio, nombre, precio, cantidad e imagen) guardado en **SQL Server**. Sigue la estructura del Laboratorio 4 (clase `Producto`, clase `Conexion`, `Dictionary<string, object>` para insertar, `MemoryStream` para convertir imágenes), adaptada de MySQL a SQL Server.

## Funcionalidades

| Acción | Cómo funciona |
|---|---|
| **Listar** | Al abrir, `cargarProductos()` llena el `DataGridView` (con miniatura de la imagen). |
| **Búsqueda** | Filtra mientras escribes (`TextChanged`) por folio, nombre, precio o cantidad. Consulta parametrizada (`LIKE @filtro`). |
| **Seleccionar** | Clic en una fila carga sus datos e imagen en el formulario. |
| **Imagen** | Clic en el recuadro de imagen abre un `OpenFileDialog` (`.jpg .jpeg .png .bmp`, máx. 5 MB). |
| **Agregar** | Valida (`datosCorrectos`), arma el diccionario (`CargarDatosProductos`) y llama a `Conexion.InsertSeguro`. |
| **Modificar** | Actualiza el producto seleccionado (`Conexion.UpdateSeguro`). |
| **Eliminar** | Pide confirmación y borra el producto seleccionado (`Conexion.DeleteSeguro`). |
| **Limpiar** | Vacía el formulario, la imagen, la selección y la búsqueda. |
| **Salir** | Cierra la aplicación. |

### Validaciones

- **Nombre**: obligatorio, sin números, máximo 100 caracteres.
- **Precio**: decimal mayor que cero, máximo 2 decimales y hasta 99,999,999.99 (límite de `DECIMAL(10,2)`).
- **Cantidad**: entero mayor que cero.
- **Folio**: solo lectura; lo asigna la base de datos (`IDENTITY`).

## Estructura

```
Practica14-9-2026.slnx
Database/
├── 01_crear_productosdb.sql     # Crea la BD, la tabla y carga los 6 productos con imágenes
└── 02_resetear_productosdb.sql  # Borra y recrea la BD con los 3 primeros productos
Practica14-9-2026/
├── Program.cs
├── Form1.cs                # Eventos del formulario y lógica CRUD
├── Form1.Designer.cs       # Diseño de la interfaz
├── Conexion.cs             # ObtenerConexion, GetProductos, InsertSeguro, UpdateSeguro, DeleteSeguro
├── Producto.cs             # Modelo (Id, Nombre, Precio, Cantidad, Imagen byte[])
├── Validaciones.cs         # Reglas de validación de los campos
└── Iconos.cs               # Íconos de botones/recuadro dibujados con GDI+ (ImageList)
```

## Base de datos

```sql
CREATE TABLE productos (
    id       INT IDENTITY(1,1) PRIMARY KEY,
    nombre   NVARCHAR(100)  NOT NULL,
    precio   DECIMAL(10, 2) NOT NULL,
    cantidad INT            NOT NULL,
    imagen   VARBINARY(MAX) NULL      -- equivalente al LONGBLOB de MySQL
);
```

### Scripts de la base de datos (`Database/`)

1. **`01_crear_productosdb.sql`**: crea `productosdb` y la tabla `productos` si no existen y carga los **6 productos del laboratorio con sus imágenes** (solo si la tabla está vacía). Se puede ejecutar varias veces sin perder datos.
2. **`02_resetear_productosdb.sql`**: **elimina la base de datos completa**, la vuelve a crear y carga los **3 primeros productos** (Teclado, Mouse y Portátil con imagen) con folios 1, 2 y 3.

Las imágenes vienen del volcado MySQL del laboratorio convertidas a `VARBINARY(MAX)`; los productos que tenían imagen vacía (`''`) quedan con `NULL`.

Ejecutar en **SSMS** (abrir el archivo y F5) o con sqlcmd:

```bash
sqlcmd -S Mateo -E -C -f 65001 -i Database/02_resetear_productosdb.sql
```

### Cadena de conexión

En `Conexion.cs`:

```csharp
"Data Source=Mateo;Initial Catalog=productosdb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"
```

Reemplazar `Mateo` por la instancia de SQL Server (por ejemplo `localhost` o `.\SQLEXPRESS`).

## Ejecución

Abrir `Practica14-9-2026.slnx` en Visual Studio y presionar **F5**, o:

```bash
dotnet run --project Practica14-9-2026/Practica14-9-2026.csproj
```

## Tecnologías

C# / .NET 10 · Windows Forms · SQL Server · Microsoft.Data.SqlClient 7.0.3
