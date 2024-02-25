using FluentValidation;

namespace Yummy.Server.Application.Orders.Queries;

public class GetOrdersByUserIdQueryValidator : AbstractValidator<GetOrdersByUserIdQuery>
{
    public GetOrdersByUserIdQueryValidator()
    {
        RuleFor(order => order.UserId)
            .NotEqual(Guid.Empty);

        RuleFor(order => order.Skip)
            .GreaterThan(-1);

        RuleFor(order => order.Limit)
            .GreaterThan(-1);
    }
}