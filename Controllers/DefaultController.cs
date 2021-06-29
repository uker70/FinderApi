using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinderApi.Database;

namespace FinderApi.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: api/Default
        public HttpResponseMessage GetIdCall([FromUri] string call, [FromUri] string id)
        {
            string result = "";

            switch (call.ToLower())
            {
                case "getuser":
                    result = StoredProcedureCalls.GetUser(Convert.ToInt32(id));
                    break;

                case "deleteuser":
                    result = StoredProcedureCalls.DeleteUser(Convert.ToInt32(id)).ToString();
                    break;

                default:
                    result = "error";
                    break;
            }

            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(result, System.Text.Encoding.UTF8, "text/plain");
            return resp;
        }

        public HttpResponseMessage GetDistance([FromUri] string call, [FromUri] string id, [FromUri] string distance)
        {
            string result = "";

            switch (call.ToLower())
            {
                case "getother":
                    result = StoredProcedureCalls.GetDistanceFromUser(Convert.ToInt32(id), Convert.ToInt32(distance));
                    break;
                default:
                    result = "error";
                    break;
            }

            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(result, System.Text.Encoding.UTF8, "text/plain");
            return resp;
        }

        public HttpResponseMessage GetUser([FromUri] string call, [FromUri] string latPos, [FromUri] string longPos)
        {
            string result = "";

            switch (call.ToLower())
            {
                case "postuser":
                    result = StoredProcedureCalls.PostUser(Convert.ToDouble(latPos), Convert.ToDouble(longPos));
                    break;
                default:
                    result = "error";
                    break;
            }

            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(result, System.Text.Encoding.UTF8, "text/plain");
            return resp;
        }
    }
}
