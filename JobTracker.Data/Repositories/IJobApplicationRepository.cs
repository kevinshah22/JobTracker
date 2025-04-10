using System.Linq.Expressions;

namespace JobTracker.Data.Repositories
{
    public interface IJobApplicationRepository
    {
        /// <summary>
        /// Add item 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<int> Create(Data.Models.JobApplication jobApplicaton);

        /// <summary>
        /// update item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<int> Update(Data.Models.JobApplication jobApplicaton);

        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<int> Delete(Data.Models.JobApplication jobApplicaton);

        /// <summary>
        /// Get item based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<Data.Models.JobApplication> GetItem(Expression<Func<Data.Models.JobApplication, bool>> predicate);

        /// <summary>
        /// Get list of items based on predicate
        /// </summary>        
        /// <returns></returns>
        Task<List<Data.Models.JobApplication>> GetJobs();
    }
}
