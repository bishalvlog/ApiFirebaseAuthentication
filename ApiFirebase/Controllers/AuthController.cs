using ApiFirebase.Repository;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace ApiFirebase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepositorycs _authRepositorycs;
        private readonly FirebaseApp _firebaseApp;
        public AuthController(IAuthRepositorycs authRepositorycs,IConfiguration configuration) 
        {
            _authRepositorycs = authRepositorycs;
            var firebaseCredentailPath = configuration["FirebaseCredentialsPath"];
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(firebaseCredentailPath)
            });


        }
        [Authorize]
        [HttpPost("authfirebasetoken")]
        public IActionResult AuthFireBaseToken()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            dynamic userId =_authRepositorycs.TokenValidate(claimsIdentity);
            return new  OkObjectResult(userId);
        }
        [Authorize]
        [HttpGet ("firebaseemailregister")]
        public IActionResult FirebaseEmailRegister()
        {
            var user = HttpContext.User;
            var claims = ((ClaimsIdentity)User.Identity).Claims;
            var items =claims.ToList();
            var jsonstr =items.Last().Value;
            FirebaseIdentity fb =(FirebaseIdentity)JsonConvert.DeserializeObject(jsonstr, typeof(FirebaseIdentity));
            string email = fb.Identities.Emails[0];
            return new OkObjectResult(email);
        }
    }
}
