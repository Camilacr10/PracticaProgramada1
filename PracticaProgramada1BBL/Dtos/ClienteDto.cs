using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaProgramada1BLL.Dtos
{
    public class ClienteDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La edad es obligatoria")]
        [Range(18, 99, ErrorMessage = "La edad debe estar entre 18 y 99")]
        public int? Edad { get; set; }

        // Lista para hacer la relación de un cliente tiene varios teléfonos
        public List<TelefonoDto> Telefonos { get; set; } = new List<TelefonoDto>();
    }

    //Clase para representar los teléfonos asociados a un cliente
    public class TelefonoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El número de teléfono es obligatorio")]
        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "El formato del teléfono debe ser ####-####")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "El tipo de teléfono es obligatorio")]
        public string Tipo { get; set; } // "Móvil", "Casa", "Trabajo"
    }
}