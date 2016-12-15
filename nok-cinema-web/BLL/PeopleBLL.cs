using nok_cinema_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nok_cinema_web.BLL
{
    public class PeopleBLL
    {
        public bool Status { get; set; }

        public PERSON GetPersonByCookie(string username)
        {
            var db = new CinemaEntities();
            var person = new PERSON();
            IQueryable<PERSON> personQuery = from tmp in db.PERSON
                                             where tmp.USERNAME.Equals(username)
                                             select tmp;
            if (personQuery != null)
            {
                foreach (var personTuple in personQuery)
                {
                    person.USERNAME = personTuple.USERNAME;
                    person.CITIZENID = personTuple.CITIZENID;
                    person.ADDRESS = personTuple.ADDRESS;
                    person.BIRTHDATE = personTuple.BIRTHDATE;
                    person.EMAIL = personTuple.EMAIL;
                    person.FNAME = personTuple.FNAME;
                    person.LNAME = personTuple.LNAME;
                    person.GENDER = personTuple.GENDER;
                    this.Status = true;
                }
                return person;
            }
            this.Status = false;
            return null;
        }

        public bool CheckPassword (string password)
        {
            var db = new CinemaEntities();
            var person = new PERSON();
            IQueryable<PERSON> personQuery = from tmp in db.PERSON
                                             where tmp.PASSWORD.Equals(password)
                                             select tmp;
            if (personQuery != null)
            {
                foreach (var personTuple in personQuery)
                {
                    return true;
                }
            }
            return false;
        }

        public PERSON GetPersonByUserDetails(UserDetails userDetails)
        {
            var db = new CinemaEntities();
            var person = new PERSON();
            IQueryable<PERSON> personQuery = from tmp in db.PERSON
                                             where tmp.USERNAME.Equals(userDetails.Username) & tmp.PASSWORD.Equals(userDetails.Password)
                                             select tmp;
            if (personQuery != null)
            {
                foreach (var personTuple in personQuery)
                {
                    person.USERNAME = personTuple.USERNAME;
                    person.CITIZENID = personTuple.CITIZENID;
                    person.ADDRESS = personTuple.ADDRESS;
                    person.BIRTHDATE = personTuple.BIRTHDATE;
                    person.EMAIL = personTuple.EMAIL;
                    person.FNAME = personTuple.FNAME;
                    person.LNAME = personTuple.LNAME;
                    person.GENDER = personTuple.GENDER;
                    this.Status = true;
                }
                return person;
            }
            this.Status = false;
            return null;
        }

        public PERSON GetPersonByCitizenId(string citizenid)
        {
            var db = new CinemaEntities();
            var person = new PERSON();
            IQueryable<PERSON> personQuery = from tmp in db.PERSON
                                        where tmp.CITIZENID.Equals(citizenid)
                                        select tmp;
            
            foreach (var personTuple in personQuery)
            {
                person.USERNAME = personTuple.USERNAME;
                person.CITIZENID = personTuple.CITIZENID;
                person.ADDRESS = personTuple.ADDRESS;
                person.BIRTHDATE = personTuple.BIRTHDATE;
                person.EMAIL = personTuple.EMAIL;
                person.FNAME = personTuple.FNAME;
                person.LNAME = personTuple.LNAME;
                person.GENDER = personTuple.GENDER;
            }
            return person;
        }
    }
}