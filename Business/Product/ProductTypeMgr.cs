using LinqEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class ProductTypeMgr
    {
        private CompanyDataContext ctx;

        public ProductTypeMgr()
        {
            ctx = new CompanyDataContext();
        }

        /// <summary>
        /// 获取产品分类列表
        /// </summary>
        /// <param name="parentid"></param>
        /// <returns></returns>
        public ResponseListModel<product_type> GetList(int parentid)
        {
            var reVal = new ResponseListModel<product_type>();
            var lst = ctx.product_type
                .Take(100)
                .ToList();
            reVal.List = lst;
            reVal.Total = lst.Count();
            return reVal;
        }

        /// <summary>
        /// 获取所有产品分类
        /// </summary>
        /// <returns></returns>
        public List<product_type> GetAllType()
        {
            var lst = ctx.product_type.ToList();
            return lst;
        }
    }
}
