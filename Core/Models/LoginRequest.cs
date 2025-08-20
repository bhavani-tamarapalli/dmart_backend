
//jwt authentication

namespace Dmart_web.Core.Models
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
