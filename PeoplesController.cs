using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oData
{

    public interface IPeopleService
    {
        IEnumerable<Person> Get();
    }

    [EnableQuery]
    [ODataRoute("Peoples")]
    public class PeoplesController : ControllerBase, IPeopleService
    {
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return DemoDataSources.Instance.People.AsQueryable();
        }

        [ODataRoute("({key})")]
        [HttpGet("({key})")]
        public async Task<IActionResult> GetEntity(string key)
        {
            var entity = DemoDataSources.Instance.People.FirstOrDefault(c => c.ID == key);
            return entity == null ? (IActionResult)NotFound() : new ObjectResult(entity);
        }

    }

}
