using System.Security.Claims;

namespace ApiFirebase.Repository
{
    public interface IAuthRepositorycs
    {
        string TokenValidate(ClaimsIdentity claimsIdentity);
    }
}
