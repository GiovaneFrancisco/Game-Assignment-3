using Assignment2.Properties;
using Assignment2.Structures;
using System;
using System.Data.Common;
using static Assignment2.EnumsAndStructs;

namespace Assignment2
{
    internal class MapGeneration
    {
        public static None CreateStartingGrid(Location location)
        {

            return new None(location);
        }
    }
}