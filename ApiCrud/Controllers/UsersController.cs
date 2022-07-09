using ApiCrud.Data;
using ApiCrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersData _usersData;
        public UsersController(IUsersData usersData)
        {
            _usersData = usersData;
        }

        [HttpGet]
        [Route("get-all-users")]
        public IActionResult GetUsers()
        {
            return Ok(_usersData.GetUsers());
        }

        [HttpGet]
        [Route("get-user-by-id/{id}")]
        public IActionResult GetUser(Guid id)
        {
            var user = _usersData.GetUser(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound($"user with id:{id} was found");
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateUser(User user)
        {
            _usersData.AddUser(user);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + user.Id, user);  
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            var user = _usersData.GetUser(id);
            if (user != null)
            {
                _usersData.DeleteUser(user);
                return Ok();
            }
            return NotFound($"user with id:{id} was found");
        }

        [HttpPatch]
        [Route("edit/{id}")]
        public IActionResult EditUser(Guid id, User user)
        {
            var existingUser = _usersData.GetUser(id);
            if (existingUser != null)
            {
                user.Id = existingUser.Id;
                _usersData.EditUser(user);
                return Ok();
            }
            return Ok(user);
        }
    }

}