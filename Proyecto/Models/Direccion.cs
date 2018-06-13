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
    
    public partial class Direccion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Direccion()
        {
            this.FuncionarioDireccion = new HashSet<FuncionarioDireccion>();
        }

        [DisplayName("Codigo de direccion")]
        public decimal codDireccion { get; set; }
        [DisplayName("Pais")]
        public string pais { get; set; }
        [DisplayName("Ciudad")]
        public string ciudad { get; set; }
        [DisplayName("Detalle")]
        public string detalle { get; set; }
        [DisplayName("Usuario creador")]
        public string usuarioCreador { get; set; }
        [DisplayName("Usuario modificador")]
        public string usuarioModificador { get; set; }
        [DisplayName("Fecha de creacion")]
        public Nullable<System.DateTime> fechaCreacion { get; set; }
        [DisplayName("Fecha de modificacion")]
        public Nullable<System.DateTime> fechaModificacion { get; set; }
    
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario Usuario1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FuncionarioDireccion> FuncionarioDireccion { get; set; }
    }
}
