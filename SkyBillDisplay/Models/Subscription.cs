﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkyBillDisplay.Models
{
    public class Subscription
    {
        public string type { get; set; }
        public string name { get; set; }
        public double cost { get; set; }
    }
}