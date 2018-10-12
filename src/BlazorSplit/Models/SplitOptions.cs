using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSplit.Models
{
    public class SplitOptions
    {
        public float[] Sizes { get; set; }
        public int[] MinSize { get; set; }
        public string Direction { get; set; }
        public bool ExpanedToMin { get; set; }
        public int GutterSize { get; set; }
        public string GutterAlign { get; set; }
        public int SnapOffset { get; set; }
        public int DragInterval { get; set; }
        public string Cursor { get; set; }
    }

    public class SplitInitOptions
    {
        public bool OnDrag;
        public bool OnDragStart;
        public bool OnDragEnd;
    }
}
