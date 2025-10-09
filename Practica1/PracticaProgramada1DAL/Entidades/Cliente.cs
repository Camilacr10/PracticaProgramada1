using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaProgramada1DAL.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

    public class Telefono
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; } // Como "Casa", "Trabajo", "Móvil"
    }

        // Lista para hacer la relación de un cliente tiene varios teléfonos
        public List<Telefono> Telefonos { get; set; } = new List<Telefono>();
    }
}
