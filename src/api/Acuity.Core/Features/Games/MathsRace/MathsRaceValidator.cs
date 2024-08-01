using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acuity.Core.Features.Games.MathsRace
{
    public class MathsRaceValidator : AbstractValidator<MathsRaceRequest>
    {
        public MathsRaceValidator() 
        {
            RuleFor(x => x.Mode).IsInEnum().WithMessage("Invalid game mode");
        }
    }
}
