using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using Business;
using LinqEF;

namespace deker_mvc.Controllers
{
    public class ProductController : ApiController
    {
        // GET api/values
        public IEnumerable<recommend_content> GetRec()
        {
            return RecommendProduct.Instance.GetRecommendProd();
        }

        [HttpGet]
        public ResponseListModel<production> GetProductList(int pageSize, int pageIndex)
        {
            var reVal = new ResponseListModel<production>();
            try
            {
                reVal = new ProductMgr().GetProductList(pageSize, pageIndex);
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