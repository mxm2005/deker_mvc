using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using Business;
using LinqEF;
using LinqEF.ResModel;
using LinqEF.ReqEn;

namespace deker_mvc.Controllers
{
    public class ProductTypeController : ApiController
    {
        
        [HttpGet]
        public ResponseListModel<NestedProductType> GetMenuProductTypeList()
        {
            var reVal = new ResponseListModel<NestedProductType>();
            try
            {
                reVal = new ProductTypeMgr().GetMenuList();
                reVal.Success = true;
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