using Saxon.Application.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saxon.Application.Repository.Repositories.Contract
{
    public interface IAccountRepository
    {
        public string CreateNewUserRepository(SignUpDTO signupdto);
        public string LoginUserRepository(LoginDto loginDto);
    }
}
