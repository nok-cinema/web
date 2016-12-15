using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;

namespace nok_cinema_web.BLL
{
    public class MemberBLL
    {
        public MEMBER GetMerberByCitizenId(string citizenid)
        {
            var db = new CinemaEntities();
            var member = new MEMBER();
            var memberQuery = db.MEMBER.Where(m => m.PERSON.CITIZENID.Equals(citizenid));

            foreach (var memberTuple in memberQuery)
            {
                member.CITIZENID = memberTuple.CITIZENID;
                member.MEMBERID = memberTuple.MEMBERID;
                member.STARTDATE = memberTuple.STARTDATE;
                member.EXPIRYDATE = memberTuple.EXPIRYDATE;
            }
            return member;
        }
    }
}