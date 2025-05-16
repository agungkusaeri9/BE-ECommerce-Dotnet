using backend_dotnet.Data;
using backend_dotnet.Entities;
using backend_dotnet.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Repositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly AppDbContext _context;

        public PaymentMethodRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<PaymentMethod> Items, int TotalItems)> GetAllAsync(int pageNumber, int pageSize)
        {
            var query = _context.PaymentMethods.AsQueryable();

            var totalItems = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalItems);
        }

        public async Task<PaymentMethod?> GetByIdAsync(int id)
        {
            return await _context.PaymentMethods.FindAsync(id);
        }

        public async Task<PaymentMethod> CreateAsync(PaymentMethod paymentMethod)
        {
            _context.PaymentMethods.Add(paymentMethod);
            await _context.SaveChangesAsync();
            return paymentMethod;
        }

        public async Task<PaymentMethod> UpdateAsync(PaymentMethod paymentMethod)
        {
            _context.PaymentMethods.Update(paymentMethod);
            await _context.SaveChangesAsync();
            return paymentMethod;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var paymentMethod = await _context.PaymentMethods.FindAsync(id);
            if (paymentMethod == null)
            {
                return false;
            }

            _context.PaymentMethods.Remove(paymentMethod);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
