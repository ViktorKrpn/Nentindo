using Microsoft.AspNetCore.Mvc;
using Nentindo.Core.Domain.Users;
using Nentindo.Data;
using System.Security.Claims;

namespace Nentindo.Presentation.Controllers
{
    public class NentindoControllerBase : ControllerBase
    {
        public DatabaseContext Db { get; set; }
        public User CurrentUser2 { get { return CurrentUser(); } }
        public NentindoControllerBase(DatabaseContext db) { 
            Db = db;
        }

        public User CurrentUser()
        {
            var userId = User.Claims
                       .First(i => i.Type == ClaimTypes.NameIdentifier).Value;
            return Db.Users
                .Where(user => user.Id == Int32.Parse(userId))
                .FirstOrDefault();
        }
    }
}
