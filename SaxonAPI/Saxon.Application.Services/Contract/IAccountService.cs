using Saxon.Application.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saxon.Application.Services.Contract
{
    public interface IAccountService
    {
        public string RegisterNewUserService(SignUpDTO signUpDTO);
        public string LoginUserService(LoginDto loginDto);
    }
}
