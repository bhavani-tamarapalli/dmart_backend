//Basic Authentication

//using Dmart_web.Core.Models;
//using Dmart_web.Data.Context;
//using Microsoft.EntityFrameworkCore;


//namespace Dmart_web.Data.Repository
//{
//    public class UserRepository : IUserRepository 
//    {
//        private readonly DmartContext dbContext;

//        public UserRepository(DmartContext dbContext)
//        {
//            this.dbContext = dbContext;
//        }

//        public async Task AddUserAsync(User user)
//        {
//            dbContext.Users.Add(user);
//            await dbContext.SaveChangesAsync();
//        }

//        public async Task<bool> IsUsernameTakenAsync(string username)
//        {
//            return await dbContext.Users.AnyAsync(u => u.Username == username);
//        }

//        public async Task<User?> GetByUsernameAsync(string username)
//        {
//            return await dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
//        }
//    }
//}

using Dmart_web.Core.Models;
using Dmart_web.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Dmart_web.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DmartContext _dbContext;

        public UserRepository(DmartContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUserAsync(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsUsernameTakenAsync(string username)
        {
            try
            {
                return await _dbContext.Users.AnyAsync(u => u.Username == username);
            }
            catch (Exception)
            {
                // If Username column doesn't exist yet, return false
                return false;
            }
        }

        public async Task<bool> IsEmailTakenAsync(string email)
        {
            try
            {
                return await _dbContext.Users.AnyAsync(u => u.Email == email);
            }
            catch (Exception)
            {
                // If there's an error, return false to allow registration
                return false;
            }
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            try
            {
                return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
            }
            catch (Exception)
            {
                // If Username column doesn't exist yet, return null
                return null;
            }
        }
    }
}


//namespace Dmart_web.Data.Repository
//{
//    public class userRepository : IUserRepository
//    {
//        private readonly DmartContext dbContext;

//        public UserRepository(DmartContext dbContext)
//        {
//            this.dbContext = dbContext;
//        }

//        public async Task AddUserAsync(User user)
//        {
//            dbContext.user.Add(user);
//            await dbContext.SaveChangesAsync();
//        }

//        //public async Task<User?> GetByUsernamePasswordAsync(string username, string password)
//        //{
//        //    return await dbContext.user.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
//        //}

//        public async Task<bool> IsUsernameTakenAsync(string username)
//        {
//            return await dbContext.user.AnyAsync(u => u.Username == username);
//        }

//        public async Task<User?> GetByUsernameAsync(string username)
//        {
//            return await dbContext.user.FirstOrDefaultAsync(u => u.Username == username);
//        }

//    }
//}


