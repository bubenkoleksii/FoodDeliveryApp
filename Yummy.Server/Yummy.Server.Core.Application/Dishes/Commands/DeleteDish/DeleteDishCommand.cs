using MediatR;

namespace Yummy.Server.Application.Dishes.Commands.DeleteDish;

public class DeleteDishCommand : IRequest
{
    public Guid Id { get; set; }
}