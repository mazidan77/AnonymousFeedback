using AnonymousFeedback.Application.Dtos.IdentityDto;
using AnonymousFeedback.Domian.IHelpers;
using AnonymousFeedback.Domian.IManagers;
using AnonymousFeedback.Domian.IRepositories;
using AnonymousFeedback.Domian.IUnitOfWork;
using AnonymousFeedback.Domian.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace AnonymousFeedback.Application.Managers
{
    public class IdentityManager :BaseManager<User>, IIdentityManager
    {
        private readonly IRepository<User> _IdentityRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IConfiguration _configuration;
        public IdentityManager(IUnitOfWork unitOfWork, IRepository<User> IdentityRepository, IPasswordHasher passwordHasher , IConfiguration configuration) : base(unitOfWork, IdentityRepository)
        {
            _IdentityRepository = IdentityRepository;
            _passwordHasher = passwordHasher;
            _configuration = configuration; 
        }

        public async Task<User> RegisterAsync(RegisterDto dto)
        {
            var existingUser = await _IdentityRepository.GetBy(x=>x.UserName==dto.UserName);
            if (existingUser != null)
                throw new InvalidOperationException("User already exists!");

            var user = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Password = _passwordHasher.HashPassword(dto.Password),
                FirstName= dto.FirstName,
                LastName= dto.LastName
                
            };

            await _IdentityRepository.AddAsync(user);
             await _unitOfWork.Complete();

            return user;
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _IdentityRepository.GetBy(x=>x.UserName==dto.UserName);
            if (user == null || !_passwordHasher.VerifyPassword(dto.Password, user.Password))
                throw new UnauthorizedAccessException("Invalid credentials!");

            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                   new Claim("UserName",user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.Name),
                new Claim("FName", user.FirstName),
                new Claim("LName", user.LastName),
               
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }




    }
}
