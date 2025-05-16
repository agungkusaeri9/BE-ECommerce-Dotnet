using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet.Entities;

namespace backend_dotnet.Interfaces.Repositories
{
    public interface IPaymentMethodRepository
    {
        Task<(IEnumerable<PaymentMethod> Items, int TotalItems)> GetAllAsync(int pageNumber, int pageSize);
        Task<PaymentMethod?> GetByIdAsync(int id);
        Task<PaymentMethod> CreateAsync(PaymentMethod paymentMethod);
        Task<PaymentMethod> UpdateAsync(PaymentMethod paymentMethod);
        Task<bool> DeleteAsync(int id);
    }

}