//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace nok_cinema_web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SHOWTIME
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SHOWTIME()
        {
            this.TICKET = new HashSet<TICKET>();
        }
    
        public System.DateTime SHOWDATE { get; set; }
        public int MOVIEID { get; set; }
        public byte THEATREID { get; set; }
    
        public virtual MOVIE MOVIE { get; set; }
        public virtual THEATRE THEATRE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TICKET> TICKET { get; set; }
    }
}