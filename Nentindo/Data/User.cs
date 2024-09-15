using Microsoft.AspNetCore.Identity;

namespace Nentindo.Data
{
    public static class UserRoles
    {
        public const string Admin = "Admin";
        public const string CEO = "CEO";
        public const string Manager = "Manager";
    }
    public class User: IdentityUser
    {

    }
}
