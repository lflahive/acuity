using Acuity.Core.Data;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Net.NetworkInformation;
using System.Security.Claims;

namespace Acuity.Core.Features.User.UserDetails
{
    public class UserDetailsModule : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/user").RequireAuthorization();

            group.MapGet("/", GetUserDetails);
        }

        private async Task<IResult> GetUserDetails(IMediator mediator, ClaimsPrincipal user)
        {
            if (user?.Identity?.Name == null)
            {
                return TypedResults.Unauthorized(); ;
            }

            var id = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (id == null)
            {
                return TypedResults.Unauthorized();
            }

            var userDetails = await mediator.Send(new UserDetailsCommand(id));

            return TypedResults.Ok(userDetails);
        }
    }
}
