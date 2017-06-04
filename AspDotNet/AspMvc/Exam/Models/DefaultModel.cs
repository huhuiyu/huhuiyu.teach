using Exam.dal.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeiBo.dal.entity;

namespace Exam.Models
{
    public class DefaultModel
    {
        public string Message { get; set; }
        public TblUser User { get; set; }
        public Page PageInfo { get; set; }
        public TblGoods Goods { get; set; }
        public List<TblGoods> GoodsList { get; set; }

        public DefaultModel()
        {
            Message = "";
            User = new TblUser();
            PageInfo = new Page();
            Goods = new TblGoods();
            GoodsList = new List<TblGoods>();
        }

    }
}