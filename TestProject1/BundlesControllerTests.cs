using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerDataAcess.Models;
using PokerGame.Controllers;
using System.Net.Http;

namespace PokerGame.Controllers.Tests
{
    [TestClass]
    public class BundlesControllerTests
    {
        [TestMethod]
        public void GetTaskTest()
        {
            BundlesController controller = new BundlesController();
            ActionResult response = controller.Get(1);
            Assert.IsNotNull(response);
            //Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        public void GetTest()
        {
            Bundle t = new Bundle();
            t.Description = "jkh";
            //t.CompletionCriteria = "jkh";
            //   t.DifficultyLevel = Convert.ToString(row["[CompletionCriteria]"]);
            //   t.DifficultyLevel = Convert.ToString(row["[Bundle_id]"]);

            //t.Completed = true;
            t.Id = 23231313;
            BundlesController controller = new BundlesController();
            HttpResponseMessage response = controller.Post(t);
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        public void PostTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void PutTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void DeleteTest()
        {
            BundlesController controller = new BundlesController();
            HttpResponseMessage response = controller.Delete(1);
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}
