using MediatR;
using Microsoft.EntityFrameworkCore;
using Yummy.Server.Application.Common.Exceptions;
using Yummy.Server.Application.Interfaces;
using Yummy.Server.Domain;

namespace Yummy.Server.Application.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IYummyDbContext _dbContext;

    public UpdateCategoryCommandHandler(IYummyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Categories
            .Where(c => c.Id == request.Id)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        if (entity == null)
            throw new NotFoundException(nameof(Category), request.Id);
        
        entity.Name = request.Name;
        entity.Description = request.Description;

        _dbContext.Categories.Update(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}