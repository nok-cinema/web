using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;
using System.ComponentModel.DataAnnotations;
namespace nok_cinema_web.ViewModels
{
    public class UserProfile
    {
        public string JOBPOSITION { get; set; }
        public int SALARY { get; set; }
        [Required]
        [Display(Name = "LNAME")]
        public string CITIZENID { get; set; }
        [Required]
        [Display(Name = "FNAME")]
        public string FNAME { get; set; }
        [Required]
        [Display(Name = "LNAME")]
        public string LNAME { get; set; }
        [Required]
        [Display(Name = "GENDER")]
        public string GENDER { get; set; }
        public Nullable<System.DateTime> BIRTHDATE { get; set; }
        public string ADDRESS { get; set; }
        public string EMAIL { get; set; }
        [Required]
        [Display(Name = "USERNAME")]
        public string USERNAME { get; set; }

        public UserProfile()
        {
            this.USERNAME = null;
        }
        public UserProfile(EMPLOYEE e, PERSON p)
        {
            this.CITIZENID = e.CITIZENID;
            this.JOBPOSITION = e.JOBPOSITION;
            this.SALARY = e.SALARY;

            this.FNAME = p.FNAME;
            this.LNAME = p.LNAME;
            this.GENDER = p.GENDER;
            this.EMAIL = p.EMAIL;
            this.USERNAME = p.USERNAME;
        }
        public void Cleanup()
        {
            this.CITIZENID = null;
            this.JOBPOSITION = null;
            this.SALARY = 0;

            this.FNAME = null;
            this.LNAME = null;
            this.GENDER = null;
            this.EMAIL = null;
            this.USERNAME = null;
        }
    }
}