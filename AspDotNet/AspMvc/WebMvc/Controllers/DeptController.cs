using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMvc.DAL.DAO;
using WebMvc.DAL.Entity;
using WebMvc.Models;

namespace WebMvc.Controllers
{
    public class DeptController : Controller
    {

        public ActionResult Index()
        {

            DeptModel model = new DeptModel();
            try
            {
                model.DeptList = DeptDAO.QueryAll();
            }
            catch (Exception ex)
            {
                model.DeptList = new List<TblDept>();
                model.Message = ex.Message;
            }
            return View(model);
        }

        public ActionResult Add(DeptModel model)
        {
            try
            {
                DeptDAO.Add(model.Dept);
                model.Message = "保存部门信息成功";
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }

            model.DeptList = DeptDAO.QueryAll();
            return View("Index", model);
        }

        public ActionResult Delete(DeptModel model)
        {
            try
            {
                DeptDAO.Delete(model.Dept.DeptId);
                model.Message = "删除部门信息成功";
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }

            model.DeptList = DeptDAO.QueryAll();
            return View("Index", model);
        }

        public ActionResult ToModify(DeptModel model)
        {
            try
            {
                model.Dept = DeptDAO.QueryByKey(model.Dept);
                if (model.Dept == null)
                {
                    model.Message = "修改的数据不存在。";
                    model.DeptList = DeptDAO.QueryAll();
                    return View("Index", model);
                }
                return View(model);
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
                model.DeptList = DeptDAO.QueryAll();
                return View("Index", model);
            }

        }
        public ActionResult Modify(DeptModel model)
        {
            try
            {
                DeptDAO.Modify(model.Dept);
                model.Message = "修改部门信息成功";
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            return View("ToModify", model);
        }

    }
}
