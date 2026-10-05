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
├── reset_productosdb.sql   # Formatea la tabla y recarga los 3 primeros productos
└── reset_productosdb.cmd   # Ejecuta el script con sqlcmd (doble clic)
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

### Reiniciar la base de datos

`Database/reset_productosdb.sql` crea `productosdb` si no existe, guarda los **3 primeros productos actuales** (por `id`, con su imagen), recrea la tabla y los vuelve a insertar con folios 1, 2 y 3. Si hay menos de 3, completa con los datos de ejemplo del laboratorio. Corre en una transacción: si falla, no cambia nada.

- Desde **SSMS**: abrir el archivo y ejecutar (F5).
- Desde Windows: doble clic en `reset_productosdb.cmd` (editar `SERVIDOR` si la instancia no es `Mateo`).

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
