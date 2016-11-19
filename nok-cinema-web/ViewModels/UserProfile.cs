using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;

namespace nok_cinema_web.ViewModels
{
    public class UserProfile
    {
        public string JOBPOSITION { get; set; }
        public int SALARY { get; set; }
        public string CITIZENID { get; set; }
        public string FNAME { get; set; }
        public string LNAME { get; set; }
        public string GENDER { get; set; }
        public Nullable<System.DateTime> BIRTHDATE { get; set; }
        public string ADDRESS { get; set; }
        public string EMAIL { get; set; }
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