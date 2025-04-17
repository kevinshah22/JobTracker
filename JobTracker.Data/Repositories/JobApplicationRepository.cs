using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JobTracker.Data.Repositories
{
    public class JobApplicationRepository : IJobApplicationRepository
    {
        private readonly JobTrackerContext _context;
        public JobApplicationRepository(JobTrackerContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add item 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<int> Create(Data.Models.JobApplication jobApplicaton)
        {
            _context.JobApplications.Add(jobApplicaton);
            await _context.SaveChangesAsync();

            return jobApplicaton.Id;
        }

        /// <summary>
        /// update item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<int> Update(Data.Models.JobApplication jobApplicaton)
        {
            _context.Entry(jobApplicaton).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<int> Delete(Data.Models.JobApplication jobApplicaton)
        {
            _context.Entry(jobApplicaton).State = EntityState.Deleted;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get item based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<Data.Models.JobApplication> GetItem(Expression<Func<Data.Models.JobApplication, bool>> predicate)
        {
            Data.Models.JobApplication item = await _context.JobApplications.Where(predicate).AsNoTracking().FirstOrDefaultAsync();
            return item;
        }

        /// <summary>
        /// Get list of items based on predicate
        /// </summary>        
        /// <returns></returns>
        public async Task<List<Data.Models.JobApplication>> GetJobs(Expression<Func<Data.Models.JobApplication, bool>> predicate)
        {
            return await _context.JobApplications.Where(predicate).AsNoTracking().ToListAsync();
        }
    }
}
