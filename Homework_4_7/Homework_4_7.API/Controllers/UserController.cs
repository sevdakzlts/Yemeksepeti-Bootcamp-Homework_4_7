using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework_4_7.API.Data;
using Homework_4_7.API.Models;

namespace Homework_4_7.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("1.1")]
    [ApiVersion("2.0")]
    public class UserController : ControllerBase
    {
        private readonly UserData _userData;

        public UserController(UserData userData)
        {
            _userData = userData;
        }

        [MapToApiVersion("2.0")]
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return Ok(_userData.Users.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var data = _userData.Users.FirstOrDefault(c => c.Id == id);
            if (data != null)
            {
                return Ok(data);
            }

            return NoContent();
        }

        [ApiVersion("1.0", Deprecated = true)]
        [MapToApiVersion("1.1")]
        [HttpPut]
        public ActionResult Put(User user)
        {
            var data = _userData.Users.FirstOrDefault(c => c.Id == user.Id);
            if (data != null)
            {
                data.Name = user.Name;
                data.UserRole = user.UserRole;
            }
            else
            {
                data = new User();
                {
                    int Id = _userData.Users.Count;
                    string Name = user.Name;
                    UserRole UserRole = user.UserRole;
                };
                _userData.Users.Add(data);
            }

            return Ok(data);
        }

        [HttpPost]
        public ActionResult Post(User user)
        {
            user.Id = _userData.Users.Count;
            _userData.Users.Add(user);
            return Ok(user);
        }
    }
}
