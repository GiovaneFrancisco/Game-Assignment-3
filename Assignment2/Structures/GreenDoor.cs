using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assignment2.EnumsAndStructs;

namespace Assignment2.Structures
{
    public class GreenDoor : Entity
    {
        public GreenDoor(Location location) 
            : base(Properties.Resources.green_door, EntityProperty.Interactable 
                  | EntityProperty.Collidable, location, "greenDoor", 4)
        {
        }

        public override string ToString()
        {
            return $"GreenDoor";
        }
    }
}
