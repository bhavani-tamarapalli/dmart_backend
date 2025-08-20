/*

using Dmart_web.Core.DTOs;
using Dmart_web.Core.Models;
using Dmart_web.Core.Interfaces;
using Dmart_web.Data.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace Dmart_web.Service
{
    public class AuthService : IAuthService
    {
        private readonly AuthRepository _authRepository;

        public AuthService(AuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<string> RegisterAsync(RegisterDTO registerDto)
        {
            // Check if email already exists
            var existingUser = await _authRepository.GetByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                return "Email already exists";
            }

            // Hash password
            var hashedPassword = HashPassword(registerDto.Password);

            // Save new customer
            var customer = new Customer
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                Password = hashedPassword
            };

            await _authRepository.AddAsync(customer);
            return "Registration successful";
        }

        public async Task<string> LoginAsync(LoginDTO loginDto)
        {
            var user = await _authRepository.GetByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return "Invalid credentials";
            }

            var hashedPassword = HashPassword(loginDto.Password);
            if (user.Password != hashedPassword)
            {
                return "Invalid credentials";
            }

            return "Login successful";
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }
}
*/


//using Dmart_web.Core.DTOs;
//using Dmart_web.Core.Interfaces;
//using Dmart_web.Core.Models;
//using Dmart_web.Data.Repository;
//using Microsoft.EntityFrameworkCore;

//namespace Dmart_web.Service
//{
//    public class AuthService : IAuthService
//    {
//        private readonly AuthRepository _authRepository;

//        public AuthService(AuthRepository authRepository)
//        {
//            _authRepository = authRepository;
//        }

//        //  REGISTER
//        public async Task<string> RegisterAsync(RegisterDTO registerDto)
//        {
//            var existingUser = await _authRepository.GetByEmailAsync(registerDto.Email);
//            if (existingUser != null)
//                return "Email already exists";

//            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

//            var newCustomer = new Customer
//            {
//                FullName = registerDto.FullName,
//                Email = registerDto.Email,
//                Password = hashedPassword,
//                Role = "Customer"
//            };

//            await _authRepository.AddAsync(newCustomer);
//            return "Registration successful";
//        }

//        //  LOGIN
//        public async Task<string> LoginAsync(LoginDTO loginDto)
//        {
//            var customer = await _authRepository.GetByEmailAsync(loginDto.Email);

//            if (customer == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, customer.Password))
//                return "Invalid credentials";

//            return "Login successful";
//        }


//        // GET all users
//        //public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
//        //{
//        //    var users = await _authRepository.GetAllAsync();
//        //    return users.Select(u => new UserDTO
//        //    {
//        //        CustomerId = u.CustomerId,
//        //        FullName = u.FullName,
//        //        Email = u.Email
//        //    });
//        //}


//        //public async Task<UserDTO?> GetUserByIdAsync(int userId)
//        //{
//        //    var user = await _authRepository.GetByIdAsync(userId);
//        //    if (user == null) return null;

//        //    return new UserDTO
//        //    {
//        //        CustomerId = user.CustomerId,
//        //        FullName = user.FullName,
//        //        Email = user.Email
//        //    };
//        //}



//        ////  UPDATE user
//        //public async Task<bool> UpdateUserAsync(int id, UpdateUserDTO updateDto)
//        //{
//        //    var user = await _authRepository.GetByIdAsync(id);
//        //    if (user == null) return false;

//        //    user.FullName = updateDto.FullName;
//        //    if (!string.IsNullOrEmpty(updateDto.Password))
//        //    {
//        //        user.Password = updateDto.Password;
//        //    }

//        //    await _authRepository.UpdateAsync(user);
//        //    return true;
//        //}

//        //  DELETE user
//        //public async Task<bool> DeleteUserAsync(int id)
//        //{
//        //    var user = await _authRepository.GetByIdAsync(id);
//        //    if (user == null) return false;

//        //    await _authRepository.DeleteAsync(user);
//        //    return true;
//        //}

//        public async Task<Customer?> GetByEmailAsync(string email)
//        {
//            return await _authRepository.GetByEmailAsync(email);
//        }

//        public async Task AddAsync(Customer customer)
//        {
//            await _authRepository.AddAsync(customer);
//        }


//    }
//}
