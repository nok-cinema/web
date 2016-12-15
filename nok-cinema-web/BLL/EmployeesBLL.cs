using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;

namespace nok_cinema_web.BLL
{
    public class EmployeesBLL
    {
        public EMPLOYEE GetEmployeeByCitizenId(string citizenid)
        {
            var db = new CinemaEntities();
            var employee = new EMPLOYEE();
            IQueryable<EMPLOYEE> employeeQuery = from tmp in db.EMPLOYEE
                                                 where tmp.CITIZENID.Equals(citizenid)
                                                 select tmp;

            foreach (var employeeTuple in employeeQuery)
            {
                employee.CITIZENID = employeeTuple.CITIZENID;
                employee.JOBPOSITION = employeeTuple.JOBPOSITION;
                employee.SALARY = employeeTuple.SALARY;
            }
            return employee;
        }
    }
}