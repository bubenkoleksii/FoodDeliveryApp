using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yummy.Server.Application.Dishes.Commands.CreateDish;
using Yummy.Server.Application.Dishes.Commands.DeleteDish;
using Yummy.Server.Application.Dishes.Commands.UpdateDish;
using Yummy.Server.Application.Dishes.Queries.GetDishById;
using Yummy.Server.WebApi.Models.Dish;

namespace Yummy.Server.WebApi.Controllers;

[Route("api/[controller]")]
public class DishController : BaseController
{
    private readonly IMapper _mapper;

    public DishController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetDishByIdDto>> GetOneById(Guid id)
    {
        var query = new GetDishByIdQuery
        {
            Id = id
        };

        var dish = await Mediator.Send(query);
        return Ok(dish);
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateDishDto createCategoryDto)
    {
        var command = _mapper.Map<CreateDishCommand>(createCategoryDto);

        var id = await Mediator.Send(command);
        return Ok(id);
    }

    [HttpPut]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<Guid>> Update([FromBody] UpdateDishDto updateDishDto)
    {
        var command = _mapper.Map<UpdateDishCommand>(updateDishDto);

        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteDishCommand
        {
            Id = id
        };

        await Mediator.Send(command);
        return NoContent();
    }
}