namespace Bet.API.Application.Commands;
public record CreateBetCommand(double Points, int BetNumber) : IRequest<ResponseInfo>
{
    [JsonIgnore]
    public string UserId { get; set; }
}
