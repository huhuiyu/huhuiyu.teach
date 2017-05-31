using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeiBo.dal.entity
{
    public class TblUser
    {
        public int Uid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public DateTime RegDate { get; set; }
    }
}