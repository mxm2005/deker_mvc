using LinqEF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace Business
{
    public class RecommendProduct
    {
        #region singleton
        private static RecommendProduct _instance = new RecommendProduct();
        private CompanyDataContext ctx;
        public static RecommendProduct Instance
        {
            get { return _instance; }
        }
        private RecommendProduct()
        {
            ctx = new CompanyDataContext();
        }
        #endregion

        /// <summary>
        /// 显示推荐产品块，目前是自动读取的，没有推荐的
        /// </summary>
        public List<recommend_content> GetRecommendProd()
        {
            var reLst = new List<recommend_content>();
            reLst = (from s in ctx.recommend_content
                     where s.group_id == 1
                     select s).Take(6).ToList();
            return reLst;
        }
    }
}
