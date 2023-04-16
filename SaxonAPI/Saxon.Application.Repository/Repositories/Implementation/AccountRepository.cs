using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Saxon.Application.Data;
using Saxon.Application.Repository.Context;
using Saxon.Application.Repository.Models;
using Saxon.Application.Repository.Repositories.Contract;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Saxon.Application.Repository.Repositories.Implementation
{
    public class AccountRepository : IAccountRepository
    {
        IMapper _mapper;
        saxondbContext _saxondbContext;
        private readonly IConfiguration _config;
        public AccountRepository(IMapper _mapper, saxondbContext _saxondbContext, IConfiguration config)
        {
            this._mapper = _mapper;
            this._saxondbContext = _saxondbContext;
            _config = config;
        }

        public string CreateNewUserRepository(SignUpDTO signupdto)
        {
            _saxondbContext.Customer.Add(_mapper.Map<Customer>(signupdto));
            _saxondbContext.SaveChanges();
            return "Saved Successfully";
        }

        public string LoginUserRepository(LoginDto loginDto)
        {
            if (isUserExist(loginDto.EmailId))
            {
                if (IsUserAuthenticated(loginDto))
                {
                    try
                    {
                        var emailID = _saxondbContext.Customer.Where(w => w.EmailId == loginDto.EmailId).Select(s => s.EmailId).SingleOrDefault().ToString();
                        var claims = new[]
                        {
                            new Claim(ClaimTypes.Email,emailID)
                        };
                        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
                        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512Signature);
                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(claims),
                            Expires = DateTime.Now.AddDays(30),
                            SigningCredentials = signinCredentials
                        };
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var token = tokenHandler.CreateToken(tokenDescriptor);
                        return tokenHandler.WriteToken(token);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                        return "Error Occured.Please contact your Adminstrator";
                    }
                }
                else return "Username or Password may be worng. Please Try Again";
            }
            else return "Email Id doesn't exist";

        }

        private bool IsUserAuthenticated(LoginDto loginDto)
        {
            byte[] passwordHash, passwordSalt;
            var user = _saxondbContext.Customer.FirstOrDefault(x => x.EmailId == loginDto.EmailId);
            if (user == null)
            {
                return false;
            }
            else
            {
                passwordHash = user.PasswordHash;
                passwordSalt = user.PasswordSalt;
                if (VerfiyPasswordHash(loginDto.Password, passwordHash, passwordSalt))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private bool VerfiyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        private bool isUserExist(string emailId)
        {
            if (_saxondbContext.Customer.Any(x => x.EmailId == emailId))
                return true;
            else
                return false;
        }
    }
}
