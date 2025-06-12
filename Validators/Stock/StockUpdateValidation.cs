using backend_dotnet.DTOs.Brand;
using backend_dotnet.DTOs.Stock;
using FluentValidation;

namespace backend_dotnet.Validators.Brand
{
    public class StockUpdateValidation : AbstractValidator<StockUpdateDTO>
    {
        public StockUpdateValidation()
        {
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Type is required");

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Product Id is required");

            RuleFor(x => x.Qty)
                .NotEmpty()
                .WithMessage("Qty is required");
        }

    }
}