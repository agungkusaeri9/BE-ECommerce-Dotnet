using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet.DTOs.PaymentMethod;
using backend_dotnet.Entities;
namespace backend_dotnet.Interfaces.Services
{
    public interface IPaymentMethodService
    {
        Task<(IEnumerable<PaymentMethod> Items, int TotalItems)> GetAllAsync(int pageNumber, int pageSize);
        Task<PaymentMethod?> GetByIdAsync(int id);
        Task<PaymentMethod> CreateAsync(PaymentMethodCreate request);
        Task<PaymentMethod> UpdateAsync(int id, PaymentMethodUpdate request);
        Task<bool> DeleteAsync(int id);
    }
}