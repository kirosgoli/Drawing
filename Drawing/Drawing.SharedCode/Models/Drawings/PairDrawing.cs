using Drawing.SharedCode.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Drawing.SharedCode.Models.Drawings
{
    public class PairDrawing : IDrawing, IDrawValidation
    {
        private List<Team> drawingTeams;
        public IEnumerable<Pair> Pairs { get; private set; }
        private PairDrawValidation drawValidation = new PairDrawValidation();

        public PairDrawing()
        {
        }

        public void Draw()
        {
            //walidacja czy jest parzysta liczba
            if (!ValidateAllElements())
                throw new Exception("Number of teams is not parity. Cannot start draw.");

            List<Pair> drawPairs = new List<Pair>() as List<Pair>;
            Random r = new Random();
            while (drawingTeams.Count > 0)
            {
                Team homeTeam = drawingTeams[r.Next(0, drawingTeams.Count - 1)];
                List<Team> possibleTeamsToDrown = getPossibleTeamThatCanBeDrown(homeTeam);
                if (possibleTeamsToDrown.Count == 0)
                    throw new Exception($"Error during validating possible teams that can be drow to team {homeTeam.Name}");
                Team awayTeam = possibleTeamsToDrown[r.Next(0, possibleTeamsToDrown.Count - 1)];
                drawPairs.Add(new Pair { HomeTeam = homeTeam, AwayTeam = awayTeam });
                drawingTeams.RemoveAll(t => t == homeTeam || t == awayTeam);
            }
            Pairs = drawPairs;
        }

        public bool ValidateAllElements()
        {
            return drawingTeams.Count % 2 == 0;
        }

        internal void SetTeams(List<Team> teams)
        {
            drawingTeams = teams;
        }

        internal void SetValidation(IEnumerable<ITeamValidation> validations)
        {
            drawValidation.Validations = validations;
        }

        private List<Team> getPossibleTeamThatCanBeDrown(Team t1)
        {
            List<Team> leftTeams = drawingTeams.Where(t => t != t1).ToList();
            List<Team> possibleTeamToBeDrown = new List<Team>();
            foreach (var t2 in leftTeams)
            {
                bool canPlay = true;
                canPlay = drawValidation.ValidateIfNecessary(t1, t2);
                if (canPlay)
                    canPlay = drawValidation.ValidateIfOtherTeamCanPlayWithThemselves(leftTeams.Where(t => t != t2).ToList());

                if (canPlay)
                    possibleTeamToBeDrown.Add(t2);
            }
            return possibleTeamToBeDrown;
        }
    }
}