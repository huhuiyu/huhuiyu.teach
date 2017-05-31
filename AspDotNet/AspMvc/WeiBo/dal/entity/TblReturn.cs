using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeiBo.dal.entity
{
    public class TblReturn : TblUser
    {
        public int Rid { get; set; }
        public int Mid { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
    }
}