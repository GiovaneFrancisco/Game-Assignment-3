using Assignment2.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assignment2.EnumsAndStructs;

namespace Assignment2.Structures
{
    public class GreenBox : Entity
    {
        public GreenBox(Location location) 
            : base(Properties.Resources.green_box, EntityProperty.Movable | EntityProperty.Collidable, location,
                  "greenBox", 5)
        {
        }

        public override string ToString()
        {
            return $"GreenBox";
        }
    }
}
