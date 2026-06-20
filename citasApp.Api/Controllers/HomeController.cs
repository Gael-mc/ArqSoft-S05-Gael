using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Api.Controllers
{
    [ApiController]
    [Route("/")] // Esto hace que responda en la raíz
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok(new { mensaje = "La API de Citas está funcionando correctamente" });
    }
}