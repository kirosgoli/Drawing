using Drawing.SharedCode.Models;
using System.Collections.Generic;

namespace Drawing.SharedCode.Sources
{
    public class TeamsContainerSource : ITeamsSource
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