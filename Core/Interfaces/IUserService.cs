//using Dmart_web.Core.DTOs;
//using Dmart_web.Core.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Dmart_web.Core.Interfaces
//{
//    public interface IUserService
//    {
//        Task<string> RegisterAsync(UserRegisterDto dto);
//        Task<User?> AuthenticateAsync(string username, string password);
//    }
//}


using Dmart_web.Core.DTOs;
using Dmart_web.Core.Models;

namespace Dmart_web.Core.Interfaces
{
    public interface IUserService
    {
        Task<string> RegisterAsync(UserRegisterDto dto);
        Task<User?> AuthenticateAsync(string username, string password);
    }
}