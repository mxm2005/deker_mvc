using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business.Download;
using LinqEF;
using LinqEF.ReqEn;

namespace deker_mvc.Controllers.Api
{
    public class DownController : ApiController
    {
        [HttpPost]
        public ResponseListModel<download> GetList(ReqDownEn en)
        {
            var reVal = new ResponseListModel<download>();
            try
            {
                reVal = new DownloadMgr().GetList(en);
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