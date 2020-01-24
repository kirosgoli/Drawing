using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.SharedCode.Models
{
    public class Pair
    {
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }

        public override string ToString()
        {
            //Todo
            //W zależności od kraju
            //return PairFormatter.Format(HomeTeam, AwayTeam);
            return $"{HomeTeam.Name} vs {AwayTeam.Name}";

        }
    }
}
