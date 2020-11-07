using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TestLuisDonoso;
using TestLuisDonoso.Controllers;

namespace TestLuisDonoso.Tests.Controllers
{
    [TestClass]
    public class UsuarioControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            UsuarioController controller = new UsuarioController();

            // Act
            ViewResult result = controller.Index() as ViewResult;
            
            // Assert
            Assert.IsNotNull(result);
        }
    }
}
