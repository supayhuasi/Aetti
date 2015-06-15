using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AETTI.Models
{
    public partial class Persona
    {
    }

    public class ProductoVentaValidation
    {
        public int Id { get; set; }


        [DisplayName("C.U.I.T")]
        [StringLength(100)]
        public string CUIT { get; set; }
        

        
        public string RazonSocial { get; set; }
        public string CodigoPostal { get; set; }
        public string Provincia { get; set; }
        public string PartidoDepartamento { get; set; }
        public string Localidad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}