using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.dal.entity
{
    public class TblGoods : TblUser
    {
        public int Gid { get; set; }
        public string Gname { get; set; }
        public Decimal Cost { get; set; }
        public Decimal Price { get; set; }
    }
}