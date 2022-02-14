using Bet.Domain.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace Bet.API.Application.Commands
{
    public record CreateBetCommand(double Points, int BetNumber) : IRequest<ResponseInfo>
    {
        [JsonIgnore]
        public string UserId { get; set; }
    }
} 
