using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class EnumsAndStructs
    {
        [Flags]
        public enum EntityProperty
        {
            PlayerCanCross = 1,
            CanDie = 2,
            Destroyable = 4,
            Hidden = 8,
            None = 0,
            Collidable = 16,
            Movable = 32,
            Interactable = 64
        }

        [Flags]
        public enum TileObject
        {
            None = 0,
            Floor = 1,
            Wall = 2,
            Chest = 4,
            Door = 8,
            Trap = 16,
            Zombie = 32,
            Skeleton = 64
        }



        public struct Size
        {
            public int Width { get; }
            public int Height { get; }

            public Size(int width, int height)
            {
                if (width <= 0 || height <= 0)
                {
                    throw new ArgumentException("Widht/Height must be greater than 0");
                }
                this.Width = width;
                this.Height = height;
            }
            public override string ToString()
            {
                return $"{Width} X {Height}";
            }
        }

        public struct Location
        {
            public int X { get; }
            public int Y { get; }

            public Location(int x, int y)
            {
                if (x <= -1 || y <= -1)
                {
                    throw new ArgumentException("Position must be greater than -2");
                }
                this.X = x;
                this.Y = y;
            }

            public override string ToString()
            {
                return $"({X}, {Y})";
            }
        }

    }
}
