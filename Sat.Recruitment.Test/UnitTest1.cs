using System;
using System.Dynamic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Api.DTO;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.DLL.Interfaces;
using Sat.Recruitment.DLL.Services;
using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Domain.Interfaces;
using Sat.Recruitment.Test.Mock;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        Mock<IUserRepository> _userRepoMock;

        public UnitTest1()
        {
            _userRepoMock = UserRepositoryMock.UserRepositoryMock_MockObject();
        }

        [Fact]
        public async Task Test1()
        {
            _userRepoMock = UserRepositoryMock.GetUsersAsync();
            var userService = new UserService(_userRepoMock.Object);
            var user = new User()
            {
                Address = "Juan B Justo 123",
                Email = $"kevin@msn.com",
                Money = 100,
                Name = $"Kevin",
                Phone = $"+5491143546789",
                UserType = Domain.Enums.UserType.SuperUser
            };
            var result = await userService.CreateUser(user);
            Assert.True(result != null);
        }

        [Fact]
        public async Task Test2()
        {
            _userRepoMock = UserRepositoryMock.GetUsersAsync();
            var userService = new UserService(_userRepoMock.Object);

            var user = new User()
            {
                Address = "Av. Juan G",
                Email = "Agustina@gmail.com",
                Money = 124,
                Name = "Agustina",
                Phone = "+349 1122354215",
                UserType = UserType.Normal
            };
            await Assert.ThrowsAsync<Exception>(() => userService.CreateUser(user));
        }
    }
}
