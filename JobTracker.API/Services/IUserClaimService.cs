namespace JobTracker.API.Services
{
    public interface IUserClaimService
    {
        int UserId { get; }
        string Email { get; }
    }
}
