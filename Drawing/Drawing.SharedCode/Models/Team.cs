using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.SharedCode.Models
{
    public class Team
    {
        public String Name { get; set; }

        public String Country { get; set; }
        public Group Group { get; set; }
    }
}
