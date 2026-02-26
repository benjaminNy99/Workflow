# Workflow

## Base de datos

Prerrequisitos:
- Tener instalado el SDK de .NET.
- Instalar la herramienta `dotnet-ef` (global o local).
- Asegurar que el archivo `dbworkflow.db` exista en la raíz del proyecto.

Cuándo usarlo:
- Cuando se actualice el esquema de la base de datos y se necesite regenerar las entidades.

Comando para generar el modelo desde SQLite:

```bash
dotnet ef dbcontext scaffold "Data Source=dbworkflow.db" Microsoft.EntityFrameworkCore.Sqlite -o Models -c Context --use-database-names --no-pluralize --no-onconfiguring --force
```
