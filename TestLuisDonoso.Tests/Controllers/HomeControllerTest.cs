using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLuisDonoso;
using TestLuisDonoso.Controllers;

namespace TestLuisDonoso.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UnAuthorized()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.UnAuthorized() as ViewResult;

            // Assert
            Assert.AreEqual("Un Authorized Page!", result.ViewBag.Message);
        }
    }
}
