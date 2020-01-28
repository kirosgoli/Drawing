using Drawing.SharedCode.Sources;
using Drawing.SharedCode.Validation;
using System.Collections.Generic;
using System.Linq;

namespace Drawing.SharedCode.Models.Drawings
{
    public static class DrawFactory
    {
        public static IDrawing CreateGroupsDraw(int groupsNumber, int groupCapacity, ITeamsSource source)
        {
            GroupDrawing groupDrawing = new GroupDrawing();
            groupDrawing.CreateGroups(groupsNumber);

            return groupDrawing;
        }

        public static IDrawing CreatePairsDraw(ITeamsSource teamsource)
        {
            PairDrawing pairDrawing = new PairDrawing();
            pairDrawing.SetTeams(teamsource.GetTeams().ToList());
            return pairDrawing;
        }
        public static IDrawing CreatePairsDraw(ITeamsSource teamsource, IEnumerable<ITeamValidation> validations)
        {
            PairDrawing pairDrawing = CreatePairsDraw(teamsource) as PairDrawing;
            pairDrawing.SetValidation(validations);
            return pairDrawing;
        }
    }
}