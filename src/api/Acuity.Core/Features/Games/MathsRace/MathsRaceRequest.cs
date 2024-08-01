using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acuity.Core.Features.Games.MathsRace
{
    public enum MathsRacingGameMode
    {
        Beginner = 1,
        Intermediate,
        Expert
    }
    public class MathsRaceRequest
    {
        public MathsRacingGameMode Mode { get; set; }
    }
}
