using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business.Article;
using LinqEF;
using LinqEF.ReqEn;

namespace deker_mvc.Controllers.Api
{
    public class ArticleController : ApiController
    {
        [HttpPost]
        public ResponseListModel<article> GetArticleList(ReqArticleEn en)
        {
            var reVal = new ResponseListModel<article>();
            try
            {
                reVal = new ArticleMgr().GetArticleList(en);
            }
            catch (Exception ex)
            {
                reVal.Success = false;
                reVal.Message = ex.Message;
            }
            return reVal;
        }
    }
}