using Drawing.SharedCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.SharedCode.Sources
{
    public class TeamsContainerSource : Interfaces.ITeamsSource
    {
        private List<Team> teams;
        public TeamsContainerSource()
        {
            teams = new List<Team>();
        }

        public void AddTeam(Team team)
        {
            teams.Add(team);
        }

        public void Clear()
        {
            teams.Clear();
        }

        public IEnumerable<Team> GetTeams()
        {
            return teams;
        }
    }
}
