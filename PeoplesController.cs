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

    public interface ITripsService
    {
        IEnumerable<Trip> Get();
    }

    [EnableQuery]
    [ODataRoute("Peoples")]
    public class PeoplesController : Controller
    {
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return DemoDataSources.Instance.People.AsQueryable();
        }

        [ODataRoute("({key})")]
        public IActionResult GetEntity(string key)
        {
            var entity = DemoDataSources.Instance.People.FirstOrDefault(c => c.ID == key);
            return entity == null ? (IActionResult)NotFound() : new ObjectResult(entity);
        }

        [ODataRoute("({key})/Trips")]
        public IActionResult GetTrips(string key)
        {
            var entity = DemoDataSources.Instance.People.FirstOrDefault(c => c.ID == key);
            return entity == null ? (IActionResult)NotFound() : new ObjectResult(entity.Trips);
        }
    }

    [EnableQuery]
    [ODataRoute("Trips")]
    public class TripsController : Controller
    {
        [HttpGet]
        public IEnumerable<Trip> Get()
        {
            return DemoDataSources.Instance.Trips.AsQueryable();
        }

        [ODataRoute("({key})")]
        public IActionResult GetEntity(string key)
        {
            var entity = DemoDataSources.Instance.Trips.FirstOrDefault(c => c.ID == key);
            return entity == null ? (IActionResult)NotFound() : new ObjectResult(entity);
        }

    }

}
