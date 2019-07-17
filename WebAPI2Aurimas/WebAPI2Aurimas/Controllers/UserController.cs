using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Db;
using System.Linq;
using WebAPI2Aurimas.Models;
using WebAPI2Aurimas.Infrastructure;
using Infrastructure;
using HugDb.Repositories;
using HugDb.Entities;

namespace WebAPI2Aurimas.Controllers
{
    [Route("api/[controller]")] // Paima bracketsuose controller name
    [ApiController] // Pasako, kad bus API, galetu but MVC
    public class UserController : ControllerBase // Jeigu pilnas butu tada tik Controller
    {

        private UserRepository _repository;
        
        public UserController(UserRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public List<UserModel> Get()
        {
            var users = _repository.GetAllUsers();
            var result = users.Select(x => new UserModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Created = x.Created,
                Id = x.Id,
                Email = x.Email,
            }).ToList();
            return result;
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            var userToDelete = _repository.GetUser(id);
            _repository.Delete(userToDelete);

            return $"User: {id} deleted";
        }

        [HttpPost]
        public string Post([FromBody]UserModel model)
        {
            var users = _repository.GetAllUsers();
            int exist = users.Where(x => x.Id == model.Id).Count();

            if (exist == 0)
            {
                User newUser = new User();

                newUser.FirstName = model.FirstName;
                newUser.LastName = model.LastName;
                newUser.Created = model.Created;
                newUser.Email = model.Email;

                _repository.AddUser(newUser);
                return "User added";
            }
            else
                return "User exists already";
        }
        /*
        [HttpGet("{id}")]
        public HugModel Get(int id) // <HugModel> sumapina
        {
            //_logger.Log("Get by id started");

            //var hugs = _dbManager.GetHugs();

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
