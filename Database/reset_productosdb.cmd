@echo off
REM Reinicia productosdb conservando los 3 primeros productos (ver reset_productosdb.sql)
REM Cambia SERVIDOR si tu instancia no se llama "Mateo" (ej: localhost o .\SQLEXPRESS)
set SERVIDOR=Mateo

sqlcmd -S %SERVIDOR% -E -C -b -f 65001 -i "%~dp0reset_productosdb.sql"
if errorlevel 1 (
    echo.
    echo Hubo un error. La base de datos NO fue modificada.
    pause
    exit /b 1
)

echo.
echo Listo: productosdb quedo con 3 productos.
pause
