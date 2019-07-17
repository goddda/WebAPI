using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API_demo.Controllers
{
    [Route("api")]
    [ApiController]
    public class HugsController : ControllerBase
    {
        private HugsService _hugsService;

        public HugsController(HugsService service)
        {
            _hugsService = service;
        }
        private static List<Hug> _hugs = new List<Hug>()
        {
        new Hug(0, "Beautiful eyes", DateTime.Now),
        new Hug(1, "Eyes", DateTime.Now),
        new Hug(2, "Was nice", DateTime.Now),
        new Hug(3, "Made me coffee", DateTime.Now),
        };
        // GET api/hug
        [HttpGet("hug/{id}")]
        public Hug Get(long id)
        {
            return _hugs.Find(hug => hug.Id == id);
        }

        [HttpGet("hug/monthCount/{month}")]
        public int GetByMonth(int month)
        {
            return _hugsService.GetHugsAtMonthCount(month, _hugs);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
