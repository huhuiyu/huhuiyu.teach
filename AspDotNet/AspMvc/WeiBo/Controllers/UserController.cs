using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeiBo.dal.dao;
using WeiBo.dal.entity;
using WeiBo.Models;

namespace WeiBo.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            UserModel model = new UserModel();
            return View(model);
        }

        public ActionResult ToReg()
        {
            UserModel model = new UserModel();
            return View(model);
        }

        public ActionResult Reg(UserModel model)
        {
            try
            {
                TblUserDAO.Reg(model.User);
                model.Message = "注册成功。";
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            return View("ToReg", model);
        }

        public ActionResult Login(UserModel model)
        {
            try
            {
                TblUser user = TblUserDAO.Login(model.User);
                if (user == null)
                {
                    model.Message = "信息不正确，登陆失败";
                }
                else
                {
                    Session.Add("LoginUser", user);
                }
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            return View("Index", model);
        }

        public ActionResult Logout()
        {
            Session.Remove("LoginUser");
            return RedirectToAction("Index", "User");
        }

    }
}
