﻿using AnonymousFeedback.Application.Dtos.UserDto;

using AnonymousFeedback.Domian.IManagers;
using AnonymousFeedback.Domian.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace AnonymousFeedback.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IBaseManager<User> _userManager;
        private IMapper  _mapper;

        public UserController(IBaseManager<User> userManager, IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult GetAllUser()
        {
            var users = _userManager.GetAll();
            var usersDto = _mapper.Map<List<UserGetDto>>(users);
            return Ok(usersDto);
        }

        [HttpPut]
        public IActionResult EditUser(UserPutDto userDto) {

            var entity = _mapper.Map<User>(userDto);
            var user = _userManager.UpdateWithComplete(entity);
            return Ok(userDto);

        
        }
    }
}
