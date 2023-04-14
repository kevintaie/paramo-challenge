using Sat.Recruitment.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> Get();
        Task Insert(User user);
    }
}
