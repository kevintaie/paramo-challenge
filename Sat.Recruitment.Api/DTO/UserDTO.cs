using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Api.DTO
{
    public class UserDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        public string UserType { get; set; }

        public string Money { get; set; }
    }

    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Errors { get; set; }
        public IEnumerable<User> Data { get; set; }
    }
}
