using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMvc.DAL.Entity;

namespace WebMvc.Models
{
    public class DeptModel
    {
        public TblDept Dept { get; set; }
        public List<TblDept> DeptList { get; set; }
        public string Message { get; set; }
    }
}