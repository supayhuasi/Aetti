//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AETTI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Proyecto
    {
        public int Id { get; set; }
        public Nullable<int> NroProyecto { get; set; }
        public string TituloProyecto { get; set; }
        public string TipoProyecto { get; set; }
        public string Diagnostico { get; set; }
        public string Producto { get; set; }
        public string Resumen { get; set; }
        public string Actividades { get; set; }
        public string LinkYoutube { get; set; }
        public Nullable<int> IdPersona { get; set; }
    
        public virtual Persona Persona { get; set; }
    }
}
