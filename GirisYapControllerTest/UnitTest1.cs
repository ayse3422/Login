using Login.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;

namespace GirisYapControllerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
       
        public void ShouldReturnView()
        {
            var controller = new LoginController();
            var result = controller.Index();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
