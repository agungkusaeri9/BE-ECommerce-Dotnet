using System.Transactions;
using backend_dotnet.DTOs.Transaction;

namespace backend_dotnet.Interfaces.Services
{
    public interface ITransactionService
    {
        public Task<Transaction> CreateAsync(TransactionCreateDTO dto);
    }
}
