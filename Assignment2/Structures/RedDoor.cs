using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assignment2.EnumsAndStructs;

namespace Assignment2.Structures
{
    public class RedDoor : Entity
    {
        public RedDoor(Location location) 
            : base(Properties.Resources.red_door, EntityProperty.Movable 
                  | EntityProperty.Collidable, location, "redDoor", 2)
        {
        }

        public override string ToString()
        {
            return $"RedDoor";
        }
    }
}
