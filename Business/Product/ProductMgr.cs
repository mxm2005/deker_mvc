using LinqEF;
using LinqEF.ReqEn;
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

        public ResponseListModel<production> GetProductList(ReqProductEn en)
        {
            var reVal = new ResponseListModel<production>();
            reVal.List = new List<production>();
            if(en.PageIndex<=0)
                en.PageIndex = 1;
            var lst = ctx.production.AsQueryable();

            if (en.ProductType > 0)
                lst = lst.Where(s => s.product_type == en.ProductType);

            if (!string.IsNullOrWhiteSpace(en.ProductName))
                lst = lst.Where(s => s.product_name.Contains(en.ProductName));

            reVal.List = lst.Skip((en.PageIndex - 1) * en.PageSize)
                .Take(en.PageSize)
                .ToList();
            reVal.Total= lst.Count();
            return reVal;
        }
    }
}
