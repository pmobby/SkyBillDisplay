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


            //solution 2
            //BillViewModel billvm = null;
            //var urlendpoint = "http://safe-plains-5453.herokuapp.com/bill.json";
            //try
            //{
            //    using (var wclient = new WebClient())
            //    {
            //        WebProxy serverProxy = new WebProxy("165.139.149.169:3128");
            //        //serverProxy.Address = new Uri("165.139.149.169:3128");
            //        wclient.Proxy = serverProxy;
            //        var data = wclient.DownloadString(urlendpoint);
            //        billvm = JsonConvert.DeserializeObject<BillViewModel>(data);
            //    }
            //}
            //catch (Exception e)
            //{
            //    Response.Write(e.ToString());
            //}
            return billvm;
        }
    }
}