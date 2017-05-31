using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeiBo.dal.dao;
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

    }
}
