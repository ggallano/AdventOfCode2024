﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_5
{
    public class OrderRule
    {
        int TargetNum { get; set; }
        int RuleNum { get; set; }

        public OrderRule(int targetNum, int ruleNum)
        {
            this.TargetNum = targetNum;
            this.RuleNum = ruleNum;
        }
    }
}
