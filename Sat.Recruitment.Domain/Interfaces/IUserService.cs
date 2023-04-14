using Sat.Recruitment.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.DLL.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> CreateUser(User user);
    }
}
