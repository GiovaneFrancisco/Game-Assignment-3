using Assignment2.Properties;
using Assignment2.Structures;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    internal class Tile : PictureBox
    {
        public Location TilePosition { get; set; }
        public int TileTag { get; set; }


        //public Tile GetTile(int row, int col)
        //{
        //    return new Tile
        //}

    }
}