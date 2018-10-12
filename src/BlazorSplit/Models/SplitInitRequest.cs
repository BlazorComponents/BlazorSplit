using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSplit.Models
{
    public class SplitInitRequest
    {
        public string Id { get; set; }
        public SplitOptions Options { get; set; }
    }

    public class SplitInitResponse
    {
        public string[] Elements { get; set; }
    }
}
