using Saxon.Application.Data;
using Saxon.Application.Repository.Repositories.Contract;
using Saxon.Application.Services.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saxon.Application.Services.Implementation
{
    public class AccountService : IAccountService
    {
        IAccountRepository accountRepository;
        public AccountService(IAccountRepository registerNewUserRepository)
        {
            this.accountRepository = registerNewUserRepository;
        }



        public string RegisterNewUserService(SignUpDTO signupdto)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(signupdto.Password, out passwordHash, out passwordSalt);
            signupdto.PasswordHash= passwordHash;
            signupdto.PasswordSalt = passwordSalt;
            signupdto.Id= Guid.NewGuid();
            return this.accountRepository.CreateNewUserRepository(signupdto);
        }

        public string LoginUserService(LoginDto loginDto)
        {
            return this.accountRepository.LoginUserRepository(loginDto);
        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }


    }
}
