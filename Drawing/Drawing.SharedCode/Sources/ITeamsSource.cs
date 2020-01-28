using Drawing.SharedCode.Models;
using System.Collections.Generic;

namespace Drawing.SharedCode.Sources
{
    public interface ITeamsSource
    {
        IEnumerable<Team> GetTeams();
    }
}