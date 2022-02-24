namespace Bet.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BetController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<BetController> _logger;
    public BetController(IMediator mediator, ILogger<BetController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost("create")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> PostAsync(CreateBetCommand command)
    {
        try
        {
            var betCommand = new CreateBetCommand(command.Points, command.BetNumber);
            betCommand.UserId = User.Identity.UserId();
            var result = await _mediator.Send(betCommand);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Unhandled exception occurred in {nameof(this.PostAsync)}.");
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync()
    {
        try
        {
            var userId = User.Identity.UserId();
            var result = await _mediator.Send(new BetQueries(userId));
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Unhandled exception occurred in {nameof(this.GetAsync)}.");
            return BadRequest(ex.Message);
        }
    }
}
