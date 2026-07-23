# Actividad 35 — Pruebas xUnit + Pipeline CI con GitHub Actions

## Descripción

Se agregó una suite de pruebas unitarias con **xUnit** para el proyecto **CitasApp**, además de un pipeline de **Integración Continua (CI)** con **GitHub Actions** que compila y ejecuta esas pruebas automáticamente en cada `push` y en cada Pull Request.

## Rama

`actividad-35-pruebas-ci` (creada a partir de `refactorizacion-actividad-32`)

## Clases probadas

Se agregó el proyecto **CitasApp.Tests**, con pruebas siguiendo el patrón **Arrange-Act-Assert** para 3 clases del proyecto:

- **JsonMedicoRepository** — obtención de todos los médicos y búsqueda por Id.
- **JsonPacienteRepository** — obtención de todos los pacientes y búsqueda por Id.
- **JsonCitaRepository** — obtención de todas las citas, mapeo de fecha/hora, y filtrado por paciente.

Para aislar las pruebas del sistema de archivos real, se creó un doble de prueba **FakeJsonFileStore**, que implementa `IJsonFileStore` y permite inyectar datos en memoria.

## Pipeline CI

Archivo: `.github/workflows/ci.yml`

El workflow se dispara en cada `push` y `pull_request`, y ejecuta:

1. Checkout del repositorio
2. Configuración de .NET 10
3. `dotnet restore`
4. `dotnet build`
5. `dotnet test`

Si alguna prueba falla, el pipeline marca el check en rojo ❌; si todas pasan, lo marca en verde ✅.

## Evidencia

Se abrió el Pull Request **#1** (`actividad-35-pruebas-ci` → `refactorizacion-actividad-32`), donde se documentó:

- Check en verde ✅ tras la implementación inicial de las pruebas.
- Un fallo intencional provocado modificando una aserción en `JsonMedicoRepositoryTests.cs`, que hizo que el pipeline mostrara el check en rojo ❌.
- La corrección de esa prueba, regresando el pipeline a verde ✅.

## Cómo correr las pruebas localmente

```bash
dotnet test CitasApp.slnx
```
