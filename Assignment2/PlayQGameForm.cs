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
        PictureBox selectedTile = new PictureBox();
        PictureBox[,] picBoxMapping;
        int originalXPos = 0;
        int originalYPos = 0;
        int checkingX = 0;
        int checkingY = 0;
        int ROWS = 0;
        int COLS = 0;
        int iterrations = 0;

        const int SIZE = 64;

        int movements = 0;
        int boxesRemaining = 0;

        bool shouldMove = true;

        MapCreationForm mapDummy = new MapCreationForm();

        public PlayQGameForm()
        {
            InitializeComponent();
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
                            string tileTag = linesFromFile[line].Substring(2, 1);
                            if (!tileTag.Equals("0"))
                            {
                                Location position = dummy.CalculateLocation(row, column);
                                tile = SetTileTag(tile, tileTag, position);
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
                UpdateRemainingBoxes();
                PrintTilesArray();
            }
        }

        private void UpdateRemainingBoxes()
        {
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
            picBox.Name = tile.Name;
            picBox.Tag = tile.Tag;
        }

        private void DisplayPicInfo(object sender, EventArgs e)
        {
            PictureBox picBox = sender as PictureBox;
            StringBuilder sb = new StringBuilder();
            sb.Append($"Position X: {picBox.Location.X / SIZE}, Y: {picBox.Location.Y / SIZE}");
            sb.Append($" Tag: {picBox.Tag}");
            //Console.WriteLine(sb);
        }

        private void SelectTile(object sender, EventArgs e)
        {
            PictureBox picBox = sender as PictureBox;
            //DisplayPicInfo(picBox, EventArgs.Empty);
            if (IsTileABox(picBox)) UpdateSelectedBox(picBox);
        }
        private bool IsTileABox(PictureBox picBox)
        {
            if (tileMapping[picBox.Location.X / SIZE, picBox.Location.Y / SIZE] != null)
            {
                return picBox.Name.Equals("greenBox") || tileMapping[picBox.Location.X / SIZE, picBox.Location.Y / SIZE].Tag == 5
                    || picBox.Name.Equals("redBox") || tileMapping[picBox.Location.X / SIZE, picBox.Location.Y / SIZE].Tag == 3;
            }
            return false;
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
        private void BtnCntrlClick(object sender, EventArgs e)
        {
            Button dummy = sender as Button;
            string direction = dummy.Text;
            shouldMove = true;
            //Console.WriteLine($"Selected X: {selectedTile.Location.X / SIZE}, Y: {selectedTile.Location.Y / SIZE}, Tag: {selectedTile.Tag}");
            while (IsNeighborNone(direction))
            {
                if (checkingY > 20 || checkingY < -20 || checkingX > 20 || checkingX < -20 || iterrations > 30)
                {
                    Console.WriteLine("FORCED BREAK");
                    break;
                }
                //Second box replaces the first
                UpdatePicBoxMappingArray();
                PrintTilesArray();
                ReloadUpdatedMap();
            }
        }

        private void ReloadUpdatedMap()
        {
            ClearMap();
            MapCreationForm dummy = new MapCreationForm();
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    PictureBox picBox = new PictureBox();
                    picBox = picBoxMapping[i, j];
                    pnlLoadTiles.Controls.Add(picBox);
                }
            }
        }

        private bool IsNeighborNone(string direction)
        {
            iterrations++;
            bool isNeighborNone = true;

            originalXPos = selectedTile.Location.X / SIZE;
            originalYPos = selectedTile.Location.Y / SIZE;

            checkingX = originalXPos;
            checkingY = originalYPos;
            switch (direction)
            {
                case "Up":
                    checkingY -= 1;
                    if (picBoxMapping[checkingX, checkingY] != null)
                    {
                        isNeighborNone = false;
                        checkingY++;
                    }
                    break;
                case "Down":
                    checkingY += 1;
                    if (picBoxMapping[checkingX, checkingY] != null)
                    {
                        isNeighborNone = false;
                        checkingY--;
                    }
                    break;
                case "Right":
                    checkingX += 1;
                    if (picBoxMapping[checkingX, checkingY] != null)
                    {
                        isNeighborNone = false;
                        checkingX--;
                    }
                    break;
                case "Left":
                    checkingX -= 1;
                    if (picBoxMapping[checkingX, checkingY] != null)
                    {
                        isNeighborNone = false;
                        checkingX++;
                    }
                    break;
            }
            return isNeighborNone;
        }

        private void UpdatePicBoxMappingArray()
        {
            picBoxMapping[checkingX, checkingY] = selectedTile;
            picBoxMapping[originalXPos, originalYPos] = null;

            selectedTile.Location = new Point(checkingX * SIZE, checkingY * SIZE);
        }

        private void PrintTilesArray()
        {
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    if (picBoxMapping[i, j] != null)
                    {
                        Console.Write(picBoxMapping[i, j].Tag);
                    }
                    Console.Write("\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
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
