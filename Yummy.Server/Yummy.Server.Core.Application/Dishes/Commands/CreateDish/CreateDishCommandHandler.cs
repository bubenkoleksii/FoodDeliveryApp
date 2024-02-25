using MediatR;
using Microsoft.EntityFrameworkCore;
using Yummy.Server.Application.Common.Exceptions;
using Yummy.Server.Application.Interfaces;
using Yummy.Server.Domain;

namespace Yummy.Server.Application.Dishes.Commands.CreateDish;

public class CreateDishCommandHandler : IRequestHandler<CreateDishCommand, Guid>
{
    private readonly IYummyDbContext _dbContext;

    public CreateDishCommandHandler(IYummyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Categories
            .Where(c => c.Id == request.CategoryId)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        if (entity == null)
            throw new NotFoundException(nameof(Category), request.CategoryId);

        var dish = new Dish
        {
            Id = new Guid(),
            CategoryId = request.CategoryId,
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Calories = request.Calories,
            PercentageDiscount = request.PercentageDiscount
        };

        await _dbContext.Dishes.AddAsync(dish, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return dish.Id;
    }
}