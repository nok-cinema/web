using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;

namespace nok_cinema_web.DAL
{
    public class EmployeeDAL
    {
        public int GetEmployeeIdByUsername(string username)
        {
            var personDAL = new PersonDAL();
            var db = new CinemaEntities();
            IQueryable<EMPLOYEE> employeeQuery = from tmp in db.EMPLOYEE
                                                 where tmp.CITIZENID.Equals(personDAL.GetCitizenIdByUsername(username))
                                                 select tmp;

            foreach (var employeeTuple in employeeQuery)
            {
                return employeeTuple.EMPID;
            }
            return 1;
        }
    }
}