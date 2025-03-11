using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_5
{
    public class PageOrder
    {
        public List<int> PageNums = new List<int>();
        public string PageNum { get; set; }
        public string CorrectedPageNum { get; set; }
        public bool HasViolation { get; set; }
        public int ViolationCount { get; set; }
        public int MidNum => PageNums[PageNums.Count / 2];
        public List<OrderRule> ViolatedRules = new List<OrderRule>();
    }
}
