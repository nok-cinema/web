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

        public MEMBER GetMemberByCitizenId(string citizenid)
        {
            var db = new CinemaEntities();
            var member = new MEMBER();
            IQueryable<MEMBER> memberQuery = from tmp in db.MEMBER
                                             where tmp.CITIZENID.Equals(citizenid)
                                             select tmp;

            foreach (var memberTuple in memberQuery)
            {
                member.PERSON = memberTuple.PERSON;
                member.CITIZENID = memberTuple.CITIZENID;
                member.MEMBERID = memberTuple.MEMBERID;
            }
            return member;
        }

        public MEMBER GetMemberByMemberId(int memberId)
        {
            var db = new CinemaEntities();
            var member = new MEMBER();
            IQueryable<MEMBER> memberQuery = from tmp in db.MEMBER
                                             where tmp.MEMBERID.Equals(memberId)
                                             select tmp;

            foreach (var memberTuple in memberQuery)
            {
                member.PERSON = memberTuple.PERSON;
                member.CITIZENID = memberTuple.CITIZENID;
                member.MEMBERID = memberTuple.MEMBERID;
            }
            return member;
        }
    }
}