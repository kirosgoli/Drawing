using System.Collections.Generic;

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