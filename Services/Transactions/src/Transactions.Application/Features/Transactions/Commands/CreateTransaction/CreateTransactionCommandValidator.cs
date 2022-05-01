using FluentValidation;

namespace Transactions.Application.Features.Transactions.Commands.CreateTransaction
{
    internal class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
    {
        public CreateTransactionCommandValidator()
        {
            RuleFor(p => p.Balance)
                .NotEmpty().WithMessage("{PropertyName} es requerido")
                .GreaterThan(1).WithMessage("El {PropertyName} minimo para ser transferido debe ser mayor a $1.00");

            RuleFor(p => p.OriginCard)
                .NotEmpty().WithMessage("{PropertyName} es requerido")
                .Length(16).WithMessage("El {PropertyName} de tarjeta origen tiene un formato invalido");

            RuleFor(p => p.DestinationCard)
                .NotEmpty().WithMessage("{PropertyName} es requerido")
                .Length(16).WithMessage("El {PropertyName} de tarjeta destino tiene un formato invalido");

            RuleFor(p => p.Amount)
                .NotEmpty().WithMessage("{PropertyName} es requerido")
                .GreaterThan(1).WithMessage("El {PropertyName} debe ser mayor a $1.00")
                .LessThanOrEqualTo(p => p.Balance).WithMessage(" El {AmountName} debe ser igual o menor a {BalanceName}");

            RuleFor(p => p.ReferenceNumber)
                .Length(6).WithMessage("La {PropertyName} debe ser contener 6 caracteres numericos")
                .Matches(@"^\d{6}$").WithMessage("La {PropertyName} debe ser contener 6 caracteres numericos");
        }
    }
}
