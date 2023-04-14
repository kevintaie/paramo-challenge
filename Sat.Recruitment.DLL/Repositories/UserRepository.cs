using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.DLL.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<List<User>> Get()
        {
            var users = new List<User>();
            var reader = ReadUsersFromFile();

            while (reader.Peek() >= 0)
            {
                var line = await reader.ReadLineAsync();
                var user = new User
                {
                    Name = line.Split(',')[0].ToString(),
                    Email = line.Split(',')[1].ToString(),
                    Phone = line.Split(',')[2].ToString(),
                    Address = line.Split(',')[3].ToString(),
                    UserType = (UserType)Enum.Parse(typeof(UserType), line.Split(',')[4]),
                    Money = decimal.Parse(line.Split(',')[5].ToString()),
                };
                users.Add(user);
            }
            reader.Close();

            return users;
        }

        public async Task Insert(User user)
        {
            string[] fileProperties = { user.Name, user.Email, user.Phone, user.Address, user.UserType.ToString(), user.Money.ToString() };

            string serializedProperties = string.Join(",", fileProperties);

            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";
            using StreamWriter sw = new StreamWriter(path, true);
            await sw.WriteLineAsync(serializedProperties);
        }

        private StreamReader ReadUsersFromFile()
        {
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }
    }
}
