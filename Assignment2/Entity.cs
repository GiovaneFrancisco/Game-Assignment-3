using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assignment2.EnumsAndStructs;

namespace Assignment2
{
    public abstract class Entity
    {
        protected EntityProperty properties;
        public Bitmap Image { get; }
        public EnumsAndStructs.Size Size { get; }
        public Location Location { get; set; }  
        public string Name { get; set; }
        public int Tag { get; set; }

        public Entity(Bitmap image,
                      EntityProperty properties,
                      Location location, 
                      string name,
                      int tag)
        {
            this.Image = image;
            this.properties = properties;
            this.Size = new EnumsAndStructs.Size(64,64);
            this.Location = location;
            this.Name = name;
            this.Tag = tag;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Entity type: {this.GetType().Name}");
            builder.AppendLine();
            builder.AppendLine($"Location: {Location.ToString()}");
            builder.AppendLine($"Size: {Size.ToString()}");
            builder.AppendLine();
            builder.AppendLine($"Properties: {properties.ToString()}");
            builder.AppendLine();
            return builder.ToString();
        }
    }
}
