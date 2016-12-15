using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;

namespace nok_cinema_web.DAL
{
    public class MemberDAL
    {
        public int GetMemberIdByUsername(string username)
        {
            var personDAL = new PersonDAL();
            var db = new CinemaEntities();
            IQueryable<MEMBER> memberQuery = from tmp in db.MEMBER
                                             where tmp.CITIZENID.Equals(personDAL.GetCitizenIdByUsername(username))
                                             select tmp;

            foreach (var memberTuple in memberQuery)
            {
                return memberTuple.MEMBERID;
            }
            return 1;
        }
    }
}