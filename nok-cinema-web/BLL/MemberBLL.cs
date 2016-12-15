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
            var merberQuery = from tmp in db.MEMBER
                                                 where tmp.CITIZENID.Equals(citizenid)
                                                 select tmp;

            foreach (var memberTuple in merberQuery)
            {
                member.CITIZENID = memberTuple.CITIZENID;
                member.STARTDATE = memberTuple.STARTDATE;
                member.EXPIRYDATE = memberTuple.EXPIRYDATE;
            }
            return member;
        }
    }
}