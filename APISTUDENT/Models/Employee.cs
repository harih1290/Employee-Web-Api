using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace APISTUDENT.Models
{
    public class Employee
    {
        public int emp_id { get; set; }
        public string emp_name { get; set; }
        public string emp_salary { get; set; }
        public string created_on { get; set; }
    }

}