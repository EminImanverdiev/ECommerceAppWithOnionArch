using OnionApi.Application.Bases;
using OnionApi.Application.Features.Auth.Exceptions;
using OnionApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Application.Features.Auth.Rules
{
    public class AuthRules:BaseRules
    {
        public Task UserShouldNotBeExist(User? user) 
        {
            if (user is not null) ;
            throw new UserAlreadyExistException();
            return Task.CompletedTask;
        }
        public Task EmailOrPasswordShouldNotBeInvalid(User?user,bool checkPassword)
        {
            if (user is null || !checkPassword)
            {
                throw new EmailOrPasswordShouldNotBeInvalidException();
            }
            return Task.CompletedTask;  

        }
    }
}
