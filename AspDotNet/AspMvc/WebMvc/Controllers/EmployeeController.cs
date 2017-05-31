using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMvc.DAL.DAO;
using WebMvc.Models;

namespace WebMvc.Controllers
{
    public class EmployeeController : Controller
    {
        private static void SetModelData(EmployeeModel model)
        {
            model.DeptList = DeptDAO.QueryAll();
            model.EmployeeList = EmployeeDAO.QueryAll();
            model.EmpDeptList = EmployeeDAO.QueryAllInfo();
            model.Datas = EmployeeDAO.QueryAllDicInfo();
        }

        public ActionResult Index()
        {
            EmployeeModel model = new EmployeeModel();
            SetModelData(model);
            return View(model);
        }

        public ActionResult Add(EmployeeModel model)
        {
            try
            {
                EmployeeDAO.Add(model.Employee);
                model.Message = "添加员工信息成功.";
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }

            SetModelData(model);
            return View("Index", model);
        }

        public ActionResult Delete(EmployeeModel model)
        {
            try
            {
                EmployeeDAO.Delete(model.Employee);
                model.Message = "删除员工信息成功.";
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }

            SetModelData(model);
            return View("Index", model);
        }

        public ActionResult ToModify(EmployeeModel model)
        {
            model.Employee = EmployeeDAO.QueryByKey(model.Employee);
            model.DeptList = DeptDAO.QueryAll();
            return View(model);
        }


        public ActionResult Modify(EmployeeModel model)
        {
            try
            {
                EmployeeDAO.Modify(model.Employee);
                model.Message = "修改员工信息成功.";
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            model.DeptList = DeptDAO.QueryAll();
            return View("ToModify", model);
        }

        public ActionResult List()
        {
            EmployeeModel model = new EmployeeModel();
            SetModelData(model);
            return View(model);
        }


    }
}
