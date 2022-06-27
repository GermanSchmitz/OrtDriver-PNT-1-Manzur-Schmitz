using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrtDriver.Models
{
    public class Viaje
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Conductor")]
        public int ConductorId { get; set; }
        [Display(Name = "Conductor")]
        public Conductor Conductor { get; set; }

        [Required(ErrorMessage = "Ingrese la direccion origen")]
        [RegularExpression("^[a-zA-Z]* [0-9]*$", ErrorMessage = " La direccion origen no es valida")]
        public string Origen { get; set; }
        
        [Required(ErrorMessage = "Ingrese la direccion destino")]
        [RegularExpression("^[a-zA-Z]* [0-9]*$", ErrorMessage = "La direccion destino no es valida")]
        public string Destino { get; set; }

        [Required(ErrorMessage = "Ingrese la fecha de reserva")]
        [Display(Name = "Fecha de reserva")]
        public DateTime FechaInscripto { get; set; }

    }
}