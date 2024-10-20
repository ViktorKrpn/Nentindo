using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.IdentityModel.Tokens;
using Nentindo.Core.Domain.Users;
using Nentindo.Data;
using Nentindo.Presentation.Models;
using Nentindo.Presentation.Models.Auth.Requests;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Nentindo.Services.Auth
{
    public class AuthService: IAuthService 
    {
        DatabaseContext _db;
        PasswordHasher<User> _hasher;
        IConfiguration _config;
        public AuthService(DatabaseContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
            _hasher = new PasswordHasher<User>();
        }

        public async Task<GenericResponse<bool>> Register(RegisterUserRequest request)
        {
            var response = new GenericResponse<bool>();
            
            var existingUser = _db.Users.SingleOrDefault(u => u.Email == request.Email);
            
            if (existingUser != null)
            {
                response.AddError("This email is already used");
                
                return response;
            }

            var newUser = new User
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                CompanyId = request.CompanyId,
            };

            newUser.PasswordHashed = _hasher.HashPassword(newUser, request.Password);

            await _db.Users.AddAsync(newUser);

            await _db.SaveChangesAsync();

            return response;
        }

        public async Task<GenericResponse<User>> VerifyCredentials(Presentation.Models.Auth.Requests.LoginRequest request)
        {
            var response = new GenericResponse<User>();

            var existingUser = _db.Users.SingleOrDefault(u => u.Email == request.Email);

            if (existingUser == null)
            {
                response.AddError("user does not exist");

                return response;
            }

            var passwordVerificationResult = _hasher.VerifyHashedPassword(existingUser, existingUser.PasswordHashed, request.Password);

            if (passwordVerificationResult != PasswordVerificationResult.Success)
            {
                response.AddError("Invalid email or password");

                return response;
            }

            response.Result = existingUser;

            return response;
        }

        public string GenerateToken(User user)
        {
            var claims = new List<Claim>()
            {
               new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
               new Claim(ClaimTypes.Email, user.Email),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Secret"]));
            
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(
              issuer: _config["Jwt:Issuer"],
              audience: _config["Jwt:Audience"],
              claims: claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return token;
        }

    }
}
