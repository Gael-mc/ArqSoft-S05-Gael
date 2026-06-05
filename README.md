# 🏥 CitasApp

Sistema web de gestión de citas médicas desarrollado con **ASP.NET Core MVC**, arquitectura en capas con repositorios JSON y diseño dark moderno.

---

## 📋 Descripción

CitasApp es una aplicación web que permite gestionar pacientes, médicos y citas médicas desde un panel centralizado. Utiliza archivos JSON como fuente de datos, siguiendo el patrón de repositorio con interfaces para desacoplar la lógica de negocio del acceso a datos.

---

## 🚀 Tecnologías utilizadas

- **ASP.NET Core MVC** — Framework principal
- **C#** — Lenguaje de programación
- **Bootstrap 5** — Estilos base
- **CSS personalizado** — Tema dark con variables CSS
- **JSON** — Almacenamiento de datos
- **Google Fonts** — Tipografías Syne y DM Sans
- **Git & GitHub** — Control de versiones

---

## 🗂️ Estructura del proyecto

```
CitasApp/
├── Controllers/
│   ├── CitaController.cs
│   ├── MedicoController.cs
│   └── PacienteController.cs
├── Data/
│   ├── citas.json
│   ├── medicos.json
│   └── pacientes.json
├── Interfaces/
│   ├── ICitaRepository.cs
│   ├── IMedicoRepository.cs
│   └── IPacienteRepository.cs
├── Models/
│   ├── Cita.cs
│   ├── Medico.cs
│   └── Paciente.cs
├── Repositories/
│   ├── JsonCitaRepository.cs
│   ├── JsonMedicoRepository.cs
│   └── JsonPacienteRepository.cs
├── Views/
│   ├── Cita/
│   ├── Medico/
│   ├── Paciente/
│   ├── Home/
│   └── Shared/
│       └── _Layout.cshtml
└── wwwroot/
    └── css/
        └── site.css
```

---

## 📸 Capturas de pantalla

### Panel Principal
<img width="1918" height="1078" alt="Screenshot 2026-06-05 110207" src="https://github.com/user-attachments/assets/7e91bc88-832e-4323-9904-868effb1ad72" />

> Vista de inicio con acceso rápido a Pacientes, Médicos y Citas.

---

### Pacientes registrados
<img width="1895" height="1066" alt="Screenshot 2026-06-05 110216" src="https://github.com/user-attachments/assets/4d9fe97f-e025-490a-bfa8-6acd2983e5b2" />

> Lista de pacientes con nombre, email, teléfono y acceso al detalle.

---

### Médicos disponibles
<img width="1912" height="1078" alt="Screenshot 2026-06-05 110223" src="https://github.com/user-attachments/assets/a5f83dd0-c999-44f9-ac68-08a6da8b011c" />

> Directorio de médicos con nombre y especialidad.

---

### Agenda de citas
<img width="1912" height="1075" alt="Screenshot 2026-06-05 110232" src="https://github.com/user-attachments/assets/75523012-0eb7-4fc4-87c8-09ee0362547b" />

> Tabla de citas con fecha, hora, paciente, médico, motivo y estado.

---

## ⚙️ Instalación y ejecución

1. Clona el repositorio:
```bash
git clone https://github.com/tu-usuario/CitasApp.git
cd CitasApp
```

2. Restaura las dependencias:
```bash
dotnet restore
```

3. Ejecuta la aplicación:
```bash
dotnet run
```

4. Abre en el navegador:
```
https://localhost:44300
```

---

## 🧱 Arquitectura

El proyecto sigue el patrón **Repositorio** con inyección de dependencias:

```
Controller → Interface → Repository → JSON File
```

Los repositorios se registran en `Program.cs`:
```csharp
builder.Services.AddScoped<ICitaRepository, JsonCitaRepository>();
builder.Services.AddScoped<IMedicoRepository, JsonMedicoRepository>();
builder.Services.AddScoped<IPacienteRepository, JsonPacienteRepository>();
```

---

## 🤖 Cláusula de uso de Inteligencia Artificial

Durante el desarrollo de este proyecto se utilizó **Claude (Anthropic)** como herramienta de asistencia para:

- Generación y corrección de código en C# (modelos, interfaces, repositorios y controladores)
- Depuración de errores como `InvalidOperationException` por servicios no registrados
- Diseño y personalización del CSS con tema dark
- Redacción de mensajes de commit siguiendo la convención **Conventional Commits**
- Estructura y redacción de este README

El uso de IA fue supervisado en todo momento. Todo el código generado fue revisado, comprendido e integrado manualmente por el desarrollador. La IA actuó como asistente, no como reemplazo del proceso de aprendizaje.

---

## 👤 Autor

**GAEL MAGAÑA** — Estudiante de desarrollo de software  
© 2026 CitasApp
