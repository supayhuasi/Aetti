using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AETTI.Models
{
    [MetadataType(typeof(TipoProyectoValidation))]
    public partial class TipoProyecto
    {
    }
    public class TipoProyectoValidation
    {
        public int Id { get; set; }

        [DisplayName("Codigo")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Codigo { get; set; }

        [DisplayName("Descripcion")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Descripcion { get; set; }

        public virtual ICollection<Proyecto> Proyecto { get; set; }
    }
}