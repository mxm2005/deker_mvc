using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqEF;
using LinqEF.ReqEn;

namespace Business.Article
{
    public class ArticleMgr
    {
        CompanyDataContext ctx = null;
        public ArticleMgr()
        {
            ctx = new CompanyDataContext();
        }

        public ResponseListModel<article> GetArticleList(ReqArticleEn en)
        {
            var reVal = new ResponseListModel<article>();
            reVal.List = new List<article>();
            if (en.PageIndex <= 0)
                en.PageIndex = 1;
            var lst = ctx.article.AsQueryable();

            if (en.ArticleType > 0)
                lst = lst.Where(s => s.type_id == en.ArticleType);

            if (!string.IsNullOrWhiteSpace(en.Title))
                lst = lst.Where(s => s.title.Contains(en.Title));

            reVal.List = lst.Skip((en.PageIndex - 1) * en.PageSize)
                .Take(en.PageSize)
                .ToList();
            reVal.Total = lst.Count();
            reVal.Success = true;
            return reVal;
        }

        public ResponseItemModel<article> GetArticle(int aid)
        {
            var reVal = new ResponseItemModel<article>();
            reVal.Item = ctx.article.Where(s => s.aid == aid).FirstOrDefault();
            reVal.Success = true;
            return reVal;
        }

        public ResponseItemModel<article> GetNextArticle(int aid)
        {
            var reVal = new ResponseItemModel<article>();
            reVal.Item = ctx.article.Where(s => s.aid > aid).FirstOrDefault();
            reVal.Success = true;
            return reVal;
        }

    }
}
