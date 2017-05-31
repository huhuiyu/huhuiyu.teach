using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeiBo.dal.entity;

namespace WeiBo.Models
{
    public class DefaultModel
    {
        public string Message { get; set; }
        public Page PageInfo { get; set; }
        public List<TblMessage> Messages { get; set; }

        public DefaultModel()
        {
            Message = "";
            PageInfo = new Page();
            Messages = new List<TblMessage>();
        }
    }
}