namespace JobTracker.API.Services
{
    public class UserClaimService : IUserClaimService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserClaimService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int UserId => Convert.ToInt32(_httpContextAccessor.HttpContext?.User?.FindFirst("UserId")?.Value);
        public string Email => _httpContextAccessor.HttpContext?.User?.FindFirst("Email")?.Value;
    }
}
