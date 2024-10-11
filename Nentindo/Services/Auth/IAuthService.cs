using Nentindo.Core.Domain.Users;
using Nentindo.Presentation.Models;
using Nentindo.Presentation.Models.Auth.Requests;

namespace Nentindo.Services.Auth
{
    public interface IAuthService
    {
        public Task<GenericResponse<bool>> Register(RegisterUserRequest request);
        public string GenerateToken(User user);
        public Task<GenericResponse<User>> VerifyCredentials(LoginRequest request);

    }
}
