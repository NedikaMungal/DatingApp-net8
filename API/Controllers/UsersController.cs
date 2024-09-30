using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // /api/users
    public class UsersController(DataContext context) : ControllerBase 
    {
        /*
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return ["value1", "value2"];
        }*/
        
        [HttpGet]
        public async Task <ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await context.Users.ToListAsync();
            return users;
        }

        [HttpGet("{id:int}")] // /api/users/id
        public async Task <ActionResult<AppUser>> GetUser(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null) return NotFound();
            return user;
        }
    }
}