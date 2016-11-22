using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nok_cinema_web.Models
{
    public class EmployeeBusinessLayer
    {
        public bool IsValidUser(UserDetails u)
        {
            if (u.Username == "wat" && u.Password == "chan")
            {
                return true;
            }
            else if (u.Username == "abc" && u.Password == "def")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}