using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkyBillDisplay;
using SkyBillDisplay.Controllers;
using SkyBillDisplay.Models;

namespace SkyBillDisplay.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;            

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetBillJsonData()
        {
            var controller = new HomeController();
            var data = controller.GetBillJsonData() as BillViewModel;
            Assert.IsNotNull(data);
        }
    }
}
