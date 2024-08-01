using Acuity.Core.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acuity.Core.Features.User.UserDetails
{
    public class UserDetailsCommand(string id) : IRequest<UserDetailsDTO?>
    {
        public string Id { get; set; } = id;
    }

    public class UserDetailsCommandHandler(AcuityDataContext dataContext) : IRequestHandler<UserDetailsCommand, UserDetailsDTO?>
    {
        public async Task<UserDetailsDTO?> Handle(UserDetailsCommand request, CancellationToken cancellationToken)
        {
            var userDetails = await dataContext.Users.FindAsync([request.Id], cancellationToken: cancellationToken);

            if (userDetails == null)
                return null;

            return new UserDetailsDTO { Email = userDetails.Email };
        }
    }
}
