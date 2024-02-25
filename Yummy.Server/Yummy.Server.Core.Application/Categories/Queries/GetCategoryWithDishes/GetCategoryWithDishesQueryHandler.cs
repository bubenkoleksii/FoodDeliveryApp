using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Yummy.Server.Application.Common.Exceptions;
using Yummy.Server.Application.Interfaces;
using Yummy.Server.Domain;

namespace Yummy.Server.Application.Categories.Queries.GetCategoryWithDishes;

public class GetCategoryWithDishesQueryHandler : IRequestHandler<GetCategoryWithDishesQuery, GetCategoryWithDishesDto>
{
    private readonly IYummyDbContext _dbContext;

    private readonly IMapper _mapper;

    public GetCategoryWithDishesQueryHandler(IYummyDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<GetCategoryWithDishesDto> Handle(GetCategoryWithDishesQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Categories
            .Where(c => c.Id == request.Id)
            .Include(c => c.Dishes)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        if (entity == null)
            throw new NotFoundException(nameof(Category), request.Id);

        var dishesByCategory = _mapper.Map<GetCategoryWithDishesDto>(entity);
        return dishesByCategory;
    }
}