using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Api.DTO;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser(UserDTO userDto)
        {
            try
            {
                return new Result()
                {
                    Data = await _userService.CreateUser(_mapper.Map<User>(userDto)),
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new Result()
                {
                    IsSuccess = false,
                    Errors = ex.Message
                };
            }
        }
    }
}
