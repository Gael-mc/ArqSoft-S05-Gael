# Arquitectura de CitasApp — Modelo C4

Este documento describe la arquitectura de **CitasApp** usando el Modelo C4, en tres niveles de detalle progresivo. Todos los diagramas están escritos como código (Mermaid) para que se versionen junto con el resto del repositorio.

---

## Nivel 1 — Contexto

**¿Para quién es este diagrama?** Para cualquier persona sin conocimiento técnico (un stakeholder, un cliente, un compañero de otro equipo) que quiere entender qué hace el sistema y quién lo usa, sin entrar en detalles de tecnología.

**¿Qué pregunta responde?** *¿Qué es CitasApp y quién interactúa con él?*

```mermaid
graph TD
    Cliente([Cliente / Paciente])
    Admin([Administrador / Recepcionista])

    subgraph Sistema
        CitasApp[CitasApp\nSistema de gestión de citas]
    end

    Cliente -->|Agenda, consulta y cancela citas| CitasApp
    Admin -->|Administra agenda y disponibilidad| CitasApp
```




## Nivel 2 — Contenedores

**¿Para quién es este diagrama?** Para arquitectos de software o desarrolladores que necesitan entender las piezas técnicas grandes del sistema (aplicaciones, servicios, bases de datos) y cómo se comunican entre sí, sin ver el código interno de cada una.

**¿Qué pregunta responde?** *¿Cuáles son las piezas técnicas principales de CitasApp y cómo interactúan?*

```mermaid
graph TD
    Cliente([Cliente / Paciente])
    Admin([Administrador])

    subgraph CitasApp["CitasApp - Sistema"]
        Web[CitasApp.web\nASP.NET Core MVC\nControllers + Views]
        Domain[CitasApp.Domain\nEntidades, Interfaces\ny reglas de negocio]
        Infra[CitasApp.Infrastructure\nRepositorios\nAcceso a datos]
        Data[(Almacenamiento\nJSON / futuro RDS)]
    end

    Cliente -->|HTTP/HTTPS| Web
    Admin -->|HTTP/HTTPS| Web
    Web -->|Usa entidades e interfaces| Domain
    Web -->|Invoca servicios/repositorios| Infra
    Infra -->|Implementa interfaces de| Domain
    Infra -->|Lee/Escribe| Data