using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assignment2.EnumsAndStructs;

namespace Assignment2.Structures
{
    public class None : Entity
    {
        //Remove Bitmap image, replace with base(Properties.Resource.floor)
        public None(Location location)
            : base(Properties.Resources.none, EntityProperty.PlayerCanCross, location, "none", 0)
        {}

        public override string ToString()
        {
            return $"None";
        }
    }
}
