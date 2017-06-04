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
    public class MessageController : Controller
    {

        public ActionResult Info(MessageModel model)
        {
            model.Info = TblMessageDAO.QueryByKey(model.Info);
            model.Returns = TblReturnDAO.QueryByMid(model.Info);
            return View(model);
        }

        public ActionResult List(MessageModel model)
        {
            TblUser user = (TblUser)Session["LoginUser"];
            if (user == null)
            {
                return RedirectToAction("Index", "Default");
            }
            model.PageInfo.Count = TblMessageDAO.QueryUserCount(user);
            model.MessageList = TblMessageDAO.QueryUser(model.PageInfo, user);
            return View(model);
        }

        public ActionResult Add(MessageModel model)
        {
            TblUser user = (TblUser)Session["LoginUser"];
            if (user == null)
            {
                return RedirectToAction("Index", "Default");
            }
            try
            {
                model.Info.Uid = user.Uid;
                TblMessageDAO.Add(model.Info);
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            model.PageInfo.Count = TblMessageDAO.QueryUserCount(user);
            model.MessageList = TblMessageDAO.QueryUser(model.PageInfo, user);
            return View("List", model);
        }

        public ActionResult AddReturn(MessageModel model)
        {
            TblUser user = (TblUser)Session["LoginUser"];
            if (user != null)
            {
                model.ReturnInfo.Uid = user.Uid;
                TblReturnDAO.Add(model.ReturnInfo);
            }
            return Redirect("/Message/Info?Info.Mid=" + model.ReturnInfo.Mid);
        }

        public ActionResult Delete(MessageModel model)
        {
            TblUser user = (TblUser)Session["LoginUser"];
            if (user == null)
            {
                return RedirectToAction("Index", "Default");
            }
            model.Info.Uid = user.Uid;
            TblMessageDAO.Delete(model.Info);
            return RedirectToAction("List", "Message");

        }


    }
}
