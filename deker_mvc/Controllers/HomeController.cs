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

        public ActionResult Product(int id)
        {
            var mo = new ProductMgr().GetProduct(id);
            return View(mo);
        }

        public ActionResult ProductList()
        {
            return View();
        }
        /// <summary>
        /// 分类查看
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ProductType(int id)
        {
            var mo = new ProductTypeMgr().GetProductType(id);
            return View(mo);
        } 

        #region support methord

        

        #endregion

    }
}
