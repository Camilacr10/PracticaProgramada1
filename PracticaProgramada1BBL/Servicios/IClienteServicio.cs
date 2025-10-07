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
    public interface IClientesServicio
    {
        Task<CustomResponse<ClienteDto>> ObtenerClientePorIdAsync(int id);
        Task<CustomResponse<List<ClienteDto>>> ObtenerClientesAsync();
        Task<CustomResponse<ClienteDto>> AgregarClienteAsync(ClienteDto clienteDto);
        Task<CustomResponse<ClienteDto>> ActualizarClienteAsync(ClienteDto clienteDto);
        Task<CustomResponse<ClienteDto>> EliminarClienteAsync(int id);
    }
}