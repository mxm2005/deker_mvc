using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Article;
using LinqEF;
using LinqEF.ReqEn;

namespace deker_mvc.Controllers
{
    public class SolutionController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Detail(int id)
        {
            article reVal = null;
            var art = new ArticleMgr().GetArticle(id);
            if (art.Success && art.Item != null)
            {
                reVal = art.Item;
                ViewBag.Title = art.Item.title;
            }
            var next = new Business.Article.ArticleMgr().GetNextArticle(id);
            ViewBag.nextid = next.Item.aid;
            ViewBag.title = next.Item.title;
            return View(reVal);
        }

        public ActionResult test()
        {
            return View();
        }
    }
}
