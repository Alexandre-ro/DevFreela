namespace DevFreela.CORE.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, string role);
    }
}
