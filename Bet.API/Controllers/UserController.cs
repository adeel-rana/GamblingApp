namespace Bet.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<UserController> _logger;
    public UserController(IMediator mediator, ILogger<UserController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost]
    [Route("create")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> CreateUserAsync([FromBody] CreateUserCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);
            if (result.StatusCode == StatusCodes.Status200OK)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Unhandled exception in {nameof(UserController)} - {nameof(this.CreateUserAsync)}");
            return BadRequest(ex);
        }
    }
}
