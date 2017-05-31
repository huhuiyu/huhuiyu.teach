using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBo.dal.dao;
using WeiBo.dal.entity;

namespace WeiBo.dal.dao
{
    public class TblUserDAO
    {
        public static int Reg(TblUser user)
        {
            return DBHelper.Update(
@"insert into TblUser(username,password,nickname) values(@p0,@p1,@p2)"
, user.Username, user.Password, user.Nickname);
        }

        public static TblUser Login(TblUser user)
        {
            return DBHelper.QueryOneRow(user,
@"select * from TblUser where username=@p0 and password=@p1"
, user.Username, user.Password);
        }
    }
}