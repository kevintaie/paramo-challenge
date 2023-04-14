using Sat.Recruitment.Api.Models;
using Sat.Recruitment.DLL.Interfaces;
using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.DLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> CreateUser(User user)
        {
            var users = await _userRepository.Get();
            //Check if its not duplicated and insert
            foreach (var u in users)
                if (user.Email == u.Email || user.Phone == u.Phone || (user.Name == u.Name && user.Address == u.Address))
                    throw new Exception("Duplicated User");

            await _userRepository.Insert(user);
            users.Add(user);
            return users;
        }
    }
}
