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
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            StringBuilder sb = new StringBuilder();
            var lst = Business.RecommendProduct.Instance.GetRecommendProd();
            foreach (var s in lst)
            {
                sb.Append(s.id + "--" + s.title);
                sb.Append("<br />");
            }
            return sb.ToString();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        /// <summary>
        /// 获取Banner
        /// </summary>
        /// <returns></returns>
        public List<XmlDataEn> getBanners()
        {
            return XmlMgr.Instance.GetHomeBanner();
        }
    }
}