using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Domain.Enums;
using System;
using System.Text;

namespace Sat.Recruitment.Api.Extensions
{
    public static class MappingExtension
    {
        public static decimal GetMoney(UserType userType, decimal money)
        {
            switch (userType)
            {
                case UserType.Normal:
                    if (money > 100)
                    {
                        var percentage = Convert.ToDecimal(0.12);
                        //If new user is normal and has more than USD100
                        var gif = money * percentage;
                        money += gif;
                    }
                    if (money < 100)
                    {
                        if (money > 10)
                        {
                            var percentage = Convert.ToDecimal(0.8);
                            var gif = money * percentage;
                            money += gif;
                        }
                    }
                    break;
                case UserType.SuperUser:
                    if (money > 100)
                    {
                        var percentage = Convert.ToDecimal(0.20);
                        var gif = money * percentage;
                        money += gif;
                    }
                    break;
                case UserType.Premium:
                    if (money > 100)
                    {
                        var gif = money * 2;
                        money += gif;
                    }
                    break;
                default:
                    break;
            }
            return money;
        }

        public static string NormalizeEmail(string email)
        {
            //Normalize email
            var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            return string.Join("@", new string[] { aux[0], aux[1] });
        }
    }
}