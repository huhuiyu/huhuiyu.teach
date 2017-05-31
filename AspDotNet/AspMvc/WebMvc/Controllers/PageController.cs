using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMvc.DAL.DAO;
using WebMvc.Models;

namespace WebMvc.Controllers
{
    public class PageController : Controller
    {
        public ActionResult Index(PageModel model)
        {
            model.PageInfo.Count = PageDAO.QueryCount();
            model.PageData = PageDAO.QueryPageData(model.PageInfo);
            model.PageEmpDept = PageDAO.QueryPageEmpDept(model.PageInfo);
            return View(model);
        }

    }
}
