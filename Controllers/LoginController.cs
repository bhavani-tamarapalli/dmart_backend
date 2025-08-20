//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication.Google;
//using Microsoft.AspNetCore.Mvc;

//namespace Dmart_web.Controllers
//{
//    public class LoginController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }


//        public async Task Login()
//        {
//            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme,new AuthenticationProperties
//            {
//                RedirectUri= Url.Action("GoogleResponse")
//            });
//        }

//        public async Task<IActionResult> GoogleResponse()
//        {
//            var result=await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

//            var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(claim => new
//            {
//                claim.Issuer,
//                claim.OriginalIssuer,
//                claim.Type,
//                claim.Value
//            });

//            return Json(claims);
//        }
//    }
//}




using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;

namespace Dmart_web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Starts Google login
        public async Task<IActionResult> Login()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        // Called by Google after login
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var claims = result.Principal.Identities.FirstOrDefault()?.Claims.Select(claim => new
            {
                claim.Issuer,
                claim.OriginalIssuer,
                claim.Type,
                claim.Value
            });

            return View("GoogleProfile", claims); // optional view to show profile data
        }

        // Logs the user out
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}
