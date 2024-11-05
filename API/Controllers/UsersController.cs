using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    [Authorize]
    public class UsersController(IUserRepository userRepository, IMapper mapper) : BaseApiController 
    {
        /*
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return ["value1", "value2"];
        }*/
        [AllowAnonymous]
        [HttpGet]
        public async Task <ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await userRepository.GetMembersAsync();
   
            return Ok(users);
        }

        [Authorize]
        [HttpGet("{username}")] // /api/users/lisa
        public async Task <ActionResult<MemberDto>> GetUser(string username)
        {
            var user = await userRepository.GetUserByUsernameAsync(username);
            if (user == null) return NotFound();
            return mapper.Map<MemberDto>(user);
        }
    }
}