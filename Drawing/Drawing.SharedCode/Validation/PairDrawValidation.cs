using Drawing.SharedCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Drawing.SharedCode.Validation
{
    internal class PairDrawValidation
    {
        private List<Pair> all_pairs;
        internal IEnumerable<ITeamValidation> Validations { get; set; }

        internal bool ValidateIfNecessary(Team t1, Team t2)
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

        internal bool ValidateIfOtherTeamCanPlayWithThemselves(List<Team> teams)
        {
            if (Validations != null)
            {
                if (teams == null)
                    return true;
                if (teams.Count == 0)
                    return true;

                int teamsNumber = teams.Count;

                all_pairs = new List<Pair>();
                CreateAllPossiblePairs(teams, teamsNumber);
                RemoveBadPairs();
                SetsContainer setsContainer = CreateSets(teamsNumber);
                if (!setsContainer.Sets.Exists(s => s.Pairs.Count == teamsNumber / 2))
                    return false;
            }
            return true;
        }

        private SetsContainer CreateSets(int teamsNumber)
        {
            SetsContainer setsContainer = new SetsContainer();
            foreach (var pair in all_pairs)
            {
                for (int j = 0; j < teamsNumber / 2; j++)
                {
                    bool isAdded = false;
                    foreach (var set in setsContainer.Sets)
                    {
                        if (set.IsFull)
                            continue;
                        if (set.IsTeamAlreadyInSet(pair.HomeTeam))
                            continue;
                        if (set.IsTeamAlreadyInSet(pair.AwayTeam))
                            continue;
                        Set _set = new Set(set);
                        _set.TryAdd(pair);
                        if (!setsContainer.isSetAlreadyAdded(_set))
                        {
                            set.TryAdd(pair);
                            isAdded = true;
                            break;
                        }
                    }
                    if (!isAdded)
                    {
                        Set set = new Set(teamsNumber / 2);
                        set.TryAdd(pair);
                        setsContainer.TryAdd(set);
                    }
                }
            }

            return setsContainer;
        }

        private void RemoveBadPairs()
        {
            for (int i = all_pairs.Count - 1; i >= 0; i--)
            {
                if (!ValidateIfNecessary(all_pairs[i].HomeTeam, all_pairs[i].AwayTeam))
                    all_pairs = all_pairs.Where(p => p != all_pairs[i]).ToList();
            }
        }

        private void CreateAllPossiblePairs(List<Team> teams, int teamsNumber)
        {
            for (int i = 0; i < teamsNumber; i++)
            {
                for (int j = i + 1; j < teamsNumber; j++)
                {
                    all_pairs.Add(new Pair { HomeTeam = teams[i], AwayTeam = teams[j] });
                }
            }
        }
    }
}