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
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }
        [Required]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }
        [Required]
        [Display(Name = "Número Documento")]
        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres...")]
        [MinLength(8, ErrorMessage = "Mínimo 8 dígitos...")]        
        //[Range(0, Int32.MaxValue, ErrorMessage = "El valor {0} no es válido para UnidadesEnExistencia")]
        public string Documento { get; set; }
        [Required]
        [Display(Name = "Género")]
        public int IdSexo { get; set; }
        [Required]
        [Display(Name = "Distrito")]
        public int IdUbigeo { get; set; }
        [Required]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Ingreso")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }

        public bool Estado { get; set; }        

        public string NombreCompleto { get { return Nombres + " " + Apellidos; } }
    }

    [MetadataType(typeof(MensajeroCE))]
    public partial class Mensajero
    {
        public string NombreCompleto { get { return Nombres + " " + Apellidos; } }        
    }

}