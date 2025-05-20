using backend_dotnet.DTOs.Brand;
using backend_dotnet.DTOs.PaymentMethod;
using FluentValidation;

namespace backend_dotnet.Validators.Brand
{
    public class PaymentMethodCreateValidator : AbstractValidator<PaymentMethodCreate>
    {
        public PaymentMethodCreateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("Number is required");
            RuleFor(x => x.OwnerName)
                .NotEmpty().WithMessage("OwnerName is required");
            RuleFor(x => x.IsActive)
                .NotEmpty().WithMessage("IsActive is required").
                Must(x => x == true || x == false).WithMessage("IsActive must be true or false");
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Type is required").
                Must(x => x == "Bank Transfer" || x == "Ewallet").WithMessage("Type must be Bank Transfer or Ewallet");
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
