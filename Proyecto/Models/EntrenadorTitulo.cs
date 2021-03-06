//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel;

namespace Proyecto.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EntrenadorTitulo
    {
        [DisplayName("Codigo del entrenador")]
        public decimal codPersona { get; set; }
        [DisplayName("Codigo del titulo")]
        public decimal codTitulo { get; set; }
        [DisplayName("Usuario creador")]
        public string usuarioCreador { get; set; }
        [DisplayName("Usuario modificador")]
        public string usuarioModificador { get; set; }
        [DisplayName("Fecha de creacion")]
        public Nullable<System.DateTime> fechaCreacion { get; set; }
        [DisplayName("Fecha de modificacion")]
        public Nullable<System.DateTime> fechaModificacion { get; set; }
        
        public virtual Entrenador Entrenador { get; set; }
        public virtual TituloAcademico TituloAcademico { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario Usuario1 { get; set; }
    }
}
