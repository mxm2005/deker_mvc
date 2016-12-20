using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqEF
{
    public class ResponseItemModel<T>:ResponseBaseModel
    {
        public T Item { get; set; }
    }
}
