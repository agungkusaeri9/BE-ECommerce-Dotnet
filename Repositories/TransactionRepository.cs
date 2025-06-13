using backend_dotnet.Data;
using backend_dotnet.DTOs.Transaction;
using backend_dotnet.Entities;
using backend_dotnet.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _appDbContext;
        public TransactionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Transaction> CreateAsync(Transaction transaction)
        {
            var Code = await GetNextTransactionCodeAsync();
            transaction.Code = Code;
            _appDbContext.Add(transaction);
            await _appDbContext.SaveChangesAsync();
            return transaction;
        }

        public async Task<string> GetNextTransactionCodeAsync()
        {
            try
            {
                // Get the last transaction code
                var lastTransaction = await _appDbContext.Transactions
                    .OrderByDescending(t => t.Id)
                    .FirstOrDefaultAsync();

                if (lastTransaction == null)
                {
                    return "TRX001";
                }

                var lastCode = lastTransaction.Code;
                if (string.IsNullOrEmpty(lastCode))
                {
                    return "TRX001";
                }

                // Extract the number from the last code
                var numberStr = lastCode.Replace("TRX", "");
                if (int.TryParse(numberStr, out int lastNumber))
                {
                    // Increment and format with leading zeros
                    return $"TRX{(lastNumber + 1).ToString("D3")}";
                }

                return "TRX001";
            }
            catch (Exception)
            {
                // If any error occurs, return the default code
                return "TRX001";
            }
        }
    }
}
