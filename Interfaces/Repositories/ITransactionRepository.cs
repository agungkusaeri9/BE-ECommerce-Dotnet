using backend_dotnet.DTOs.Transaction;
using backend_dotnet.Entities;

namespace backend_dotnet.Interfaces.Repositories
{
    public interface ITransactionRepository
    {
        public Task<Transaction> CreateAsync(Transaction dto);
    }
}
