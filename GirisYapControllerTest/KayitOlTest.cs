using Login.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GirisYapControllerTest
{
    [TestClass]
    public class KayitOlTest
    {

        [TestMethod]

        public void ShouldReturnView()
        {
            var controller = new KayitController();
            var result = controller.Index();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
