using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeiBo.dal.dao;
using WeiBo.Models;

namespace WeiBo.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index(DefaultModel model)
        {
            model.PageInfo.PageSize = 7;
            model.PageInfo.Count = TblMessageDAO.QueryCount();
            model.Messages = TblMessageDAO.Query(model.PageInfo);
            return View(model);
        }

    }
}
