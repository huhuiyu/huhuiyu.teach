using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMvc.DAL.Entity;

namespace WebMvc.DAL.DAO
{
    public class PageDAO
    {
        public static int QueryCount()
        {
            return (int)DBHelper.QueryOne("select count(*) from TblEmployee");
        }

        public static List<Dictionary<string, object>> QueryPageData(Page page)
        {
            if (page.PageNumber == 1)
            {
                return DBHelper.QueryDicRows(string.Format(
@"select top {0} * from TblEmployee", page.PageSize));
            }
            else
            {
                return DBHelper.QueryDicRows(string.Format(
@"select top {0} * from TblEmployee
 where eid not in 
 (select top {1} eid from TblEmployee)", page.PageSize, page.Skip));
            }
        }

        public static List<Dictionary<string, object>> QueryPageEmpDept(Page page)
        {
            if (page.PageNumber == 1)
            {
                return DBHelper.QueryDicRows(string.Format(
@"select top {0} e.eid,e.ename,e.indate,e.salary
 ,case e.sex when 'm' then '男' else '女' end 'sex'
 ,d.deptName,d.deptInfo from TblEmployee e
 inner join TblDept d on e.deptId=d.deptId", page.PageSize));
            }
            else
            {
                return DBHelper.QueryDicRows(string.Format(
@"select top {0} e.eid,e.ename,e.indate,e.salary
 ,case e.sex when 'm' then '男' else '女' end 'sex'
 ,d.deptName,d.deptInfo from TblEmployee e
 inner join TblDept d on e.deptId=d.deptId
 where e.eid not in 
 (select top {1} eid from TblEmployee)", page.PageSize, page.Skip));
            }
        }

    }
}