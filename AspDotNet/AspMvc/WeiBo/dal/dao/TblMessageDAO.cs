using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeiBo.dal.entity;

namespace WeiBo.dal.dao
{
    public class TblMessageDAO
    {
        public static int Add(TblMessage message)
        {
            return DBHelper.Update(
@"insert into TblMessage(uid,title,content) values(@p0,@p1,@p2)"
               , message.Uid, message.Title, message.Content);
        }

        public static int QueryCount()
        {
            return (int)DBHelper.QueryOne(
@"select count(*) from TblMessage where deleted='n'");
        }

        public static List<TblMessage> Query(Page page)
        {
            if (page.PageNumber > 1)
            {
                return DBHelper.QueryRows(new TblMessage()
, string.Format(@"select top {0} m.mid,m.title,m.created
 ,u.username,u.nickname
 from TblMessage m
 inner join TblUser u on m.uid=u.uid
 where m.deleted='n' and m.mid not in
 (select top {1} mid from TblMessage order by mid desc)
 order by m.mid desc", page.PageSize, page.Skip));
            }
            return DBHelper.QueryRows(new TblMessage()
, string.Format(@"select top {0} m.mid,m.title,m.created
 ,u.username,u.nickname
 from TblMessage m
 inner join TblUser u on m.uid=u.uid
 where m.deleted='n' order by mid desc", page.PageSize));
        }

        public static TblMessage QueryByKey(TblMessage message)
        {
            return DBHelper.QueryOneRow(message,
                @"select m.mid,m.title,m.content,m.created
                 ,u.username,u.nickname
                 from TblMessage m
                 inner join TblUser u on m.uid=u.uid
                 where m.deleted='n' and m.mid=@p0", message.Mid);
        }

        public static int QueryUserCount(TblUser user)
        {
            return (int)DBHelper.QueryOne(
@"select count(*) from TblMessage where uid=@p0 and deleted='n'", user.Uid);
        }

        public static List<TblMessage> QueryUser(Page page, TblUser user)
        {
            if (page.PageNumber > 1)
            {
                return DBHelper.QueryRows(new TblMessage()
, string.Format(@"select top {0} mid,title,content,created from TblMessage
 where deleted='n' and uid=@p0 and mid not in
 (select top {1} mid from TblMessage order by mid desc)
 order by mid desc", page.PageSize, page.Skip), user.Uid);
            }
            return DBHelper.QueryRows(new TblMessage()
, string.Format(@"select top {0} mid,title,content,created from TblMessage m
 where m.deleted='n' and uid=@p0 order by mid desc", page.PageSize), user.Uid);
        }

    }
}