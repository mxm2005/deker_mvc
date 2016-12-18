using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqEF;

namespace Business.Article
{
    public class ArticleMgr
    {
        public ArticleMgr()
        {

        }

        public List<article> GetList()
        {
            return null;
        }

         /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="fldName">查询字段名</param>
        /// <param name="strWhere"></param>
        /// <param name="orderBy">排序字段</param>
        /// <param name="orderType">排序类型，非 0 值则降序</param>
        /// <returns></returns>
        public List<article> GetSolutionList(int PageSize, int PageIndex,string fldName, string strWhere,string orderBy,int orderType)
        {
            return null;
        }

    }
}
