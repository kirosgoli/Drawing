using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.SharedCode.Interfaces
{
    public interface IDrawing
    {
        IDrawing Draw();
        void SetTeams(ITeamSource source);
    }
}
