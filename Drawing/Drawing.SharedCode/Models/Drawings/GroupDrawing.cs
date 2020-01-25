using Drawing.SharedCode.Interfaces;
using Drawing.SharedCode.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.SharedCode.Models.Drawings
{
    public class GroupDrawing : IDrawing
    {
        public IEnumerable<Group> Groups { get; private set; }

        internal void CreateGroups(int number)
        {
            List<Group> Groups = new List<Group>();
            for (int i = 1; i <= number; i++)
            {
                Groups.Add(new Group() { Name = GroupNameCreator.CreateGroupNameFromNumber(i) });
            }
            this.Groups = Groups;
        }
        public IDrawing Draw()
        {
            throw new NotImplementedException();
        }

        public void SetTeams(ITeamSource source)
        {
            throw new NotImplementedException();
        }
    }
}
