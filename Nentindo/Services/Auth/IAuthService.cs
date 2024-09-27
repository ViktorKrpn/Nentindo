using Nentindo.Core.Domain.User;
using Nentindo.Models;
using Nentindo.Models.Auth.Requests;

namespace Nentindo.Services.Auth
{
    public interface IAuthService
    {
        public Task<GenericResponse<bool>> Register(RegisterUserRequest request);
        public string GenerateToken(User user);
        public Task<GenericResponse<User>> VerifyCredentials(LoginRequest request);

    }
}
