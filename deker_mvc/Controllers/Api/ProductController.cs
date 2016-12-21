using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using Business;
using LinqEF;
using LinqEF.ReqEn;

namespace deker_mvc.Controllers
{
    public class ProductController : ApiController
    {
        // GET api/values
        public IEnumerable<recommend_content> GetRec()
        {
            return RecommendProduct.Instance.GetRecommendProd();
        }

        [HttpPost]
        public ResponseListModel<production> GetProductList(ReqProductEn en)
        {
            var reVal = new ResponseListModel<production>();
            try
            {
                reVal = new ProductMgr().GetProductList(en);
            }
            catch (Exception ex)
            {
                reVal.Success = false;
                reVal.Message = ex.Message;
            }
            return reVal;
        }

        /// <summary>
        /// 获取Banner
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<XmlDataEn> getBanners()
        {
            return XmlMgr.Instance.GetHomeBanner();
        }
        
    }
}