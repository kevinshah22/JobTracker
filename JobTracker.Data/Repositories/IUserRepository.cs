using System.Linq.Expressions;

namespace JobTracker.Data.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Add User 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<int> Create(Data.Models.User user);

        /// <summary>
        /// update User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<int> Update(Data.Models.User user);

        /// <summary>
        /// Get User based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<Data.Models.User> GetUser(Expression<Func<Data.Models.User, bool>> predicate);

        /// <summary>
        /// Get list of User based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<Data.Models.User>> GetUsers();
    }
}
