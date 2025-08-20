//Basic Authentication

//using Dmart_web.Core.Models;
//using Dmart_web.Data.Context;
//using Microsoft.EntityFrameworkCore;

//namespace Dmart_web.Data.Repository
//{
//    public interface IUserRepository
//    {

//        //Task<User?> GetByUsernamePasswordAsync(string username, string password);
//        Task<bool> IsUsernameTakenAsync(string username);
//        Task AddUserAsync(User user);

//        Task<User?> GetByUsernameAsync(string username);


//    }
//}
using Dmart_web.Core.Models;

namespace Dmart_web.Data.Repository
{
    public interface IUserRepository
    {
        Task<bool> IsUsernameTakenAsync(string username);
        Task AddUserAsync(User user);
        Task<User?> GetByUsernameAsync(string username);
        Task<bool> IsEmailTakenAsync(string email); // Added for better validation
    }
}