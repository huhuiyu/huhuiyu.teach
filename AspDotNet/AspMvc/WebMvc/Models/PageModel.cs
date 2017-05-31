using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMvc.DAL.Entity;

namespace WebMvc.Models
{
    public class PageModel
    {
        public string Message = "";
        public Page PageInfo { get; set; }
        public List<Dictionary<string, object>> PageData { get; set; }
        public List<Dictionary<string, object>> PageEmpDept { get; set; }

        public PageModel()
        {
            //默认值
            PageInfo = new Page();
            PageData = new List<Dictionary<string, object>>();
            PageEmpDept = new List<Dictionary<string, object>>();
        }

    }
}