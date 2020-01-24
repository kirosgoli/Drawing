using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.SharedCode.Models
{
    public class Group
    {
        public string Name { get; set; }
        public IEnumerable<Team> Teams { get; set; }

        internal Group()
        {
            Teams = new List<Team>();
        }
    }
}
