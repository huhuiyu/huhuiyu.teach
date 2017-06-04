using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Exam.dal.dao;
using Exam.Models;
using Exam.dal.entity;

namespace Exam.Controllers
{
    public class DefaultController : Controller
    {

        public ActionResult Index(DefaultModel model)
        {

            using (SqlConnection conn = DBConn.GetConn())
            {
                ViewBag.Message = conn.Database;
                conn.Close();
            }
            return View(model);
        }

        public ActionResult Login(DefaultModel model)
        {
            TblUser user = TblUserDAO.Login(model.User);
            if (user == null)
            {
                model.Message = "用户名或者密码错误。";
                return View("Index", model);
            }
            Session.Add("LoginUser", user);
            return RedirectToAction("Main", "Default"); ;
        }

        public ActionResult Logout()
        {
            Session.Remove("LoginUser");
            return RedirectToAction("Index", "Default"); ;
        }

        public ActionResult Main(DefaultModel model)
        {
            TblUser user = (TblUser)Session["LoginUser"];
            if (user == null)
            {
                return RedirectToAction("Index", "Default");
            }
            return View(model);
        }





    }
}
