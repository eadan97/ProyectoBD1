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
    
    public partial class Federacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Federacion()
        {
            this.Equipo = new HashSet<Equipo>();
        }

        [DisplayName("Codigo de federacion")]
        public decimal codFederacion { get; set; }
        [DisplayName("Nombre de federacion")]
        public string nbrFederacion { get; set; }
        [DisplayName("Fecha de fundacion")]
        public Nullable<System.DateTime> fechaFundacion { get; set; }
        [DisplayName("Usuario creador")]
        public string usuarioCreador { get; set; }
        [DisplayName("Usuario Modificador")]
        public string usuarioModificador { get; set; }
        [DisplayName("Fecha de creacion")]
        public Nullable<System.DateTime> fechaCreacion { get; set; }
        [DisplayName("Fecha de modificacion")]
        public Nullable<System.DateTime> fechaModificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Equipo> Equipo { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario Usuario1 { get; set; }
    }
}
