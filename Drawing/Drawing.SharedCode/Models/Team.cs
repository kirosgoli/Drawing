using System;

namespace Drawing.SharedCode.Models
{
    public class Team
    {
        public virtual String Name { get; set; }

        public String Country { get; set; }
        public Group Group { get; set; }
    }
}