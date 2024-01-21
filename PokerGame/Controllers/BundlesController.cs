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
using PokerDataAcess.Models;

namespace PokerGame.Controllers
{

    [Route("api/[controller]")]
    public class BundlesController : Controller
    {
        [Route("Bundles")]

        [HttpGet]
        public ActionResult GetBundles()
        {
            if (!Authorization.IsAuthorize(Request))
            {
                return Unauthorized();
            }
            List<Bundle> bundles = BundlesDataAcess.Get();
     
            if (bundles == null || bundles.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(bundles);
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
            Bundle bundle = BundlesDataAcess.Get(id);
            if (bundle == null)
                return NotFound();
            else
                return Ok(bundle);
        }

        // POST api/values
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Bundle bundles)
        {
            if (!Authorization.IsAuthorize(Request))
            {
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
            bool isSucess = BundlesDataAcess.Add(bundles);
            HttpResponseMessage res = new HttpResponseMessage();
            res.StatusCode = isSucess? HttpStatusCode.OK : HttpStatusCode.NotFound;
           
            return res;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public HttpResponseMessage Put(Bundle bundles)
        {
            if (!Authorization.IsAuthorize(Request))
            {
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
            bool isSucess = BundlesDataAcess.Update(bundles);
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
                return new HttpResponseMessage(statusCode: HttpStatusCode.Unauthorized);
            }
            bool isSucess = BundlesDataAcess.Delete(id);
            HttpResponseMessage res = new HttpResponseMessage();
            res.StatusCode = isSucess ? HttpStatusCode.OK : HttpStatusCode.NotFound;

            return res;
        }
    }
}
