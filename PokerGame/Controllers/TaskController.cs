using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PokerDataAcess;
using Newtonsoft.Json.Linq;

namespace PokerGame.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        [Route("GetTasks")]

        // GET api/values

        [HttpGet]
        public ActionResult GetTasks()
        {
            if (!Authorization.IsAuthorize(Request)){
                return Unauthorized();
            }
            IHeaderDictionary request = Request.Headers;
            List<PokerDataAcess.Models.Task> tasks = PokerDataAcess.TaskDataAcess.Get();

            if (tasks ==  null || tasks.Count ==  0)
            {
                return NotFound();
            }
            else
            {
                return Ok(tasks);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (!Authorization.IsAuthorize(Request))
            {
                return Unauthorized();
            }
            PokerDataAcess.Models.Task t = PokerDataAcess.TaskDataAcess.Get(id);
            if (t == null)
                return NotFound();
            else
                return Ok(t);
         
        }

        // POST api/values
        [HttpPost]
        public HttpResponseMessage Post([FromBody] PokerDataAcess.Models.Task task)
        {
            if (!Authorization.IsAuthorize(Request))
            {
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
            bool isSucess = PokerDataAcess.TaskDataAcess.Add(task);
            HttpResponseMessage res = new HttpResponseMessage();
            res.StatusCode = isSucess ? HttpStatusCode.OK : HttpStatusCode.NotFound;

            return res;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            if (!Authorization.IsAuthorize(Request))
            {
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
            bool isSucess = PokerDataAcess.TaskDataAcess.Delete(id);
            HttpResponseMessage res = new HttpResponseMessage();
            res.StatusCode = isSucess ? HttpStatusCode.OK : HttpStatusCode.NotFound;

            return res;
        }

    }
}
