using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.SharedCode.Models
{
    public class Set
    {
        internal List<Pair> Pairs { get; private set; }
        public readonly int Capacity;

        public Set(int capacity)
        {
            Pairs = new List<Pair>();
            Capacity = capacity;
        }

        public Set(Set set)
        {
            this.Pairs = set.Pairs.ToList();
            this.Capacity = set.Capacity;
        }

        public void TryAdd(Pair pair)
        {
            if (Pairs.Count < Capacity)
                Pairs.Add(pair);
        }

        public bool IsFull
        {
            get
            {
                return Pairs.Count == Capacity ? true : false;
            }
        }

        public bool IsTeamAlreadyInSet(Team team)
        {
            return Pairs.Exists(p => p.HomeTeam == team || p.AwayTeam == team);
        }
    }
}