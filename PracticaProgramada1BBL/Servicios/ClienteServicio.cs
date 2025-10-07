using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PracticaProgramada1BBL.Dtos;
using PracticaProgramada1BLL.Dtos;
using PracticaProgramada1DAL.Entidades;
using PracticaProgramada1DAL.Repositorios;

namespace PracticaProgramada1BBL.Servicios
{
    public class ClienteServicio : IClientesServicio
    {
        //Inyección de dependencias
        private readonly IClientesRepositorio _clientesRepositorio;
        private readonly IMapper _mapper;

        public ClienteServicio(IClientesRepositorio clientesRepositorio, IMapper mapper)
        {
            _clientesRepositorio = clientesRepositorio;
            _mapper = mapper;
        }

        public async Task<CustomResponse<ClienteDto>> ActualizarClienteAsync(ClienteDto clienteDto)
        {
            var respuesta = new CustomResponse<ClienteDto>();
            var cliente = _mapper.Map<Cliente>(clienteDto);

            if (!await _clientesRepositorio.ActualizarClienteAsync(cliente))
            {
                respuesta.EsError = true;
                respuesta.Mensaje = "No se pudo actualizar el cliente";
                return respuesta;
            }

            return respuesta;
        }

        public async Task<CustomResponse<ClienteDto>> EliminarClienteAsync(int id)
        {
            var respuesta = new CustomResponse<ClienteDto>();

            if (!await _clientesRepositorio.EliminarClienteAsync(id))
            {
                respuesta.EsError = true;
                respuesta.Mensaje = "No se pudo eliminar el cliente";
                return respuesta;
            }

            return respuesta;
        }

        public async Task<CustomResponse<ClienteDto>> AgregarClienteAsync(ClienteDto clienteDto)
        {
            var respuesta = new CustomResponse<ClienteDto>();

            // El repositorio me indica que si pudo o no pudo agregar el cliente
            if (!await _clientesRepositorio.AgregarClienteAsync(_mapper.Map<Cliente>(clienteDto)))
            {
                respuesta.EsError = true;
                respuesta.Mensaje = "No se pudo agregar el cliente";
                return respuesta;
            }

            return respuesta;
        }

        public async Task<CustomResponse<ClienteDto>> ObtenerClientePorIdAsync(int id)
        {
            var respuesta = new CustomResponse<ClienteDto>();

            var cliente = await _clientesRepositorio.ObtenerClientePorIdAsync(id);

            var validaciones = validar(cliente);
            if (validaciones.EsError)
            {
                return validaciones;
            }

            respuesta.Data = _mapper.Map<ClienteDto>(cliente);
            return respuesta;
        }

        public async Task<CustomResponse<List<ClienteDto>>> ObtenerClientesAsync()
        {
            var respuesta = new CustomResponse<List<ClienteDto>>();
            var clientes = await _clientesRepositorio.ObtenerClientesAsync();
            var clientesDto = _mapper.Map<List<ClienteDto>>(clientes);
            respuesta.Data = clientesDto;
            return respuesta;
        }

        private CustomResponse<ClienteDto> validar(Cliente cliente)
        {
            var respuesta = new CustomResponse<ClienteDto>();

            if (cliente == null)
            {
                respuesta.EsError = true;
                respuesta.Mensaje = "Cliente no encontrado";
                return respuesta;
            }


            //Validación adicional por teléfono
            if (cliente.Telefonos == null || cliente.Telefonos.Count == 0)
            {
                respuesta.EsError = true;
                respuesta.Mensaje = "El cliente debe tener al menos un número de teléfono";
                return respuesta;
            }

            return respuesta;
        }
    }
}