using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeiBo.dal.entity;

namespace WeiBo.Models
{
    public class MessageModel
    {
        public TblMessage Info { get; set; }
        public List<TblReturn> Returns { get; set; }
        public string Message { get; set; }
    }
}