using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        User Add<TValidator>(User obj) where TValidator : AbstractValidator<User>;
        User GetUser(string email,string password);
    }
}
