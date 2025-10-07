using AutoMapper;
using PracticaProgramada1BLL.Dtos;
using PracticaProgramada1DAL.Entidades;
using static PracticaProgramada1DAL.Entidades.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaProgramada1BBL.Mapeos
{
    public class MapeoClase : Profile
    {
        public MapeoClase()
        {
            // Mapeo Cliente - ClienteDto
            CreateMap<Cliente, ClienteDto>();
            CreateMap<ClienteDto, Cliente>();

            // Mapeo Telefono - TelefonoDto
            CreateMap<Telefono, TelefonoDto>();
            CreateMap<TelefonoDto, Telefono>();
        }
    }
}