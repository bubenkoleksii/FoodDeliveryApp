using FluentValidation;

namespace Yummy.Server.Application.Orders.Commands.UpdateOrderStatus;

public class UpdateOrderStatusCommandValidator : AbstractValidator<UpdateOrderStatusCommand>
{
    public UpdateOrderStatusCommandValidator()
    {
        RuleFor(order => order.Status)
            .NotEmpty()
            .Must(OrderConstants.Status.IsValidStatus)
            .MaximumLength(250);

        RuleFor(order => order.Id)
            .NotNull()
            .NotEqual(Guid.Empty);
    }
}