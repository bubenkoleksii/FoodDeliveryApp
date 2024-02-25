using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yummy.Server.Application.Categories.Commands.CreateCategory;
using Yummy.Server.Application.Categories.Commands.DeleteCategory;
using Yummy.Server.Application.Categories.Commands.UpdateCategory;
using Yummy.Server.Application.Categories.Queries.GetCategories;
using Yummy.Server.Application.Categories.Queries.GetCategoryWithDishes;
using Yummy.Server.WebApi.Models.Category;

namespace Yummy.Server.WebApi.Controllers;

[Route("api/[controller]")]
public class CategoryController : BaseController
{
    private readonly IMapper _mapper;

    public CategoryController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<GetCategoriesListDto>> GetAll()
    {
        var query = new GetCategoriesQuery();

        var categories = await Mediator.Send(query);
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetCategoryWithDishesDto>> GetOneWithDishes(Guid id)
    {
        var query = new GetCategoryWithDishesQuery
        {
            Id = id
        };

        var category = await Mediator.Send(query);
        return Ok(category);
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateCategoryDto createCategoryDto)
    {
        var command = _mapper.Map<CreateCategoryCommand>(createCategoryDto);

        var categoryId = await Mediator.Send(command);
        return Ok(categoryId);
    }

    [HttpPut]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryDto updateCategoryDto)
    {
        var command = _mapper.Map<UpdateCategoryCommand>(updateCategoryDto);

        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteCategoryCommand
        {
            Id = id
        };

        await Mediator.Send(command);
        return NoContent();
    }
}