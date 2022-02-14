using Bet.Domain.Models;
using Bet.Domain.Service;
using Bet.Infrastructure.Models;
using Bet.Infrastructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bet.API.Application.Commands
{
    public class CreateBetCommandHandler : IRequestHandler<CreateBetCommand, ResponseInfo>
    {
        private readonly IBettingRepository _repository;
        private readonly IBettingService _bettingService;
        private readonly UserManager<ApplicationUser> _userManager;
        public CreateBetCommandHandler(IBettingRepository repository,
             IBettingService bettingService,
             UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _bettingService = bettingService;
            _userManager = userManager;
        }

        public async Task<ResponseInfo> Handle(CreateBetCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            var balance = _repository.GetBalance(request.UserId);

            if (user == null)
            {
                throw new ArgumentOutOfRangeException($"No user exists for {request.UserId}.");
            }

            if (balance < request.Points)
            {
                throw new BadHttpRequestException($"You don't have sufficient points for the bet.");
            }

            var result = _bettingService.GetBetResponse(new BetRequest(request.Points, request.BetNumber, balance));
            await _repository.CreateAsync(
                new BettingHistory {
                    Points = result.Points,
                    Status = result.Status,
                    UserId = request.UserId,
                    Transaction = new Transaction(request.UserId, result.Points)
                });

            return new ResponseInfo
            {
                StatusCode = StatusCodes.Status200OK,
                Status = result.Status,
                Data = result
            };
        }
    }
}
