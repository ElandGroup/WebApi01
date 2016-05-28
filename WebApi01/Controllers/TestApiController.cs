using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using RestSharp;
using WebApi01.Models;

namespace WebApi01.Controllers
{
    public class TestApiController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        //.net request by this method
        public JsonResult GetFruit()
        {
            string baseUrl = "http://localhost:169";
            var client = new RestClient(baseUrl);
            var request = new RestRequest("api/v1/fruit/agentfruit", Method.POST);
            request.RequestFormat = DataFormat.Json;
            EmployeeDto dto = new EmployeeDto
            {
                Name = "liu1",
                Password = "1234"
            };
            //var jsonDto = JsonConvert.SerializeObject(dto);
            request.AddBody(dto);

            try
            {
                // execute the request
                IRestResponse response = client.Execute(request);
                return JsonParse(response.Content, ResultType.Success, "");

            }
            catch (Exception ex)
            {
                return JsonParse("", ResultType.Failure, ex.Message);
            }
        }


        public JsonResult JsonParse(object data, ResultType resultType, string msg)
        {
            return Json(new { ResultType = resultType.ToString(), Data = data, Msg = msg }, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
    }
}