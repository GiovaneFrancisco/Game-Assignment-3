using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assignment2.EnumsAndStructs;

namespace Assignment2.Structures
{
    public class Wall : Entity
    {
        //Remove Bitmap image, replace with base(Properties.Resource.floor)
        public Wall(Location location)
            : base(Properties.Resources.wall, EntityProperty.Collidable, location, "wall", 1)
        {}

        public override string ToString()
        {
            return $"Wall";
        }
    }
}
