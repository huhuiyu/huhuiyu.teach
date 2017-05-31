using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBo.dal.dao;
using WeiBo.dal.entity;

namespace WeiBo.dal.dao
{
    public class TblReturnDAO
    {
        public static List<TblReturn> QueryByMid(TblMessage message)
        {
            return DBHelper.QueryRows(new TblReturn(),
@"select r.rid,r.mid,r.content,r.created,u.username,u.nickname
    from TblReturn r inner join TblUser u on r.uid=u.uid
   where r.mid=@p0", message.Mid);
        }
    }
}