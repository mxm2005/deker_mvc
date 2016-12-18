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

        public List<production> GetProductList()
        {
            var reList = new List<production>();


            return reList;
        }
    }
}
