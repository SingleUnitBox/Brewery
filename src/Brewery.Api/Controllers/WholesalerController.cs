﻿using Brewery.Abstractions.Commands;
using Brewery.Abstractions.Queries;
using Brewery.Application.Commands;
using Brewery.Application.DTO;
using Brewery.Application.Queries;
using Brewery.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Brewery.Api.Controllers;

public class WholesalerController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public WholesalerController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet("{wholesalerId:guid}")]
    public async Task<ActionResult<WholesalerDto>> Get(Guid wholesalerId)
        => Ok(_queryDispatcher.QueryAsync(new GetWholesaler(wholesalerId)));

    [HttpPost]
    public async Task<ActionResult> Post(AddWholesaler command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return CreatedAtAction(nameof(Get), new { wholesaleerId = command.Id }, null);
    }

    [HttpPost("{wholesalerId:guid}/sale")]
    public async Task<ActionResult> AddSale(AddBeerSale command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return NoContent();
    }
}