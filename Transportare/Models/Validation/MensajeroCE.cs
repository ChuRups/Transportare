using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Transportare.Models
{
    public class MensajeroCE
    {
        public int IdMensajero { get; set; }
        [Required]
        [Display(Name = "Ingrese Nombres")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Ingrese Apellidos")]
        public string Apellidos { get; set; }
        [Required]
        [Display(Name = "Ingrese Número Documento")]
        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres...")]
        [MinLength(8, ErrorMessage = "Mínimo 8 dígitos...")]
        //[Range(0, Int32.MaxValue, ErrorMessage = "El valor {0} no es válido para UnidadesEnExistencia")]
        public string Documento { get; set; }
        [Required]
        [Display(Name = "Ingrese Género")]
        public int IdSexo { get; set; }
        [Required]
        [Display(Name = "Ingrese Dirección")]
        public string Direccion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }

        public string SexoDes { get; set; }

        public string NombreCompleto { get { return Nombre + " " + Apellidos; } }

    }

    [MetadataType(typeof(MensajeroCE))]
    public partial class Mensajero
    {
        public string NombreCompleto { get { return Nombre + " " + Apellidos; } }
        public string SexoDes { get; set; }
    }

}