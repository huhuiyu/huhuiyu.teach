using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMvc.DAL.Entity;

namespace WebMvc.DAL.DAO
{
    public class EmployeeDAO
    {
        public static List<TblEmployee> QueryAll()
        {
            return DBHelper.QueryRows(new TblEmployee(), "select * from TblEmployee order by eid desc");
        }

        public static int Add(TblEmployee emp)
        {
            return DBHelper.Update(@"insert into TblEmployee(deptId,ename,sex,salary)
            values(@p0,@p1,@p2,@p3)", emp.DeptId, emp.Ename, emp.Sex, emp.Salary);
        }

        public static int Delete(TblEmployee emp)
        {
            return DBHelper.Update(@"delete from TblEmployee where eid=@p0", emp.Eid);
        }

        public static int Modify(TblEmployee emp)
        {
            return DBHelper.Update(@"update TblEmployee set deptId=@p0,ename=@p1,sex=@p2,salary=@p3
    where eid=@p4", emp.DeptId, emp.Ename, emp.Sex, emp.Salary, emp.Eid);
        }

        public static TblEmployee QueryByKey(TblEmployee emp)
        {
            return DBHelper.QueryOneRow(emp, "select * from TblEmployee where eid=@p0", emp.Eid);
        }

        public static List<VwEmployeeDept> QueryAllInfo()
        {
            return DBHelper.QueryRows(new VwEmployeeDept(), @"select e.eid,e.ename,e.indate,e.salary
 ,case e.sex when 'm' then '男' else '女' end 'sex'
 ,d.deptName,d.deptInfo from TblEmployee e
 inner join TblDept d on e.deptId=d.deptId");
        }

        public static List<Dictionary<string, object>> QueryAllDicInfo()
        {
            return DBHelper.QueryDicRows(@"select e.eid,e.ename,e.indate,e.salary
 ,case e.sex when 'm' then '男' else '女' end 'sex'
 ,d.deptName,d.deptInfo from TblEmployee e
 inner join TblDept d on e.deptId=d.deptId");
        }


    }
}