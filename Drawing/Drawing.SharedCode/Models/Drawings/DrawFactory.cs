using Drawing.SharedCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.SharedCode.Models.Drawings
{
    class DrawFactory
    {
        public IDrawing CreateGroupDraw(int groupsNumber, int groupCapacity)
        {
            GroupDrawing groupDrawing = new GroupDrawing();
            groupDrawing.CreateGroups(groupsNumber);

            return groupDrawing;
        }
    }
}
