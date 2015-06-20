using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AETTI.Models
{
    [MetadataType(typeof(PersonaValidation))]
    public partial class Persona
    { }	
    
    public class PersonaValidation
    {
        
        public int Id { get; set; }
        
        [DisplayName("C.U.I.T")]
        [StringLength(50)]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Range(0, 99999999999, ErrorMessage = "Ingrese un CUIT valido.")]
        public string CUIT { get; set; }
        
        [DisplayName("Titular")]
        [StringLength(100)]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string RazonSocial { get; set; }
        
        [DisplayName("Código Postal")]
        [StringLength(50)]
        [Range(100, 9999, ErrorMessage = "Ingrese un Codigo de Area valido.")]
        public string CodigoPostal { get; set; }

        [DisplayName("Provincia")]
        [StringLength(100)]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Provincia { get; set; }
        
        [DisplayName("Partido / Departamento")]
        [StringLength(100)]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string PartidoDepartamento { get; set; }
        
        [DisplayName("Localidad")]
        [StringLength(100)]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Localidad { get; set; }
        
        [DisplayName("Teléfonos (incluir el código de área")]
        [StringLength(50)]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression(@"^\+?\d{1,3}?[- .]?\(?(?:\d{2,3})\)?[- .]?\d\d\d[- .]?\d\d\d\d$", ErrorMessage="Ingrese un telefono valido. Sin espacio y sin guión entre area y nro de telefono.")]
        public string Telefono { get; set; }

        [DisplayName("E-mail")]
        [StringLength(100)]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [EmailAddress(ErrorMessage="Ingrese un mail valido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Profesion { get; set; }

    }
}