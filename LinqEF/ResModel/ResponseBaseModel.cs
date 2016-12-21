using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqEF
{
    public class ResponseBaseModel
    {
        public bool HasRight { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
