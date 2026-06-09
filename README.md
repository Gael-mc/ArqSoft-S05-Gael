# CitasApp

Aplicación web para la gestión de citas médicas desarrollada con ASP.NET Core MVC (.NET 10).

## Descripción General

El proyecto sigue el enfoque de Arquitectura Hexagonal (Ports & Adapters), permitiendo una clara separación de responsabilidades y facilitando el mantenimiento, la escalabilidad y el reemplazo de componentes sin afectar la lógica principal del sistema.

## Estructura del Proyecto

La solución está organizada en cuatro capas principales:

* **CitasApp.Domain:** contiene las entidades, reglas de negocio e interfaces principales del sistema.
* **CitasApp.Application:** administra los casos de uso y coordina la comunicación entre las diferentes capas.
* **CitasApp.Infrastructure:** implementa los mecanismos de almacenamiento de datos mediante repositorios JSON y en memoria.
* **CitasApp.Web:** incluye la interfaz MVC, controladores, vistas y configuración de la aplicación.

## Relación entre Capas

Web → Application → Domain ← Infrastructure

## Funcionalidades

### Pacientes

* Consulta de pacientes registrados.
* Visualización de información detallada de cada paciente.

### Médicos

* Listado de médicos disponibles.
* Consulta de datos específicos de cada profesional.

### Citas

* Visualización completa de la agenda médica.
* Filtrado de citas por paciente.

## Almacenamiento de Datos

La información se almacena en archivos JSON ubicados en:

`CitasApp.Web/data/`

Archivos utilizados:

* `pacientes.json`
* `medicos.json`
* `citas.json`

Además, se incluye una implementación de repositorio en memoria para demostrar la flexibilidad de la arquitectura y el intercambio de adaptadores.

## Rutas Principales

* `/Paciente` → listado de pacientes.
* `/Medico` → listado de médicos.
* `/Cita` → agenda general de citas.
* `/Cita/PorPaciente?pacienteId=1` → consulta de citas asociadas a un paciente específico.

## Requisitos

* .NET 10.0
* Visual Studio 2022

## Ramas del Repositorio

* **main:** versión estable con persistencia mediante archivos JSON.
* **hexagonal:** implementación completa utilizando Arquitectura Hexagonal distribuida en múltiples proyectos.
