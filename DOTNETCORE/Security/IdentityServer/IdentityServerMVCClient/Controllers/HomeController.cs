using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel.Client;
using IdentityServerClient.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace IdentityServerMVCClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles="Admin,Clerk")]
        public async Task<IActionResult> SecureInfo()
        {
//            var token = await HttpContext.GetTokenAsync("access_token");

            //var jwtToken = new JwtSecurityToken(token);
            //var claims = jwtToken.Claims;
            //((ClaimsIdentity) User.Identity).AddClaims(claims);
            return View();
        }
        //private ClaimsIdentity GetClaimsIdentity()
        //{
        //    var user = User;
        //    // Here we can save some values to token.
        //    // For example we are storing here user id and email
        //    Claim[] claims = new[]
        //    {
        //        //new Claim(ClaimTypes.Name, user.Id.ToString()),
        //        //new Claim(ClaimTypes.Email, user.Email)
        //    };
        //    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token");

        //    // Adding roles code
        //    // Roles property is string collection but you can modify Select code if it it's not
        //    //claimsIdentity.AddClaims(user.Roles.Select(role => new Claim(ClaimTypes.Role, role)));
        //    return claimsIdentity;
        //}
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            await HttpContext.SignOutAsync("oidc");
        }
        public async Task<IActionResult> CallApiUsingClientCredentials()
        {
            var tokenClient = new TokenClient("http://localhost:5000/connect/token", "MVCSample", "secret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("myApi");

            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);
            var content = await client.GetStringAsync("http://localhost:5001/identity");

            ViewBag.Json = JArray.Parse(content).ToString();
            return View("json");
        }

        public async Task<IActionResult> CallApiUsingUserAccessToken()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var client = new HttpClient();
            client.SetBearerToken(accessToken);
            var content = await client.GetStringAsync("http://localhost:5001/identity");

            ViewBag.Json = JArray.Parse(content).ToString();
            return View("json");
        }
    }
}
