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
    
    public partial class PERSON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PERSON()
        {
            this.EMPLOYEE = new HashSet<EMPLOYEE>();
            this.MEMBER = new HashSet<MEMBER>();
        }
    
        public string CITIZENID { get; set; }
        public string FNAME { get; set; }
        public string LNAME { get; set; }
        public string GENDER { get; set; }
        public Nullable<System.DateTime> BIRTHDATE { get; set; }
        public string ADDRESS { get; set; }
        public string EMAIL { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLOYEE> EMPLOYEE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEMBER> MEMBER { get; set; }
    }
}
