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
    
    public partial class MOVIE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MOVIE()
        {
            this.SHOWTIME = new HashSet<SHOWTIME>();
            this.REVIEW = new HashSet<REVIEW>();
        }
    
        public int MOVIEID { get; set; }
        public string MOVIENAME { get; set; }
        public string CATEGORY { get; set; }
        public string DIRECTOR { get; set; }
        public string SHORTDESCRIPTION { get; set; }
        public string ACTOR { get; set; }
        public Nullable<decimal> DURATION { get; set; }
        public Nullable<int> PLAYCOUNT { get; set; }
        public string STATUS { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SHOWTIME> SHOWTIME { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REVIEW> REVIEW { get; set; }
    }
}
