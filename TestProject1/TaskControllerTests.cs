using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerGame.Controllers;
using System.Net.Http;

namespace PokerGame.Controllers.Tests
{
    [TestClass]
    public class TaskControllerTests
    {
        [TestMethod]
        public void GetTaskTest()
        {
            TaskController controller = new TaskController();
            ActionResult response = controller.Get(1);
            Assert.IsNotNull(response);
            //Assert.IsTrue(response.);
        }

        [TestMethod]
        public void GetTest()
        {
            PokerDataAcess.Models.Task t = new PokerDataAcess.Models.Task();
            t.Description = "jkh";
            t.CompletionCriteria = 1;
            t.DifficultyLevel = 2;


            t.Completed = true;
            t.Id = 23231313;
            TaskController controller = new TaskController();
            HttpResponseMessage response = controller.Post(t);
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        public void PostTest()
        {
            PokerDataAcess.Models.Task t = new PokerDataAcess.Models.Task();
            t.Description = "jkh";
            t.CompletionCriteria =1;
            t.DifficultyLevel = 2;
            //   t.DifficultyLevel = Convert.ToString(row["[CompletionCriteria]"]);
            //   t.DifficultyLevel = Convert.ToString(row["[Bundle_id]"]);

            t.Completed = true;
            t.Id = 23231313;
            TaskController controller = new TaskController();
            HttpResponseMessage response = controller.Post(t);
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        public void PutTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void DeleteTest()
        {
            TaskController controller = new TaskController();
            HttpResponseMessage response = controller.Delete(1);
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}
