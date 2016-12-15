using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace nok_cinema_web.Models
{
    [MetadataType(typeof(PERSONMetaData))]

    public partial class PERSON
    {
    }
    public class PERSONMetaData
    {
        [Required]
        [MinLength(13)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please Enter digits")]
        [Remote("CITIZENID", "Authentication", HttpMethod = "POST", ErrorMessage = "CITIZENID already exists. Please enter a different CITIZENID.")]
        public string CITIZENID { get; set; }
        [Required]
        public string FNAME { get; set; }
        [Required]
        public string LNAME { get; set; }
        [Required]
        public string GENDER { get; set; }
        [Required]
        public Nullable<System.DateTime> BIRTHDATE { get; set; }
        public string ADDRESS { get; set; }
        [Required]
        [Remote("doesEMAILExist", "Authentication", HttpMethod = "POST", ErrorMessage = "EMAIL already exists. Please enter a different EMAIL.")]
        public string EMAIL { get; set; }
        [Required]
        [Remote("doesUSERNAMEExist", "Authentication", HttpMethod = "POST", ErrorMessage = "Username already exists. Please enter a different username.")]
        public string USERNAME { get; set; }
        [Required]
        [Remote("currentpass", "People", HttpMethod = "POST", ErrorMessage = "Current password didn't match!")]
        public string PASSWORD { get; set; }

    }
}