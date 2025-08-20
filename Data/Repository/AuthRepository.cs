//using Dmart_web.Core.Models;
//using Dmart_web.Data.Context;
//using Microsoft.EntityFrameworkCore;

//namespace Dmart_web.Data.Repository
//{
//    public class AuthRepository : BaseRepository<Customer>
//    {
//        private readonly DmartContext _context;

//        public AuthRepository(DmartContext context):base(context)
//        {
//            _context = context;
//        }

//        public async Task<Customer?> GetByEmailAsync(string email)
//        {
//            return await _context.Customers.FirstOrDefaultAsync(u => u.Email == email);
//        }

//        public async Task AddAsync(Customer customer)
//        {
//            _context.Customers.Add(customer);
//            await _context.SaveChangesAsync();
//        }
//    }
//}



//using Dmart_web.Core.Models;
//using Dmart_web.Data.Context;
//using Microsoft.EntityFrameworkCore;

//namespace Dmart_web.Data.Repository
//{
//    public class AuthRepository
//    {
//        private readonly DmartContext _context;

//        public AuthRepository(DmartContext context)
//        {
//            _context = context;
//        }

//        // Get customer by email
//        public async Task<Customer?> GetByEmailAsync(string email)
//        {
//            return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
//        }

//        // Add customer
//        public async Task AddAsync(Customer customer)
//        {
//            if (customer == null) throw new ArgumentNullException(nameof(customer));
//            _context.Customers.Add(customer);
//            await _context.SaveChangesAsync();
//        }

//        // Get all customers
//        public async Task<List<Customer>> GetAllAsync()
//        {
//            return await _context.Customers.AsNoTracking().ToListAsync();
//        }

//        // Get customer by ID
//        public async Task<Customer?> GetByIdAsync(int id)
//        {
//            return await _context.Customers.FindAsync(id);
//        }

//        // Update customer
//        public async Task UpdateAsync(Customer customer)
//        {
//            if (customer == null) throw new ArgumentNullException(nameof(customer));
//            _context.Customers.Update(customer);
//            await _context.SaveChangesAsync();
//        }

//        // Delete customer
//        public async Task DeleteAsync(Customer customer)
//        {
//            if (customer == null) throw new ArgumentNullException(nameof(customer));
//            _context.Customers.Remove(customer);
//            await _context.SaveChangesAsync();
//        }
//    }
//}
