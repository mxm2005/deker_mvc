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

        
    }
}