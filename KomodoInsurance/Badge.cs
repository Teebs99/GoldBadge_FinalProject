using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    public class Badge
    {
        public int BadgeId { get; }
        public List<string> Doors { get; set; }

        public Badge(int id)
        {
            BadgeId = id;
            Doors = new List<string>();
        }
        public Badge(int id, List<string> doors)
        {
            BadgeId = id;
            Doors = doors;
        }
    }
}
