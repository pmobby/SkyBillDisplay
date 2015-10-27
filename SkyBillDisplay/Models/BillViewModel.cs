using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SkyBillDisplay.Models
{    
    public class BillViewModel
    {        
        public Statement statement { get; set; }        
        public double total { get; set; }       
        public Package package { get; set; }       
        public CallCharges callCharges { get; set; }        
        public SkyStore skyStore { get; set; }
        public string ErrorMessages { get; set; }
    }
}