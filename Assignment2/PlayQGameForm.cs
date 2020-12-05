using Assignment2.Properties;
using Assignment2.Structures;
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
using static Assignment2.EnumsAndStructs;

namespace Assignment2
{
    public partial class PlayQGameForm : Form
    {
        private Entity[,] tileMapping;
        Entity selectedEntity;
        PictureBox selectedTile = new PictureBox();
        PictureBox[,] picBoxMapping;
        int startingPosX = 0;
        int startingPosY = 0;
        int checkingX = 0;
        int checkingY = 0;
        int ROWS = 0;
        int COLS = 0;

        const int SIZE = 64;

        int movements = 0;
        int boxesRemaining = 0;

        bool shouldMove = true;

        MapCreationForm mapDummy = new MapCreationForm();

        public PlayQGameForm()
        {
            InitializeComponent();
        }

        private void BtnCntrlClick(object sender, EventArgs e)
        {
            //Button dummy = sender as Button;
            //string direction = dummy.Text;
            //shouldMove = true;
            //checkingX = selectedTile.Location.X / SIZE;
            //checkingY = selectedTile.Location.Y / SIZE;
            //startingPosX = checkingX;
            //startingPosY = checkingY;
            //while (shouldMove)
            //{
            //    if (IsNeighborNone(direction))
            //    {
            //        UpdateTiles();
            //        UpdatePictures();
            //        PrintTilesArray();
            //        startingPosX = checkingX;
            //        startingPosY = checkingY;
            //    } else
            //    {
            //        shouldMove = false;
            //    }
            //}
            //if (shouldMove)
            //{
            //    movements++;
            //    txtNumbMoves.Text = movements.ToString();
            //}
        }

        private void UpdateTiles()
        {
            //tileMapping[checkingX, checkingY] = tileMapping[startingPosX, startingPosY];
            //tileMapping[startingPosX, startingPosY] = null;
        }
        private void UpdatePictures()
        {
            //selectedTile.Location = new Point(checkingX, checkingY);
            //picBoxMapping[checkingX, checkingY] = selectedTile;
            //picBoxMapping[checkingX, checkingY].BackgroundImage = selectedTile.BackgroundImage;
            //picBoxMapping[checkingX, checkingY].Tag = selectedTile.Tag;
            //picBoxMapping[checkingX, checkingY].Name = selectedTile.Name;

            //selectedTile = picBoxMapping[checkingX, checkingY];

            //picBoxMapping[startingPosX, startingPosY] = null;

            

        }

        private bool IsNeighborNone(string direction)
        {
            //bool isNeighborNone = true;
            //switch (direction)
            //{
            //    case "Up":
            //        checkingX -= 1;
            //        if (checkingX > 0 && tileMapping[checkingX, checkingY] != null)
            //        {
            //            isNeighborNone = false;
            //            checkingX++;
            //        }
            //        break;
            //    case "Down":
            //        checkingX += 1;
            //        if (checkingX < ROWS && tileMapping[checkingX, checkingY] != null)
            //        {
            //            isNeighborNone = false;
            //            checkingX--;
            //        }
            //        break;
            //    case "Right":
            //        checkingY += 1;
            //        if (checkingY < COLS && tileMapping[checkingX, checkingY] != null)
            //        {
            //            isNeighborNone = false;
            //            checkingY--;
            //        }
            //        break;
            //    case "Left":
            //        checkingY -= 1;
            //        if (checkingY > 0 && tileMapping[checkingX, checkingY] != null)
            //        {
            //            isNeighborNone = false;
            //            checkingY++;
            //        }
            //        break;
            //}

            //return isNeighborNone;
        }


        private void PrintTilesArray()
        {
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    if (tileMapping[i, j] != null)
                    {
                        Console.Write(tileMapping[i, j].Tag);
                    }
                    Console.Write("\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private void loadMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadMap();
        }

        private void LoadMap()
        {

            OpenFileDialog openFile = new OpenFileDialog();

            openFile.Filter = "qgame (*.qgame)|*.qgame";
            openFile.FilterIndex = 2;
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                if (HasLoadedMap()) ClearMap();
                using (StreamReader reader = new StreamReader(openFile.FileName, true))
                {
                    string fileText = reader.ReadToEnd();
                    ROWS = int.Parse(fileText.Substring(0, 1));
                    COLS = int.Parse(fileText.Substring(1, 1));
                    string[] linesFromFile = fileText.Split('\n');
                    tileMapping = new Entity[ROWS, COLS];
                    picBoxMapping = new PictureBox[ROWS, COLS];
                    MapCreationForm dummy = new MapCreationForm();
                    int line = 1;

                    for (int row = 0; row < ROWS; row++)
                    {
                        for (int column = 0; column < COLS; column++)
                        {

                            PictureBox picBox = new PictureBox();
                            
                            Entity tile = null;
                            //string tileX = linesFromFile[line].Substring(0, 1);
                            //string tileY = linesFromFile[line].Substring(1, 1);
                            string tileTag = linesFromFile[line].Substring(2, 1);
                            if (!tileTag.Equals("0"))
                            {

                                Location position = dummy.CalculateLocation(row, column);
                                tile = SetTileTag(tile, tileTag, position);
                                //Console.WriteLine($"Line: {line} \t {tileX}x{tileY} \t {tile.Name}");
                                SetPictureBoxAttributes(picBox, tile);
                                pnlLoadTiles.Controls.Add(picBox);
                                tileMapping[row, column] = tile;
                                picBoxMapping[row, column] = picBox;
                            } else
                            {
                                tileMapping[row, column] = null;
                            }
                            line++;
                        }
                    }
                }

                foreach (Entity ent in tileMapping)
                {
                    if (ent != null)
                    {

                        if (ent.Tag == 3 || ent.Tag == 5)
                        {
                            boxesRemaining++;
                        }
                    }
                }
                txtNumbBoxes.Text = boxesRemaining.ToString();
                PrintTilesArray();
            }
        }

        private bool HasLoadedMap()
        {
            foreach (Control cntrl in pnlLoadTiles.Controls)
            {
                if (cntrl is PictureBox) return true;
            }
            return false;
        }

        private void ClearMap()
        {
            pnlLoadTiles.Controls.Clear();
        }

        private void SetPictureBoxAttributes(PictureBox picBox, Entity tile)
        {
            picBox.BackgroundImage = tile.Image;
            picBox.Location = new Point(tile.Location.X, tile.Location.Y);
            picBox.Size = new System.Drawing.Size(tile.Size.Width, tile.Size.Height);
            picBox.BorderStyle = BorderStyle.FixedSingle;
            picBox.Click += new EventHandler(SelectTile);
            //picBox.Click += new EventHandler(PicInfo);
            picBox.Name = tile.Name;
            picBox.Tag = tile.Tag;
        }

        private void SelectTile(object sender, EventArgs e)
        {
            PictureBox picBox = sender as PictureBox;
            if (IsTileABox(picBox)) UpdateSelectedBox(picBox);
        }

        private void UpdateSelectedBox(PictureBox picBox)
        {
            selectedTile.Location = new Point(picBox.Location.X, picBox.Location.Y);
            selectedTile.Name = picBox.Name;
            selectedTile.Tag = picBox.Tag;
            selectedTile.BackgroundImage = picBox.BackgroundImage;
            selectedTile.BorderStyle = picBox.BorderStyle;


            bool hasBoxSelected = false;
            foreach (Control pic in pnlLoadTiles.Controls)
            {
                if (pic is PictureBox)
                {
                    PictureBox dummy = pic as PictureBox;
                    if (dummy.BorderStyle == BorderStyle.Fixed3D && dummy.Location == selectedTile.Location)
                    {
                        hasBoxSelected = true;
                    }
                    dummy.BorderStyle = BorderStyle.FixedSingle;
                }
            }
            if (hasBoxSelected)
            {
                picBox.BorderStyle = BorderStyle.FixedSingle;
            } else
            {
                picBox.BorderStyle = BorderStyle.Fixed3D;
            }
            ChangeCntrlButtonsActive(picBox);
        }


        private void ChangeCntrlButtonsActive(PictureBox picBox)
        {
            {
                foreach (Control button in pnlCntrlButtons.Controls)
                {
                    Button dummy = button as Button;
                    if (picBox.BorderStyle == BorderStyle.Fixed3D)
                    {
                        dummy.Enabled = true;
                    } else
                    {
                        dummy.Enabled = false;
                    }
                }
            }
        }

        private bool IsTileABox(PictureBox picBox)
        {
            if (tileMapping[picBox.Location.X / SIZE, picBox.Location.Y/SIZE] != null)
            {
                return picBox.Name.Equals("greenBox") || tileMapping[picBox.Location.X / SIZE, picBox.Location.Y / SIZE].Tag == 5
                    || picBox.Name.Equals("redBox") || tileMapping[picBox.Location.X / SIZE, picBox.Location.Y / SIZE].Tag == 3;
            }
            return false;
        }

        private static Entity SetTileTag(Entity tile, string tileTag, Location position)
        {
            switch (tileTag)
            {
                //case "0":
                //    tile = new None(position);
                //    break;
                case "1":
                    tile = new Wall(position);
                    break;
                case "2":
                    tile = new RedDoor(position);
                    break;
                case "3":
                    tile = new RedBox(position);
                    break;
                case "4":
                    tile = new GreenDoor(position);
                    break;
                case "5":
                    tile = new GreenBox(position);
                    break;

            }

            return tile;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            LoadMap();
        }
    }
}
