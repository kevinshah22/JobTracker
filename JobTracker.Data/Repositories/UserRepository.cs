using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JobTracker.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly JobTrackerContext _context;
        public UserRepository(JobTrackerContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add User 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<int> Create(Data.Models.User user)
        {
            _context.Users.Add(user);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// update User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<int> Update(Data.Models.User user)
        {
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get User based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<Data.Models.User> GetUser(Expression<Func<Data.Models.User, bool>> predicate)
        {
            return await _context.Users.FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Get list of User based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<List<Data.Models.User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
