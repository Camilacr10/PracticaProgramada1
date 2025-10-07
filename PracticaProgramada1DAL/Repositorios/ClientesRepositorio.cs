using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaProgramada1DAL.Entidades;
using static PracticaProgramada1DAL.Entidades.Cliente;

namespace PracticaProgramada1DAL.Repositorios
{
    public class ClientesRepositorio : IClientesRepositorio
    {
        private List<Cliente> clientes = new List<Cliente>()
        {
            new Cliente {
                Id = 1, Nombre = "Ana", Apellido = "Gómez", Edad = 28,
                Telefonos = new List<Telefono> {
                    new Telefono { Id = 1, Numero = "8888-9999", Tipo = "Móvil" },
                    new Telefono { Id = 2, Numero = "2222-3333", Tipo = "Casa" }
                }
            },
            new Cliente {
                Id = 2, Nombre = "Diego", Apellido = "Vega", Edad = 35,
                Telefonos = new List<Telefono> {
                    new Telefono { Id = 3, Numero = "7777-6666", Tipo = "Trabajo" }
                }
            },
            new Cliente {
                Id = 3, Nombre = "Carla", Apellido = "Loaiza", Edad = 31,
                Telefonos = new List<Telefono> ()
            }
        };

        public async Task<bool> ActualizarClienteAsync(Cliente cliente)
        {
            var clienteExistente = clientes.FirstOrDefault(c => c.Id == cliente.Id);
            clienteExistente.Nombre = cliente.Nombre;
            clienteExistente.Apellido = cliente.Apellido;
            clienteExistente.Edad = cliente.Edad;
            clienteExistente.Telefonos = cliente.Telefonos;

            return true;
        }

        public async Task<bool> AgregarClienteAsync(Cliente cliente)
        {
            cliente.Id = clientes.Any() ? clientes.Max(c => c.Id) + 1 : 1;
            clientes.Add(cliente);
            return true;
        }

        public async Task<bool> EliminarClienteAsync(int id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                clientes.Remove(cliente);
                return true;
            }
            return false;
        }

        public async Task<Cliente> ObtenerClientePorIdAsync(int id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            return cliente;
        }

        public async Task<List<Cliente>> ObtenerClientesAsync()
        {
            return clientes;
        }
    }
}
