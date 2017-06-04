using Exam.dal.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeiBo.dal.entity;

namespace Exam.dal.dao
{
    public class TblGoodsDAO
    {
        public static int QueryCount()
        {
            return (int)DBHelper.QueryOne(@"select count(*) from TblGoods");
        }

        public static List<TblGoods> QueryPage(Page page)
        {
            return DBHelper.QueryRows(new TblGoods(),
string.Format(@"select top {0} g.*,u.*
from TblGoods g
inner join TblUser u on g.operator=u.uid
where g.gid not in
(
	select top {1} gid from TblGoods
)", page.PageSize, page.Skip));
        }

        public static int Add(TblGoods goods)
        {
            return DBHelper.Update(
@"insert into TblGoods(operator,gname,cost,price) values(@p0,@p1,@p2,@p3)"
, goods.Uid, goods.Gname, goods.Cost, goods.Price);
        }

        public static int Delete(TblGoods goods)
        {
            return DBHelper.Update(@"delete from TblGoods where gid=@p0", goods.Gid);
        }
    }
}