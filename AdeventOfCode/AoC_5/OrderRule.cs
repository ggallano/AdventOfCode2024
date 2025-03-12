using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_5
{
    public class OrderRule
    {
        public OrderRule(int targetNum, int ruleNum)
        {
            this.TargetNum = targetNum;
            this.RuleNum = ruleNum;
        }

        public int RuleNum { get; set; }
        public int TargetNum { get; set; }
    }
}
