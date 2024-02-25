using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Yummy.Server.Application.Interfaces;

namespace Yummy.Server.Application.Categories.Queries.GetCategories;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, GetCategoriesListDto>
{
    private readonly IYummyDbContext _dbContext;

    private readonly IMapper _mapper;

    public GetCategoriesQueryHandler(IYummyDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<GetCategoriesListDto> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _dbContext.Categories
            .ProjectTo<GetCategoriesDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new GetCategoriesListDto
        {
            Categories = categories
        };
    }
}