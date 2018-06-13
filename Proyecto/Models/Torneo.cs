//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Torneo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Torneo()
        {
            this.EquipoTorneo = new HashSet<EquipoTorneo>();
            this.Fecha = new HashSet<Fecha>();
        }

        [DisplayName("Codigo del torneo"), DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal codTorneo { get; set; }
        [DisplayName("Codigo de la competicion")]
        public decimal codCompeticion { get; set; }

        [DisplayName("Codigo de la temporada"), DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal codTemporada { get; set; }
        [DisplayName("Usuario creador")]
        public string usuarioCreador { get; set; }
        [DisplayName("Usuario modificador")]
        public string usuarioModificador { get; set; }
        [DisplayName("Fecha de creacion")]
        public Nullable<System.DateTime> fechaCreacion { get; set; }
        [DisplayName("Fecha de modificacion")]
        public Nullable<System.DateTime> fechaModificacion { get; set; }
    
        public virtual Competicion Competicion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipoTorneo> EquipoTorneo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fecha> Fecha { get; set; }
        public virtual Temporada Temporada { get; set; }
    }
}
