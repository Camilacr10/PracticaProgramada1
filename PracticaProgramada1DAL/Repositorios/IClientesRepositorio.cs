using PracticaProgramada1DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaProgramada1DAL.Repositorios
{
    public interface IClientesRepositorio
    {
        Task<List<Cliente>> ObtenerClientesAsync();
        Task<Cliente> ObtenerClientePorIdAsync(int id);
        Task<bool> AgregarClienteAsync(Cliente cliente);
        Task<bool> ActualizarClienteAsync(Cliente cliente);
        Task<bool> EliminarClienteAsync(int id);
    }
}
