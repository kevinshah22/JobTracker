using System.Linq.Expressions;

namespace JobTracker.Data.Repositories
{
    public interface ICompanyRepository
    {
        /// <summary>
        /// Add company 
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        Task<int> Create(Data.Models.Company company);

        /// <summary>
        /// update company
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        Task<int> Update(Data.Models.Company company);

        /// <summary>
        /// Get company based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<Data.Models.Company> GetCompany(Expression<Func<Data.Models.Company, bool>> predicate);

        /// <summary>
        /// Get list of company based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<Data.Models.Company>> GetCompanies();
    }
}
