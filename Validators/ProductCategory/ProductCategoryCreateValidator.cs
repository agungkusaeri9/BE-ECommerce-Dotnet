using FluentValidation;
using backend_dotnet.DTOs.ProductCategory; // pastikan ini ada

namespace backend_dotnet.Validators.ProductCategory
{
    public class ProductCategoryCreateValidator : AbstractValidator<ProductCategoryCreate>
    {
        public ProductCategoryCreateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required");

            RuleFor(x => x.Image)
                .NotNull().WithMessage("Image is required")
                .Must(BeAValidImage).WithMessage("Only JPG, JPEG, PNG files are allowed")
                .Must(HaveValidSize).WithMessage("Max file size is 2MB");
        }

        private bool BeAValidImage(IFormFile? file)
        {
            if (file == null) return false;

            var allowedTypes = new[] { "image/jpeg", "image/png", "image/jpg" };
            return allowedTypes.Contains(file.ContentType);
        }

        private bool HaveValidSize(IFormFile? file)
        {
            const long maxSize = 2 * 1024 * 1024; // 2MB
            return file != null && file.Length <= maxSize;
        }
    }
}
