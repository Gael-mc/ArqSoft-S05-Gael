# CitasApp — Documentación de Arquitectura (C4 Model)

Esta rama (`diagramas`) contiene la documentación de arquitectura del proyecto **CitasApp**, modelada con el **Modelo C4** en sus primeros tres niveles: Contexto, Contenedores y Componentes.

## Objetivo

Documentar la arquitectura completa del proyecto individual usando el Modelo C4, versionada como código (Mermaid) dentro del propio repositorio, en lugar de imágenes sueltas o diagramas externos.

## Contenido

| Archivo | Descripción |
|---|---|
| [`docs/c4-diagrams.md`](./docs/c4-diagrams.md) | Los tres niveles de diagramas C4 (Contexto, Contenedores, Componentes), cada uno con una nota sobre para quién es y qué pregunta responde. |

## Niveles documentados

- **Nivel 1 — Contexto**: quién usa CitasApp y qué es el sistema, en términos simples (sin tecnicismos).
- **Nivel 2 — Contenedores**: las piezas técnicas grandes del sistema (`CitasApp.web`, `CitasApp.Domain`, `CitasApp.Infrastructure`, almacenamiento de datos) y cómo se comunican entre sí.
- **Nivel 3 — Componentes**: el detalle interno de la pieza principal (`CitasApp.web`), incluyendo controladores, interfaces y el patrón Repository ya implementado en el proyecto.

## Estructura del proyecto (referencia)

```
CitasApp/
├── CitasApp.Domain/          # Entidades, interfaces y reglas de negocio
├── CitasApp.Infrastructure/  # Repositorios e implementación de acceso a datos
└── CitasApp.web/             # Controllers, Views y punto de entrada (ASP.NET Core)
```

## Proceso de esta entrega

Los diagramas se agregaron en commits separados (uno por nivel) sobre esta rama, para reflejar el proceso incremental de documentación en lugar de un solo commit con todo el contenido de golpe.

## Cómo visualizar los diagramas

Los diagramas están escritos en sintaxis [Mermaid](https://mermaid.js.org/). Se renderizan automáticamente al ver el archivo `docs/c4-diagrams.md` en GitHub, o pueden previsualizarse en Visual Studio Code con la extensión "Markdown Preview Mermaid Support".
