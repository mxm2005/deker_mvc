using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqEF.ResModel
{
    public class NestedProductType:product_type
    {
        public List<product_type> Child { get; set; }
    }
}
