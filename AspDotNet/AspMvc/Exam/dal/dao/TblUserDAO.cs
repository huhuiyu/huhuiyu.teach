using Exam.dal.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.dal.dao
{
    public class TblUserDAO
    {
        public static TblUser Login(TblUser user)
        {
            return DBHelper.QueryOneRow(user,
@"select * from TblUser where username=@p0 and password=@p1"
, user.Username, user.Password);
        }
    }
}