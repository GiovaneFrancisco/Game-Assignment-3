using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assignment2.EnumsAndStructs;

namespace Assignment2.Structures
{
    public class RedBox : Entity
    {
        public RedBox(Location location) 
            : base(Properties.Resources.red_box, EntityProperty.Movable 
                  | EntityProperty.Collidable, location, "redBox", 3)
        {
        }

        public override string ToString()
        {
            return $"RedBox";
        }
    }
}
