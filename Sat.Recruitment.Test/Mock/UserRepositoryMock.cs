using AutoMapper;
using Moq;
using Sat.Recruitment.Api.DTO;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Test.Mock
{
    public class UserRepositoryMock
    {
        public static Mock<IUserRepository> UserRepositoryMock_MockObject()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            return userRepositoryMock;
        }

        public static Mock<IUserRepository> GetUsersAsync()
        {
            List<User> users = new()
            {
                new User()
                {
                    Address = "Av. Juan G",
                    Email = "Agustina@gmail.com",
                    Money = 124,
                    Name = "Agustina",
                    Phone = "+349 1122354215",
                    UserType = UserType.Normal
                }
            };
            var mock = new Mock<IUserRepository>();
            mock.Setup(x => x.Get()).ReturnsAsync(users);
            return mock;
        }
    }
}
