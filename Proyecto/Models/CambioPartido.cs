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
    
    public partial class CambioPartido
    {
        [DisplayName("Codigo del partido")]
        public decimal codPartido { get; set; }
        [DisplayName("Codigo del jugador saliente")]
        public decimal jugadorSale { get; set; }
        [DisplayName("Codigo del jugador entrante")]
        public decimal jugadorEntra { get; set; }
        [DisplayName("Minuto"), DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal minuto { get; set; }
        [DisplayName("Usuario creador")]
        public string usuarioCreador { get; set; }
        [DisplayName("Usuario modificador")]
        public string usuarioModificador { get; set; }
        [DisplayName("Fecha de creacion")]
        public Nullable<System.DateTime> fechaCreacion { get; set; }
        [DisplayName("Fecha de modificacion")]
        public Nullable<System.DateTime> fechaModificacion { get; set; }

    
        public virtual Partido Partido { get; set; }
        public virtual Jugador Jugador { get; set; }
        public virtual Jugador Jugador1 { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario Usuario1 { get; set; }
    }
}
