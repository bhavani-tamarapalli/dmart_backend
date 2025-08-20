//using Dmart_web.Core.DTOs;
//using Dmart_web.Core.Interfaces;
//using Dmart_web.Core.Models;
//using Dmart_web.Data.Repository;
//using Microsoft.EntityFrameworkCore;



//namespace Dmart_web.Service
//{
//    public class UserService : IUserService
//    {
//        private readonly IUserRepository _userRepository;

//        public UserService(IUserRepository userRepository)
//        {
//            this._userRepository = userRepository;
//        }
//        public async Task<User?> AuthenticateAsync(string username, string password)
//        {
//            var user = await _userRepository.GetByUsernameAsync(username);
//            if (user == null) return null;

//            bool isValid = BCrypt.Net.BCrypt.Verify(password, user.Password);

//            return isValid ? user : null;
//        }

//        public async Task<string> RegisterAsync(UserRegisterDto dto)
//        {
//            if (await _userRepository.IsUsernameTakenAsync(dto.Username))
//                return "Username already taken";

//            var user = new User
//            {
//                Username = dto.Username,
//                Email = dto.Email,
//                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password), // hash password
//                Role = dto.Role,
//            };



//            await _userRepository.AddUserAsync(user);
//            return "User registered successfully";
//        }
//    }

//}



using Dmart_web.Core.DTOs;
using Dmart_web.Core.Interfaces;
using Dmart_web.Core.Models;
using Dmart_web.Data.Repository;

namespace Dmart_web.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            try
            {
                var user = await _userRepository.GetByUsernameAsync(username);
                if (user == null) return null;

                bool isValid = BCrypt.Net.BCrypt.Verify(password, user.Password);
                return isValid ? user : null;
            }
            catch (Exception)
            {
                // If username column doesn't exist, return null
                return null;
            }
        }

        public async Task<string> RegisterAsync(UserRegisterDto dto)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(dto.Username))
                    return "Username is required";
                
                if (string.IsNullOrWhiteSpace(dto.Email))
                    return "Email is required";
                    
                if (string.IsNullOrWhiteSpace(dto.Password))
                    return "Password is required";

                // Check if username already exists
                if (await _userRepository.IsUsernameTakenAsync(dto.Username))
                    return "Username already taken";

                // Check if email already exists
                if (await _userRepository.IsEmailTakenAsync(dto.Email))
                    return "Email already registered";

                var user = new User
                {
                    FirstName = dto.FirstName ?? "",
                    LastName = dto.LastName ?? "",
                    Username = dto.Username,
                    Email = dto.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(dto.Password), // hash password
                    Role = dto.Role ?? "Customer", // Default role
                };

                await _userRepository.AddUserAsync(user);
                return "User registered successfully";
            }
            catch (Exception ex)
            {
                return $"Registration failed: {ex.Message}";
            }
        }
    }
}