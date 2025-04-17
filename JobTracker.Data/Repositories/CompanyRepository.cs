using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JobTracker.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly JobTrackerContext _context;
        public CompanyRepository(JobTrackerContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add company 
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public async Task<int> Create(Models.Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();

            return company.Id;
        }

        /// <summary>
        /// update company
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public async Task<int> Update(Models.Company company)
        {
            _context.Entry(company).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get company based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<Models.Company> GetCompany(Expression<Func<Models.Company, bool>> predicate)
        {
            return await _context.Companies.Where(predicate).AsNoTracking().FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get list of company based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<List<Data.Models.Company>> GetCompanies(Expression<Func<Data.Models.Company, bool>> predicate)
        {
            return await _context.Companies.Where(predicate).AsNoTracking().ToListAsync();
        }
    }
}
