using MediatR;
using Microsoft.EntityFrameworkCore;
using Yummy.Server.Application.Common.Exceptions;
using Yummy.Server.Application.Interfaces;
using Yummy.Server.Domain;

namespace Yummy.Server.Application.Dishes.Commands.UpdateDish;

public class UpdateDishCommandHandler : IRequestHandler<UpdateDishCommand>
{
    private readonly IYummyDbContext _dbContext;

    public UpdateDishCommandHandler(IYummyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(UpdateDishCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Dishes
            .Where(c => c.Id == request.Id)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        if (entity == null)
            throw new NotFoundException(nameof(Dish), request.Id);

        if (entity.CategoryId != request.CategoryId)
        {
            var category = await _dbContext.Categories
                .Where(c => c.Id == request.CategoryId)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);

            if (category == null)
                throw new NotFoundException(nameof(Category), request.CategoryId);
        }

        entity.Id = request.Id;
        entity.CategoryId = request.CategoryId;
        entity.Calories = request.Calories;
        entity.Description = request.Description;
        entity.Price = request.Price;
        entity.Name = request.Name;
        entity.PercentageDiscount = request.PercentageDiscount;

        _dbContext.Dishes.Update(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}