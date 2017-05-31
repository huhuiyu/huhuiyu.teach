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
        public Page PageInfo { get; set; }
        public List<TblMessage> MessageList { get; set; }
        public List<TblReturn> Returns { get; set; }
        public string Message { get; set; }

        public MessageModel()
        {
            PageInfo = new Page();
            MessageList = new List<TblMessage>();
        }
    }
}