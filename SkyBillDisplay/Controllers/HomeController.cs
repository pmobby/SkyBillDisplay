using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using SkyBillDisplay.Models;
using Newtonsoft.Json;
using System.IO;

namespace SkyBillDisplay.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            BillViewModel bill = null;
            bill = GetBillJsonData();           

            return View(bill);
        }

        public BillViewModel GetBillJsonData()
        {
            BillViewModel billvm = null;

            Uri uri = new Uri(@"http://safe-plains-5453.herokuapp.com/bill.json");
            try
            {
                WebRequest wr = WebRequest.Create(uri);
                WebProxy myProxy = new WebProxy("192.240.46.123:80");
                myProxy.BypassProxyOnLocal = false;
                wr.Proxy = myProxy;
                wr.Method = "GET";
                WebResponse response = wr.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream());
                String data = streamReader.ReadToEnd();
                billvm = JsonConvert.DeserializeObject<BillViewModel>(data);
            }
            catch (Exception e)
            {
                billvm.ErrorMessages = e.ToString();
            }
           
            return billvm;
        }
    }
}