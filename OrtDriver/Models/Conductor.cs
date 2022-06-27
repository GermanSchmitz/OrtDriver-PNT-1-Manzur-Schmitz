using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrtDriver.Models
{
    public class Conductor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConductorId { get; set; }

        [MaxLength(30), MinLength(1)]
        [Required(ErrorMessage = "Ingrese su nombre")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = " El nombre no es valido")]
        [Display(Name = "Nombre")]
        public string ConductorName { get; set; }

        [MaxLength(30), MinLength(1)]
        [Required(ErrorMessage = "Ingrese su apellido")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = " El apellido no es valido")]
        [Display(Name = "Apellido")]
        public string ConductorSurname { get; set; }

        [Required(ErrorMessage = "Ingrese su número de DNI")]
        [RegularExpression("^[\\s\\S]{7,8}$", ErrorMessage = " El número de DNI no es válido.")]
        [Display(Name = "DNI")]
        public int Dni { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Ingrese un e-mail")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = " El correo no es válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ingrese la fecha de inscripcion")]
        [Display(Name = "Fecha inscripcion")]
        public DateTime FechaInscripto { get; set; }

    }
}