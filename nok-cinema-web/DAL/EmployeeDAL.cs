﻿using System;
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

        public EMPLOYEE GetEmployeeByCitizenId(string citizenid)
        {
            var db = new CinemaEntities();
            var employee = new EMPLOYEE();
            IQueryable<EMPLOYEE> employeeQuery = from tmp in db.EMPLOYEE
                                                 where tmp.CITIZENID.Equals(citizenid)
                                                 select tmp;

            foreach (var employeeTuple in employeeQuery)
            {
                employee.PERSON = employeeTuple.PERSON;
                employee.CITIZENID = employeeTuple.CITIZENID;
                employee.EMPID = employeeTuple.EMPID;
                employee.JOBPOSITION = employeeTuple.JOBPOSITION;
                employee.SALARY = employeeTuple.SALARY;
            }
            return employee;
        }

        public EMPLOYEE GetEmployeeByEmployeeId(int employeeId)
        {
            var db = new CinemaEntities();
            var employee = new EMPLOYEE();
            IQueryable<EMPLOYEE> employeeQuery = from tmp in db.EMPLOYEE
                                                 where tmp.EMPID.Equals(employeeId)
                                                 select tmp;

            foreach (var employeeTuple in employeeQuery)
            {
                employee.PERSON = employeeTuple.PERSON;
                employee.CITIZENID = employeeTuple.CITIZENID;
                employee.EMPID = employeeTuple.EMPID;
                employee.JOBPOSITION = employeeTuple.JOBPOSITION;
                employee.SALARY = employeeTuple.SALARY;
            }
            return employee;
        }
    }
}