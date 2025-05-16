using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet.DTOs.PaymentMethod;
using backend_dotnet.Entities;
using backend_dotnet.Interfaces;
using backend_dotnet.Interfaces.Repositories;
using backend_dotnet.Interfaces.Services;

namespace backend_dotnet.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _IPaymentMethodRepository;
        private readonly IFileUploadService _fileUploadService;

        public PaymentMethodService(IPaymentMethodRepository repository, IFileUploadService fileUploadService)
        {
            _IPaymentMethodRepository = repository;
            _fileUploadService = fileUploadService;
        }

        public async Task<(IEnumerable<PaymentMethod>, int)> GetAllAsync(int page, int limit)
        {
            return await _IPaymentMethodRepository.GetAllAsync(page, limit);
        }

        public async Task<PaymentMethod?> GetByIdAsync(int id)
        {
            var paymentMethod = await _IPaymentMethodRepository.GetByIdAsync(id);
            if (paymentMethod == null) throw new KeyNotFoundException("Payment Method not found");
            return paymentMethod;
        }

        public async Task<PaymentMethod> CreateAsync(PaymentMethodCreate request)
        {
            string? imagePath = null;
            if (request.Image != null)
            {
                imagePath = await _fileUploadService.UploadAsync(request.Image, "images/payment-method");
            }
            var paymentMethod = new PaymentMethod
            {
                Name = request.Name,
                Number = request.Number,
                OwnerName = request.OwnerName,
                IsActive = request.IsActive,
                Type = request.Type,
                Image = imagePath
            };

            return await _IPaymentMethodRepository.CreateAsync(paymentMethod);
        }


        public async Task<PaymentMethod> UpdateAsync(int id, PaymentMethodUpdate request)
        {
            var existing = await _IPaymentMethodRepository.GetByIdAsync(id);
            if (existing == null) throw new KeyNotFoundException("Payment Method not found");

            if (request.Image != null)
            {
                if (!string.IsNullOrEmpty(existing.Image))
                {
                    await _fileUploadService.DeleteAsync(existing.Image);
                }
                existing.Image = await _fileUploadService.UploadAsync(request.Image, "images/payment-method");
            }

            existing.Name = request.Name;
            existing.Number = request.Number;
            existing.Type = request.Type;
            existing.OwnerName = request.OwnerName;
            existing.IsActive = request.IsActive;

            return await _IPaymentMethodRepository.UpdateAsync(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _IPaymentMethodRepository.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException("Payment Method not found");
            if (!string.IsNullOrEmpty(existing.Image))
            {
                await _fileUploadService.DeleteAsync(existing.Image);
            }
            return await _IPaymentMethodRepository.DeleteAsync(id);
        }
    }
}