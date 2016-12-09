using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Configuration;
//using Business;

namespace deker_mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.RecommendProd = new RecommendProduct().GetRecommendProd();
            return View();
        }

        public ActionResult Product()
        {
            return View();
        }

        #region support methord

        

        #endregion

    }
}
