using FluentValidation;

namespace Yummy.Server.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(order => order.UserId)
            .NotNull()
            .NotEqual(Guid.Empty);

        RuleFor(order => order.OrderItems)
            .NotNull()
            .NotEmpty()
            .Must(orderItems => orderItems != null && orderItems.Any());
    }
}