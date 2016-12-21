using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqEF.ReqEn
{
    /// <summary>
    /// 请求参数实体
    /// </summary>
    public class ReqProductEn:ReqBaseEn
    {
        public int ProductType { get; set; }
        public string ProductName { get; set; }
    }
}
