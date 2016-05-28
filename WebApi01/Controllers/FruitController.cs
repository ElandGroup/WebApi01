using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApi01.Models;

namespace WebApi01.Controllers
{
    public class FruitController : ApiController
    {
        [HttpPost]
        public IEnumerable<FruitDto> AgentFruit(EmployeeDto value)
        {
            Dictionary<string, FruitDto> dicFruit = new Dictionary<string, FruitDto>() { 
            {"liu1",new FruitDto{ Name="Apple", Price="12", Type="A"}},
            {"liu2",new FruitDto{ Name="Pear", Price="10", Type="B"}}
            };
            var fruitDtoList = from p in dicFruit
                               where p.Key == value.Name
                                select p.Value;

            return fruitDtoList;
        }

    }
}