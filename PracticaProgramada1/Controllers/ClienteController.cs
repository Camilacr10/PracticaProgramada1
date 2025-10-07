    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using PracticaProgramada1.Models;      
    using PracticaProgramada1BBL.Servicios;
    using PracticaProgramada1BLL.Dtos;

    namespace PracticaProgramada1.Controllers
    {
    public class ClienteController : Controller
    {
        private readonly ILogger<ClienteController> _logger;

        private readonly IClientesServicio _clientesServicio;

        public ClienteController(ILogger<ClienteController> logger, IClientesServicio clientesServicio)
        {
            _logger = logger;
            _clientesServicio = clientesServicio;
        }

        public async Task<IActionResult> Index()
        {
            var respuesta = await _clientesServicio.ObtenerClientesAsync();
            return View(respuesta.Data);
        }

        // GET: Cliente/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var respuesta = await _clientesServicio.ObtenerClientePorIdAsync(id);
            if (respuesta.EsError || respuesta.Data == null)
            {
                return NotFound();
            }
            return View(respuesta.Data);
        }

    }
    }