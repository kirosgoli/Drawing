using Drawing.SharedCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.SharedCode.Models.Drawings
{
    class PairDrawing : IDrawing
    {
        public IEnumerable<Pair> Pairs { get; private set; }
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
