using LinqEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class ProductMgr
    {
        private CompanyDataContext ctx;
        public ProductMgr()
        {
            ctx = new CompanyDataContext();
        }

        public ResponseListModel<production> GetProductList(int pageSize, int pageIndex)
        {
            var reVal = new ResponseListModel<production>();
            reVal.List = new List<production>();
            if(pageIndex<=0)
                pageIndex=1;
            reVal.List = ctx.production.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            reVal.Total= ctx.production.Count();
            return reVal;
        }
    }
}
