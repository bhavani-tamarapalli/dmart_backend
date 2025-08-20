//Basic Authentication

//using Dmart_web.Service;
//using Dmart_web.Core.Interfaces;


//using Microsoft.AspNetCore.Authentication;
//using Microsoft.Extensions.Options;
//using System.Net.Http.Headers;
//using System.Security.Claims;
//using System.Text;
//using System.Text.Encodings.Web;

//namespace Dmart_web.Auth
//{

//    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
//    {
//        private readonly IUserService _userService;

//        public BasicAuthenticationHandler(
//            IOptionsMonitor<AuthenticationSchemeOptions> options,
//            ILoggerFactory logger,
//            UrlEncoder encoder,
//            ISystemClock clock,
//            IUserService userService)
//            : base(options, logger, encoder, clock)
//        {
//            _userService = userService;
//        }

//        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
//        {
//            if (!Request.Headers.ContainsKey("Authorization"))
//                return AuthenticateResult.Fail("Unauthorized");

//            try
//            {
//                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
//                var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter ?? "")).Split(':');
//                var username = credentials[0];
//                var password = credentials[1];

//                var user = await _userService.AuthenticateAsync(username, password);
//                if (user == null)
//                    return AuthenticateResult.Fail("Invalid credentials");

//                var claims = new[]
//                {
//                new Claim(ClaimTypes.Name, user.Username),
//                new Claim(ClaimTypes.Role, user.Role)
//            };

//                var identity = new ClaimsIdentity(claims, Scheme.Name);
//                var principal = new ClaimsPrincipal(identity);
//                var ticket = new AuthenticationTicket(principal, Scheme.Name);

//                return AuthenticateResult.Success(ticket);
//            }
//            catch
//            {
//                return AuthenticateResult.Fail("Invalid Authorization Header");
//            }
//        }
//    }


//}

using Dmart_web.Service;
using Dmart_web.Core.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace Dmart_web.Auth
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserService _userService;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IUserService userService)
            : base(options, logger, encoder, clock)
        {
            _userService = userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Unauthorized");

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter ?? "")).Split(':', 2);

                if (credentials.Length != 2)
                    return AuthenticateResult.Fail("Invalid Authorization Header");

                var username = credentials[0];
                var password = credentials[1];

                var user = await _userService.AuthenticateAsync(username, password);
                if (user == null)
                    return AuthenticateResult.Fail("Invalid credentials");

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };

                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail($"Invalid Authorization Header: {ex.Message}");
            }
        }
    }
}



//using Microsoft.AspNetCore.Authentication;
//using Microsoft.Extensions.Options;
//using System.Net.Http.Headers;
//using System.Security.Claims;
//using System.Text;
//using System.Text.Encodings.Web;

//namespace Dmart_web.Auth
//{
//    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
//    {
//        public BasicAuthenticationHandler(
//            IOptionsMonitor<AuthenticationSchemeOptions> options,
//            ILoggerFactory logger,
//            UrlEncoder encoder,
//            ISystemClock clock)
//            : base(options, logger, encoder, clock)
//        {
//        }

//        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
//        {
//            if (!Request.Headers.ContainsKey("Authorization"))
//                return AuthenticateResult.Fail("Missing Authorization Header");

//            try
//            {
//                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
//                var credentialBytes = Convert.FromBase64String(authHeader.Parameter ?? "");
//                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
//                var email = credentials[0];
//                var password = credentials[1];


//                if (email == "bhavani@gmail.com" && password == "bhavani")
//                {
//                    var claims = new[] {
//                        new Claim(ClaimTypes.NameIdentifier, email),
//                        new Claim(ClaimTypes.Name, email),
//                    };
//                    var identity = new ClaimsIdentity(claims, Scheme.Name);
//                    var principal = new ClaimsPrincipal(identity);
//                    var ticket = new AuthenticationTicket(principal, Scheme.Name);
//                    return AuthenticateResult.Success(ticket);
//                }

//                return AuthenticateResult.Fail("Invalid credentials");
//            }
//            catch
//            {
//                return AuthenticateResult.Fail("Invalid Authorization Header");
//            }
//        }
//    }
//}


//using System.Net.Http.Headers;
//using System.Security.Claims;
//using System.Text;
//using System.Text.Encodings.Web;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Options;
//using Dmart_web.Data.Context;
//using Microsoft.EntityFrameworkCore;
//using Dmart_web.Core.Models;

//namespace Dmart_web.Auth
//{
//    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
//    {
//        private readonly DmartContext _context;

//        public BasicAuthenticationHandler(
//            IOptionsMonitor<AuthenticationSchemeOptions> options,
//            ILoggerFactory logger,
//            UrlEncoder encoder,
//            ISystemClock clock,
//            DmartContext context) : base(options, logger, encoder, clock)
//        {
//            _context = context;
//        }

//        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
//        {
//            if (!Request.Headers.ContainsKey("Authorization"))
//                return AuthenticateResult.Fail("Missing Authorization Header");

//            try
//            {
//                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
//                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
//                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);
//                var email = credentials[0];
//                var password = credentials[1];

//                //var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
//                //if (customer == null || !BCrypt.Net.BCrypt.Verify(password, customer.Password))
//                //    return AuthenticateResult.Fail("Invalid Username or Password");

//                var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
//                if (customer == null || !BCrypt.Net.BCrypt.Verify(password, customer.Password))
//                    return AuthenticateResult.Fail("Invalid Username or Password");



//                // Create Claims
//                // Replace with your actual property names
//                var claims = new[]
//                {
//                     new Claim(ClaimTypes.NameIdentifier, customer.CustomerId.ToString()), 
//                     new Claim(ClaimTypes.Name, customer.Email),
//                     //new Claim(ClaimTypes.Role, customer.Role ?? "Customer") 
//                       new Claim(ClaimTypes.Role, customer.Role ?? "Customer")
//                };


//                var identity = new ClaimsIdentity(claims, Scheme.Name);
//                var principal = new ClaimsPrincipal(identity);
//                var ticket = new AuthenticationTicket(principal, Scheme.Name);

//                return AuthenticateResult.Success(ticket);
//            }
//            catch
//            {
//                return AuthenticateResult.Fail("Invalid Authorization Header");
//            }
//        }
//    }
//}


