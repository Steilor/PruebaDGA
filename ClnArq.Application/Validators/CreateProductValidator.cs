using ClnArq.Application.Dtos;
using ClnArq.Application.Dtos.Productos;
using FluentValidation;

namespace ClnArq.Application.Validators;

public class CreateProductValidator : AbstractValidator<ProductosDtoAdd>
{
    public CreateProductValidator()
    {
        RuleFor(dto => dto.Nombre)
             .Length(3, 100);

        RuleFor(dto => dto.Stock)
           .GreaterThanOrEqualTo(0)
           .WithMessage("Stock no puede ser un numero negativo.");


        RuleFor(dto => dto.Precio)
              .GreaterThanOrEqualTo(0)
           .WithMessage("Precio no puede ser un numero negativo.");

    }
}
