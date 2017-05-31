using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMvc.DAL.Entity;

namespace WebMvc.Models
{
    public class EmployeeModel
    {
        public string Message { get; set; }
        public TblEmployee Employee { get; set; }
        public List<TblDept> DeptList { get; set; }
        public List<TblEmployee> EmployeeList { get; set; }
        public List<VwEmployeeDept> EmpDeptList { get; set; }
        public List<Dictionary<string, object>> Datas { get; set; }
    }
}