using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqEF
{
    public class ResponseListModel<T>:ResponseBaseModel
    {
        public List<T> List { get; set; }
        public int Total { get; set; }
    }
}
