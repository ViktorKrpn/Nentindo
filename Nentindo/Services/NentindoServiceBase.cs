using Nentindo.Core.Domain.Users;
using Nentindo.Data;
using System.Security.Claims;

namespace Nentindo.Services
{
    public class NentindoServiceBase
    {
        public DatabaseContext Db;
        public User CurrentUser;

        public NentindoServiceBase(DatabaseContext db, IHttpContextAccessor httpContextAccessor)
        {
            Db = db;
            var currentUserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            CurrentUser = db.Users
                .Where(user => user.Id == Int32.Parse(currentUserId))
                .FirstOrDefault();
        }

    }
}
