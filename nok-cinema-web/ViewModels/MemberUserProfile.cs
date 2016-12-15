using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;


namespace nok_cinema_web.ViewModels
{
    public class MemberUserProfile
    {
        public int MEMBERID { get; set; }
        public System.DateTime STARTDATE { get; set; }
        public System.DateTime EXPIRYDATE { get; set; }
        public string CITIZENID { get; set; }
        public string FNAME { get; set; }
        public string LNAME { get; set; }
        public string GENDER { get; set; }
        public Nullable<System.DateTime> BIRTHDATE { get; set; }
        public string ADDRESS { get; set; }
        public string EMAIL { get; set; }
        public string USERNAME { get; set; }

        public MemberUserProfile()
        {
            this.USERNAME = null;
        }
        public MemberUserProfile(MEMBER m, PERSON p)
        {
            this.CITIZENID = m.CITIZENID;
            this.STARTDATE = m.STARTDATE;
            this.EXPIRYDATE = m.EXPIRYDATE;
            this.MEMBERID = m.MEMBERID;

            this.FNAME = p.FNAME;
            this.LNAME = p.LNAME;
            this.GENDER = p.GENDER;
            this.EMAIL = p.EMAIL;
            this.USERNAME = p.USERNAME;
        }
        public void Cleanup()
        {
            this.CITIZENID = null;
            this.STARTDATE = DateTime.Now.AddYears(-10);
            this.EXPIRYDATE = DateTime.Now.AddYears(-10);

            this.FNAME = null;
            this.LNAME = null;
            this.GENDER = null;
            this.EMAIL = null;
            this.USERNAME = null;
        }
    }
}