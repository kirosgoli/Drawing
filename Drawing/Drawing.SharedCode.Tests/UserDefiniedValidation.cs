using Drawing.SharedCode.Models;
using Drawing.SharedCode.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.SharedCode.Tests
{
    internal class UserDefiniedValidation : ITeamValidation
    {
        private string[,] pairs;

        public bool CanPlayAgainstThemself(Team t1, Team t2)
        {
            pairs = new string[8, 2];
            pairs[0, 0] = "PSG";
            pairs[0, 1] = "Real Madrid";
            pairs[1, 0] = "Bayern Munchen";
            pairs[1, 1] = "Tottenham";
            pairs[2, 0] = "Manchester City";
            pairs[2, 1] = "Atalanta";
            pairs[3, 0] = "Juventus";
            pairs[3, 1] = "Atletico Madrid";
            pairs[4, 0] = "Liverpool";
            pairs[4, 1] = "Napoli";
            pairs[5, 0] = "Barcelona";
            pairs[5, 1] = "Borussia";
            pairs[6, 0] = "RB Lipsk";
            pairs[6, 1] = "Lyon";
            pairs[7, 0] = "Valencia";
            pairs[7, 1] = "Chelsea";
            for (int i = 0; i < 8; i++)
            {
                if ((pairs[i, 0] == t1.Name || pairs[i, 1] == t1.Name)
                    &&
                    (pairs[i, 0] == t2.Name || pairs[i, 1] == t2.Name))
                    return false;
            }
            bool IsTeam1GroupWinner = isGroupWinner(t1);
            bool IsTeam2GroupWinner = isGroupWinner(t2);
            if (IsTeam1GroupWinner == IsTeam2GroupWinner)
                return false;
            return true;
        }

        private bool isGroupWinner(Team team)
        {
            for (int i = 0; i < 8; i++)
            {
                if (pairs[i, 0] == team.Name)
                    return true;
            }
            return false;
        }
    }
}