using Drawing.SharedCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.SharedCode.Models.Drawings
{
    public class PairDrawing : IDrawing
    {
        private List<Team> drawingTeams;

        public IEnumerable<Pair> Pairs { get; private set; }
        public void Draw()
        {
            //walidacja czy jest parzysta liczba 
            List<Pair> drawPairs = new List<Pair>() as List<Pair>;
            Random r = new Random();
            while (drawingTeams.Count>0)
            {
                Team homeTeam = drawingTeams[r.Next(0, drawingTeams.Count-1)];
                //przerobienie na funkcje
                List<Team> possibleTeamsToDrown = drawingTeams.Where(t => t != homeTeam).ToList();//.Except<Team>(homeTeam)
                Team awayTeam = possibleTeamsToDrown[r.Next(0, possibleTeamsToDrown.Count - 1)];
                drawPairs.Add(new Pair { HomeTeam = homeTeam, AwayTeam = awayTeam});
                drawingTeams.RemoveAll(t => t == homeTeam || t == awayTeam);
            }
            Pairs = drawPairs;
        }
        internal void SetTeams(List<Team> teams)
        {
            drawingTeams = teams;
        }
    }
}
