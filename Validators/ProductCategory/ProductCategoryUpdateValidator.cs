using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet.DTOs.ProductCategory;
using FluentValidation;

namespace backend_dotnet.Validators.ProductCategory
{
    public class ProductCategoryUpdateValidator : AbstractValidator<ProductCategoryUpdate>
    {
        public ProductCategoryUpdateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required");

            RuleFor(x => x.Image)
            .Must(file => file == null || BeAValidImage(file))
                .WithMessage("Only JPG, JPEG, PNG files are allowed")
            .Must(file => file == null || HaveValidSize(file))
                .WithMessage("Max file size is 2MB");
        }

        private bool BeAValidImage(IFormFile? file)
        {
            if (file == null) return false;

            var allowedTypes = new[] { "image/jpeg", "image/png", "image/jpg" };
            return allowedTypes.Contains(file.ContentType);
        }

        private bool HaveValidSize(IFormFile? file)
        {
            const long maxSize = 2 * 1024 * 1024;
            return file != null && file.Length <= maxSize;
        }
    }
}