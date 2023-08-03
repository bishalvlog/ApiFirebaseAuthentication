using System.Security.Claims;

namespace ApiFirebase.Repository
{
    public class AuthRepository : IAuthRepositorycs
    {
        public string TokenValidate(ClaimsIdentity claimsIdentity)
        {
            string userId = (claimsIdentity.Claims).ToList().FirstOrDefault(a => a.Type == "user_Id").Value;
            return userId;
        }
    }
}
