using LinqEF;
using LinqEF.ReqEn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Download
{
    public class DownloadMgr
    {
        CompanyDataContext ctx = null;
        public DownloadMgr()
        {
            ctx = new CompanyDataContext();
        }

        public ResponseListModel<download> GetList(ReqDownEn en)
        {
            var reVal = new ResponseListModel<download>();
            reVal.List = new List<download>();
            if (en.PageIndex <= 0)
                en.PageIndex = 1;
            var lst = ctx.download.AsQueryable();
            
            if (!string.IsNullOrWhiteSpace(en.Name))
                lst = lst.Where(s => s.name.Contains(en.Name));

            reVal.List = lst.Skip((en.PageIndex - 1) * en.PageSize)
                .Take(en.PageSize)
                .ToList();
            reVal.Total = lst.Count();
            reVal.Success = true;
            return reVal;
        }

    }
}
