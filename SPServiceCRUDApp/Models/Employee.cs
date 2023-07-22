using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPServiceCRUDApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string EmployeeCode { get; set; }
        public string Address { get; set; }
    }
}