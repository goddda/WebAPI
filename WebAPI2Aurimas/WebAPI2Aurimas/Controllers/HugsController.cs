using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Db;
using System.Linq;
using WebAPI2Aurimas.Models;
using WebAPI2Aurimas.Infrastructure;
using Infrastructure;

namespace WebAPI2Aurimas.Controllers
{
    [Route("api/[controller]")] // Paima bracketsuose controller name
    [ApiController] // Pasako, kad bus API, galetu but MVC
    public class HugsController : ControllerBase // Jeigu pilnas butu tada tik Controller
    {
        private readonly IMyLogger _logger;
        
        private DbManager _dbManager;
        
        /*private readonly IMyTime _time;
        public HugsController()
        {
            //_time = new myTime();
            _logger = new FileLogger();
        }
        */
        //_logger = new FileLogger();
        
        public HugsController()
        {
            _logger = new FileLogger();
            _dbManager = new DbManager(_logger);
        }
        
        [HttpGet]
        public List<HugModel> Get() // <HugModel> sumapina
        {
            _logger.Log("Get started");

            var hugs = _dbManager.GetHugs();
            var mappedHugs = hugs.Select(h => new HugModel
                {
                    Id = h.Id,
                    From = h.From,
                    To = h.To,
                    Reason = h.Reason,
                    Created = h.Created
                })
                .ToList();
            return mappedHugs;
        }

        [HttpGet("{id}")]
        public HugModel Get(int id) // <HugModel> sumapina
        {
            _logger.Log("Get by id started");

            var hugs = _dbManager.GetHugs();

            var mappedHugs = hugs.Select(h => new HugModel
            {
                Id = h.Id,
                From = h.From,
                To = h.To,
                Reason = h.Reason,
                Created = h.Created
            }).ToList();

            return mappedHugs.Single(h => h.Id == id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id) // <HugModel> sumapina
        {
            _logger.Log("Delete started");
            _dbManager.DeleteHug(id);
        }

        [HttpPost]
        public void Post([FromBody]HugModel model)
        {
            _logger.Log("Post started");
            var mappedHug =  new Hug
                {
                    Id = model.Id,
                    From = model.From,
                    To = model.To,
                    Reason = model.Reason,
                    Created = model.Created
                };
            _dbManager.InsertHug(mappedHug);
        }

        [HttpPut]
        public void Put([FromBody]HugModel model)
        {
            _logger.Log("Put started");
            var mappedHug = new Hug
            {
                Id = model.Id,
                From = model.From,
                To = model.To,
                Reason = model.Reason,
                Created = model.Created
            };
            _dbManager.UpdateHug(mappedHug);
        }
        /*
        [HttpPatch]
        public void Patch([FromBody]HugModel semimodel)
        {
            var mappedHug = new Hug
            {
                Id = semimodel.Id,
                From = semimodel.From,
                To = semimodel.To,
                Reason = semimodel.Reason,
                Created = semimodel.Created
            };
            _dbManager.SemiUpdateHug(mappedHug);
        }
        */

    }
}
