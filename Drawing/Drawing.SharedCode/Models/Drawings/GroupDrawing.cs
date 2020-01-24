using Drawing.SharedCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.SharedCode.Models.Drawings
{
    class GroupDrawing : IDrawing
    {
        public IEnumerable<Group> Groups { get; private set; }

        internal void CreateGroups(int number)
        {
            Groups = new List<Group>();
            for (int i = 0; i < number; i++)
            {
                //Groups = new Group() { Name = CreateGroupName(i)}
            }
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
