//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hist_PartidoArbitro
    {
        public decimal codPartido { get; set; }
        public decimal codPersona { get; set; }
        public string estado { get; set; }
        public Nullable<decimal> calificacion { get; set; }
    
        public virtual Arbitro Arbitro { get; set; }
        public virtual Hist_Partido Hist_Partido { get; set; }
    }
}
