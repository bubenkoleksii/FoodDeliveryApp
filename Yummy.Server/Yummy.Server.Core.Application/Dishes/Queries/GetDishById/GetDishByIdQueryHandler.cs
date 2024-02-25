using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Yummy.Server.Application.Common.Exceptions;
using Yummy.Server.Application.Interfaces;
using Yummy.Server.Domain;

namespace Yummy.Server.Application.Dishes.Queries.GetDishById;

public class GetDishByIdQueryHandler : IRequestHandler<GetDishByIdQuery, GetDishByIdDto>
{
    private readonly IYummyDbContext _dbContext;

    private readonly IMapper _mapper;

    public GetDishByIdQueryHandler(IYummyDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<GetDishByIdDto> Handle(GetDishByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Dishes
            .Where(c => c.Id == request.Id)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        if (entity == null)
            throw new NotFoundException(nameof(Category), request.Id);

        var dish = _mapper.Map<GetDishByIdDto>(entity);
        return dish;
    }
}