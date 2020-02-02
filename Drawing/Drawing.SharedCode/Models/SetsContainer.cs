using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.SharedCode.Models
{
    internal class SetsContainer
    {
        public List<Set> Sets { get; private set; }

        public SetsContainer()
        {
            Sets = new List<Set>();
        }

        public void TryAdd(Set set)
        {
            bool CanAdd = true;

            foreach (var addSets in Sets)
            {
                int duplicated = 0;
                for (int i = 0; i < set.Pairs.Count; i++)
                {
                    if (addSets.Pairs.Exists(p => p == set.Pairs[i]))
                        duplicated++;
                }
                if (duplicated == set.Capacity)
                    CanAdd = false;
            }

            if (CanAdd)
                Sets.Add(set);
        }

        public bool isSetAlreadyAdded(Set _set)
        {
            foreach (var set in Sets)
            {
                int duplicatedpairs = 0;
                foreach (var pair in _set.Pairs)
                {
                    if (set.Pairs.Exists(p => p == pair))
                        duplicatedpairs++;
                }
                if (duplicatedpairs == _set.Pairs.Count)
                    return true;
            }
            return false;
        }
    }
}