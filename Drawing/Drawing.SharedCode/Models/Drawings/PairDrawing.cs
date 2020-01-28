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

                //int number_of_all_matches = (Factorial(n) / (Factorial(n - k) * Factorial(k)));
                //int number_of_allowed_pairs = 0;
                //int number_of_disallowed_pairs = 0;
                //for (int i = 0; i < teams.Count; i++)
                //{
                //    for (int j = i+1; j < teams.Count; j++)
                //    {
                //        if (!ValidateIfNessesary(teams[i], teams[j]))
                //            number_of_disallowed_pairs++;
                //        else
                //            number_of_allowed_pairs++;
                //    }
                //}
                //if (number_of_disallowed_pairs > number_of_allowed_pairs)
                //    return false;
                //return true;
                List<Pair> all_pairs = new List<Pair>();
                for (int i = 0; i < n; i++)
                {
                    for (int j = i+1; j < n; j++)
                    {
                        all_pairs.Add(new Pair { HomeTeam = teams[i], AwayTeam = teams[j] });
                    }
                }

                //Remove bad pairs

                for (int i = all_pairs.Count-1; i >= 0; i--)
                {
                    if (!ValidateIfNessesary(all_pairs[i].HomeTeam, all_pairs[i].AwayTeam))
                        all_pairs = all_pairs.Where(p => p != all_pairs[i]).ToList();
                }

                List<List<Pair>> zestawy = new List<List<Pair>>();

                foreach (var pair in all_pairs)
                {
                    //List<Pair> Znalezionezestawy = new List<Pair>()
                    for (int j = 0; j < n/2; j++)
                    {
                        bool isAdded = false;
                        foreach (var zestaw in zestawy)
                        {
                            if (zestaw.Count == n/2)
                                continue;
                            if (zestaw.Exists(p => p.HomeTeam == pair.HomeTeam || p.AwayTeam == pair.HomeTeam))
                                continue;
                            if (zestaw.Exists(p => p.HomeTeam == pair.AwayTeam || p.AwayTeam == pair.AwayTeam))
                                continue;
                            //Czy istnieje już taki zestaw 
                            zestaw.Add(pair);
                            isAdded = true;
                            break;
                        }
                        if (!isAdded)
                        {
                            List<Pair> zestaw = new List<Pair> { pair };
                            zestawy.Add(zestaw);
                        }
                    }
                }

                int wrongcase = 0;
                foreach (var zestaw in zestawy)
                {
                    foreach (var pair in zestaw)
                    {
                        if (!ValidateIfNessesary(pair.HomeTeam, pair.AwayTeam))
                            wrongcase++;
                    }
                }
                if (zestawy.Count == wrongcase)
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
            for (int i = 2; i <= number; i++)
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