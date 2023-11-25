namespace WebApi.Controllers;

using Application.Distances;
using Application.Distances.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Unit = Application.Distances.Unit;

[ApiController]
[Route("[controller]")]
public class DistancesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<DistancesController> _logger;

    public DistancesController(IMediator mediator, ILogger<DistancesController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet]
    [Route("{latitudeA:double}/{longitudeA:double}/{latitudeB:double}/{longitudeB:double}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetDistance(
        double latitudeA,
        double longitudeA,
        double latitudeB,
        double longitudeB,
        [FromQuery] Method? method,
        [FromQuery] Unit? unit,
        CancellationToken cancellationToken)
    {
        try
        {
            method ??= Method.Geodesic;
            unit ??= Unit.Metric;

            var pointA = new Point(latitudeA, longitudeA);
            var pointB = new Point(latitudeB, longitudeB);

            var getDistanceQuery = new GetDistanceQuery(pointA, pointB, method.Value, unit.Value);

            var result = await _mediator.Send(getDistanceQuery, cancellationToken);

            return Ok(new DistanceDto(result));
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing query {nameof(GetDistanceQuery)}.");

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}