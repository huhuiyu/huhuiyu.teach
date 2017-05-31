using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMvc.DAL.Entity
{
    public class VwEmployeeDept : TblEmployee
    {
        public string DeptName { get; set; }
        public string DeptInfo { get; set; }
    }
}