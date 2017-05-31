using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeiBo.dal.entity
{
    public class TblMessage : TblUser
    {
        public int Mid { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public string Deleted { get; set; }
    }
}