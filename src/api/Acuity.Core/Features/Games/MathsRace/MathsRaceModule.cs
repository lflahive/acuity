using Acuity.Core.Features.User.UserDetails;
using Carter;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Security.Claims;

namespace Acuity.Core.Features.Games.MathsRace
{
    public class MathsRaceModule : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/game/mathsrace");

            group.MapPost("join", JoinGame);
        }

        private async Task<IResult> JoinGame(MathsRaceRequest request, IValidator<MathsRaceRequest> validator, IMediator mediator, ClaimsPrincipal user)
        {
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return TypedResults.BadRequest(validationResult.Errors);
            }

            return TypedResults.Ok(request.Mode);
        }
    }
}
