using Drawing.SharedCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.SharedCode.Validation
{
    public interface ITeamValidation : IValidationBase
    {
        bool CanPlayAgainstThemself(Team t1, Team t2);
    }
}
