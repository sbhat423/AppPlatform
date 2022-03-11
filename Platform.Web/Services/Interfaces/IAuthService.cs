namespace Platform.Web.Services.Interfaces
{
    public interface IAuthService
    {
        Task<Guid> GetUserId();
    }
}
