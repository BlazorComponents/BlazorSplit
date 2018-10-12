using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSplit.Models
{
    public class SplitOptions
    {
        public float[] Sizes { get; set; }
        public int MinSize { get; set; } = 0;
        public string Direction { get; set; }
        
    }
}
