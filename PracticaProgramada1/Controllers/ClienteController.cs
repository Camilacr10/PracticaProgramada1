using Microsoft.AspNetCore.Mvc;
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

        // GET: Cliente
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

        // GET: Cliente/Create
        public IActionResult Create()
        {
            var model = new ClienteDto
            {
                Telefonos = new List<TelefonoDto> { new TelefonoDto() } // para Telefonos[0] en la vista
            };
            return View(model);
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteDto cliente)
        {
            // Garantiza que la lista exista para re-render en caso de error
            cliente.Telefonos ??= new List<TelefonoDto>();

            if (!ModelState.IsValid)
            {
                // Si no hay slot para la vista, agrega uno
                if (cliente.Telefonos.Count == 0) cliente.Telefonos.Add(new TelefonoDto());
                return View(cliente);
            }

            var respuesta = await _clientesServicio.AgregarClienteAsync(cliente);
            if (!respuesta.EsError)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, respuesta.Mensaje ?? "No se pudo agregar el cliente.");
            if (cliente.Telefonos.Count == 0) cliente.Telefonos.Add(new TelefonoDto());
            return View(cliente);
        }


        //GET: Cliente/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var respuesta = await _clientesServicio.ObtenerClientePorIdAsync(id);
            if (respuesta.EsError)
            {
                return NotFound();
            }
            return View(respuesta.Data);
        }

        //POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClienteDto clienteDto)
        {
            if (id != clienteDto.Id)
                return NotFound();

            clienteDto.Telefonos ??= new List<TelefonoDto>();

            if (!ModelState.IsValid)
            {
                if (clienteDto.Telefonos.Count == 0)
                    clienteDto.Telefonos.Add(new TelefonoDto());
                return View(clienteDto);
            }

            var clienteOriginal = await _clientesServicio.ObtenerClientePorIdAsync(id);
            if (!clienteOriginal.EsError && clienteOriginal.Data != null)
            {
                clienteOriginal.Data.Telefonos ??= new List<TelefonoDto>();

                int maxId = clienteOriginal.Data.Telefonos.Any()
                    ? clienteOriginal.Data.Telefonos.Max(t => t.Id)
                    : 0;

                foreach (var telefono in clienteDto.Telefonos)
                {
                    var existente = clienteOriginal.Data.Telefonos
                        .FirstOrDefault(t => t.Id == telefono.Id);

                    if (existente != null)
                    {
                        telefono.Id = existente.Id;
                    }
                    else
                    {
                        maxId++;
                        telefono.Id = maxId;
                    }
                }
            }

            var respuesta = await _clientesServicio.ActualizarClienteAsync(clienteDto);

            if (!respuesta.EsError)
            {
                TempData["Success"] = "Cliente actualizado exitosamente.";
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, respuesta.Mensaje ?? "No se pudo actualizar el cliente.");

            if (clienteDto.Telefonos.Count == 0)
                clienteDto.Telefonos.Add(new TelefonoDto());

            return View(clienteDto);
        }


        //GET: Cliente/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var respuesta = await _clientesServicio.ObtenerClientePorIdAsync(id);
            if (respuesta.EsError)
            {
                return NotFound();
            }
            return View(respuesta.Data);
        }

        //POST: Cliente/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var respuesta = await _clientesServicio.EliminarClienteAsync(id);
            if (!respuesta.EsError)
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(string.Empty, respuesta.Mensaje);
            return View("Delete", respuesta.Data);
        }

    }

}
