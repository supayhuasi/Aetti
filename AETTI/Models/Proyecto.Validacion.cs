﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AETTI.Models
{
    [MetadataType(typeof(ProyectoValidation))]
    public partial class Proyecto
    { }

    public class ProyectoValidation
    {
        
        public int Id { get; set; }

        [DisplayName("Nro. Proyecto")]
        //[Range(0, 99999999999999.99, ErrorMessage = "Limite debe ser numerico")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public Nullable<int> NroProyecto { get; set; }
        [DisplayName("Título del Proyecto")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string TituloProyecto { get; set; }
        
        [DisplayName("Emprendedor")]
        //[Required(ErrorMessage = "Este campo es obligatorio.")]
        public int? IdPersona { get; set; }

        [DisplayName("Diagnostico de donde observa la necesidad")]
        //[Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Diagnostico { get; set; }

        [DisplayName("Prod. que desea fabricar o desarrollar")]
        //[Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Producto { get; set; }

        [DisplayName("Proceso de producción y el mercado")]
        //[Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Resumen { get; set; }

        [DisplayName("Act. que desea financiar y monto estimado")]
        //[Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Actividades { get; set; }

        [DisplayName("Link de youtube del videopitch")]   
        public string LinkYoutube { get; set; }
        
        
    }
}