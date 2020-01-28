using Drawing.SharedCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.SharedCode.Validation
{
    public class CountryValidation : ITeamValidation
    {
        public bool CanPlayAgainstThemself(Team t1, Team t2)
        {
            return t1.Country != t2.Country;
        }
    }
}
