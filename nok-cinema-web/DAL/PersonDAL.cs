using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;

namespace nok_cinema_web.DAL
{
    public class PersonDAL
    {
        public string GetCitizenIdByUsername(string username)
        {
            var db = new CinemaEntities();
            IQueryable<PERSON> personQuery = from tmp in db.PERSON
                                                 where tmp.USERNAME.Equals(username)
                                                 select tmp;

            foreach (var personTuple in personQuery)
            {
                return personTuple.CITIZENID;
            }
            return null;
        }
    }
}