using Microsoft.EntityFrameworkCore;
using Nentindo.Core.Domain.Companies;
using Nentindo.Data;
using Nentindo.Presentation.Models;

namespace Nentindo.Services.Companies
{
    public class CompaniesService: NentindoServiceBase
    {
        public CompaniesService(DatabaseContext db, IHttpContextAccessor httpContextAccessor) : base(db, httpContextAccessor)
        {
        }

        public async Task<GenericResponse<List<Company>>> GetAllowedCompanies()
        {
            var response = new GenericResponse<List<Company>>();
            
            if(CurrentUser.CompanyId == 1)
            {
                var allCompnaies = await Db.Companies.ToListAsync();
                response.Result = allCompnaies;
            } else
            {
                var company = await Db.Companies
                    .Where(company => company.Id == CurrentUser.Id)
                    .FirstOrDefaultAsync();

                response.Result = new List<Company> { company }; 
            }
            return response;
        }

    }
}
