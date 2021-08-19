using AutoMapper;
using CinemaSystemAPI.Entities;
using CinemaSystemAPI.Exceptions;
using CinemaSystemAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSystemAPI.Services
{
    public class AccountService :IAccountService
    {
        private readonly IMapper mapper;
        private readonly IPasswordHasher<User> passwordHasher;
        private readonly CinemaDbContext cinemaDbContext;
        private readonly AuthenticationSettings authenticationSettings;

        public AccountService(IMapper mapper,
            IPasswordHasher<User> passwordHasher,
            CinemaDbContext cinemaDbContext,
            AuthenticationSettings authenticationSettings)
        {
            this.mapper = mapper;
            this.passwordHasher = passwordHasher;
            this.cinemaDbContext = cinemaDbContext;
            this.authenticationSettings = authenticationSettings;
        }

        public string GenerateJwt(LoginUserDto loginUserDto)
        {
            var user = cinemaDbContext.Users.Include(y => y.Role).FirstOrDefault(x => x.Email == loginUserDto.Email);
            if (user is null)
            {
                throw new BadRequestException("Invalid username or password");
            }
            var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginUserDto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid username or password");
            }
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, $"{user.Role}")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(authenticationSettings.JwtExpireDays);
            var token = new JwtSecurityToken(authenticationSettings.JwtIssuer, authenticationSettings.JwtIssuer, claims,
                expires: expires, signingCredentials: cred);
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        public void RegisterUser(RegisterUserDto registerUserDto)
        {
            if (registerUserDto == null)
            {
                throw new IsNullOrEmptyException("Object is null or empty");
            }

            var user = mapper.Map<User>(registerUserDto);

            user.PasswordHash = passwordHasher.HashPassword(user, registerUserDto.Password);

            var role = cinemaDbContext.Roles.FirstOrDefault(x => x.Id == user.RoleId);

            user.Role = role;

            cinemaDbContext.Users.Add(user);

            cinemaDbContext.SaveChanges();
        }
    }
}
