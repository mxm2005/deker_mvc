using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqEF.ReqEn
{
    /// <summary>
    /// 文章请求参数实体
    /// </summary>
    public class ReqArticleEn : ReqBaseEn
    {
        public int ArticleType { get; set; }
        public string Title { get; set; }
    }
}
