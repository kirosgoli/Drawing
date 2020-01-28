using Drawing.SharedCode.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Drawing.SharedCode.Models.Drawings
{
    public class PairDrawing : IDrawing, IDrawValidation
    {
        private List<Team> drawingTeams;
        internal IEnumerable<ITeamValidation> Validations { get; private set; }
        public IEnumerable<Pair> Pairs { get; private set; }

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
                //przerobienie na funkcje
                //List<Team> possibleTeamsToDrown = drawingTeams.Where(t => t != homeTeam).ToList();//.Except<Team>(homeTeam)
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
            Validations = validations;
        }
        private List<Team> getPossibleTeamThatCanBeDrown(Team t1)
        {
            List<Team> leftTeams = drawingTeams.Where(t => t != t1).ToList();
            List<Team> possibleTeamToBeDrown = new List<Team>();
            foreach (var t2 in leftTeams)
            {
                bool canPlay = true;
                canPlay = ValidateIfNessesary(t1, t2);
                if (canPlay)
                    canPlay = ValidateIfOtherTeamCanPlayWithThemselfs(leftTeams.Where(t => t != t2).ToList());

                if (canPlay)
                    possibleTeamToBeDrown.Add(t2);
            }
            return possibleTeamToBeDrown;
        }

        private bool ValidateIfOtherTeamCanPlayWithThemselfs(List<Team> teams)
        {
            if (Validations != null)
            {
                if (teams == null)
                    return true;
                if (teams.Count == 0)
                    return true;

                int k = 2;
                int n = teams.Count;

                int number_of_all_matches = (Factorial(n) / (Factorial(n - k) * Factorial(k)));
                int number_of_disallowed_matches = 0;
                for (int i = 0; i < teams.Count; i++)
                {
                    for (int j = i+1; j < teams.Count; j++)
                    {
                        if (!ValidateIfNessesary(teams[i], teams[j]))
                            number_of_disallowed_matches++;
                    }
                }
                if (number_of_all_matches / 2 < number_of_disallowed_matches)
                    return false;
                return true;
            }
            return true;
        }

        public int Factorial(int number)
        {
            if (number < 0)
                throw new Exception("Factorial number lower than zero.");
            int result = 1;
            for (int i = 2; i < number; i++)
            {
                result *= i;
            }
            return result;
        }


        /// <summary>
        /// To refactor
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="possibleTeamsToDrown"></param>
        /// <param name="i"></param>
        /// <param name="canPlay"></param>
        /// <returns></returns>
        private bool ValidateIfNessesary(Team t1, Team t2)
        {
            if (Validations != null)
            {
                foreach (var validation in Validations)
                {
                     if (!validation.CanPlayAgainstThemself(t1, t2))
                        return false;
                }
            }

            return true;
        }
    }
}