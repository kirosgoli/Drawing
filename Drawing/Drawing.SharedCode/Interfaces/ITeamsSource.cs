using Drawing.SharedCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.SharedCode.Interfaces
{
    public interface ITeamsSource
    {
        IEnumerable<Team> GetTeams();
    }
}
