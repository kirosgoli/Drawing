using Drawing.SharedCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.SharedCode.Models.Drawings
{
    public static class DrawFactory
    {
        public static IDrawing CreateGroupsDraw(int groupsNumber, int groupCapacity,ITeamsSource source)
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
    }
}
