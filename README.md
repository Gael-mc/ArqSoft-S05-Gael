Markdown
# 🗺️ CitasApp — API Services Branch

Esta rama contiene la capa de backend pura y los servicios REST de **CitasApp**, optimizada para la exposición de endpoints e integración con front-ends distribuidos independientes (como interfaces HTML externas).

---

## 📡 Características de la Rama Api

* **Aislamiento Total de Assets:** Se desactivó el sistema de Web Roots estáticos locales (`<EnableStaticWebAssets>false</EnableStaticWebAssets>`) para permitir que la API corra de forma óptima sin requerir carpetas internas físicas como `wwwroot`.
* **CORS Global Abierto:** Configurado con una política `"PermitirTodo"` para permitir el acceso asíncrono desde orígenes cruzados remotos y locales (`file://`).
* **Arquitectura en Red:** Diseñado para responder en el puerto HTTP dedicado `62548`.

---

## 📂 Endpoints Implementados

### 🧮 Controlador de Calculadora (`/api/calculadora`)

| Endpoint | Parámetros | Tipo | Descripción |
| :--- | :--- | :--- | :--- |
| `/sumar` | `a` (int), `b` (int) | GET | Retorna la suma de dos variables |
| `/restar` | `a` (int), `b` (int) | GET | Retorna la diferencia de dos variables |
| `/multiplicar` | `a` (int), `b` (int) | GET | Retorna el producto |
| `/dividir` | `a` (int), `b` (int) | GET | Retorna el cociente flotante |

---

## 🛠️ Configuración de Program.cs para Servicios Básicos

El motor de inyección de esta rama está optimizado para resolver dependencias a nivel de capa lógica de la aplicación directamente al almacenamiento JSON persistido en la infraestructura:

```csharp
builder.Services.AddCors(options => {
    options.AddPolicy("PermitirTodo", policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddScoped<IPacienteRepository, JsonPacienteRepository>();
builder.Services.AddScoped<IMedicoRepository, JsonMedicoRepository>();
builder.Services.AddScoped<ICitaRepository, JsonCitaRepository>();
⚠️ Solución a Errores Comunes de Integración en esta Rama
1. DirectoryNotFoundException en el Builder
Si el runtime intenta mapear activos estáticos inexistentes, el archivo .csproj de esta rama tiene la instrucción que soluciona el problema de raíz:

XML
<EnableStaticWebAssets>false</EnableStaticWebAssets>
2. Navegador bloquea petición con "Failed to Fetch" (Error de conexión)
Ocurre porque los navegadores modernos restringen accesos desde archivos locales del disco duro (file:///) a servidores de red local (http://localhost). Para evadir la restricción e integrar con éxito el HTML externo, se debe ejecutar la sesión del navegador deshabilitando las políticas de origen:

Bash
msedge.exe --user-data-dir="C:\temp" --disable-web-security
🤖 Cláusula de uso de Inteligencia Artificial
Durante el desarrollo de esta rama se utilizó Gemini (Google) como herramienta de asistencia avanzada para:

Resolución de errores en tiempo de ejecución en la carga del WebApplicationBuilder.

Desacoplamiento de archivos estáticos del core para despliegues dinámicos sin carpetas raíz locales.

Diseño e inyección de políticas permisivas Cross-Origin Resource Sharing (CORS).

Estructuración de este documento técnico.

👤 Autor
GAEL MAGAÑA — Estudiante de desarrollo de software

Branch api — © 2026
