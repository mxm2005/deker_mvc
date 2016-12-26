using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Configuration;
using Business;
using LinqEF;

namespace deker_mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.RecommendProd = RecommendProduct.Instance.GetRecommendProd();
            ViewBag.Banner = XmlMgr.Instance.GetHomeBanner();
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        #region support methord

        

        #endregion

    }
}
