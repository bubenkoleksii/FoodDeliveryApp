using MediatR;
using Microsoft.EntityFrameworkCore;
using Yummy.Server.Application.Common.Exceptions;
using Yummy.Server.Application.Interfaces;
using Yummy.Server.Domain;

namespace Yummy.Server.Application.Dishes.Commands.DeleteDish;

public class DeleteDishCommandHandler : IRequestHandler<DeleteDishCommand>
{
    private readonly IYummyDbContext _dbContext;

    public DeleteDishCommandHandler(IYummyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(DeleteDishCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Dishes
            .Where(c => c.Id == request.Id)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        if (entity == null)
            throw new NotFoundException(nameof(Dish), request.Id);

        _dbContext.Dishes.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}