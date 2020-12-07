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
        #region Variables

        PictureBox selectedTile = new PictureBox();
        PictureBox[,] picBoxMapping;
        int originalXPos = 0;
        int originalYPos = 0;
        int checkingX = 0;
        int checkingY = 0;
        int ROWS = 0;
        int COLS = 0;

        const int SIZE = 64;

        int movements = 0;

        int pastMovement = 0;
        int currentMovement = 0;

        int boxesRemaining = 0;

        bool shouldMove = true;

        #endregion

        #region Constructor
        public PlayQGameForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Load Game
        private void loadMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadMap();
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadMap()
        {
            movements = 0;
            pastMovement = 0;
            currentMovement = 0;
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
                                picBoxMapping[row, column] = picBox;
                            } else
                            {
                                picBoxMapping[row, column] = null;
                            }
                            line++;
                        }
                    }
                }
                UpdateRemainingBoxes();
                ChangeEnabledControlButtons(true);
                //PrintTilesArray();
            }
            ResizePanel();
        }
        private bool HasLoadedMap()
        {
            foreach (Control cntrl in pnlLoadTiles.Controls)
            {
                if (cntrl is PictureBox) return true;
            }
            return false;
        }
        private void ResizePanel()
        {
            if (ROWS > 7)
            {

            }
            if (COLS > 7)
            {

            }
        }
        private void SetPictureBoxAttributes(PictureBox picBox, Entity tile)
        {
            picBox.BackgroundImage = tile.Image;
            //picBox.Location = new Point(tile.Location.X, tile.Location.Y);
            picBox.Left = tile.Location.X;
            picBox.Top = tile.Location.Y;
            picBox.Size = new System.Drawing.Size(tile.Size.Width, tile.Size.Height);
            picBox.BorderStyle = BorderStyle.FixedSingle;
            picBox.Click += new EventHandler(SelectTile);
            picBox.Name = tile.Name;
            picBox.Tag = tile.Tag;
        }
        #endregion

        #region Tile Handling
        private void DisplayPicInfo(object sender, EventArgs e)
        {
            PictureBox picBox = sender as PictureBox;
            StringBuilder sb = new StringBuilder();
            sb.Append($"Position X: {picBox.Top / SIZE}, Y: {picBox.Left / SIZE}");
            sb.Append($" Tag: {picBox.Tag}");
            Console.WriteLine(sb);
        }
        private void SelectTile(object sender, EventArgs e)
        {
            PictureBox picBox = sender as PictureBox;
            DisplayPicInfo(picBox, EventArgs.Empty);
            if (IsTileABox(picBox)) UpdateSelectedBox(picBox);
        }
        private bool IsTileABox(PictureBox picBox)
        {
            if (picBoxMapping[picBox.Top / SIZE, picBox.Left / SIZE] != null)
            {
                return picBox.Name.Equals("greenBox") || picBoxMapping[picBox.Top / SIZE, picBox.Left / SIZE].Tag.Equals("5")
                    || picBox.Name.Equals("redBox") || picBoxMapping[picBox.Top / SIZE, picBox.Left / SIZE].Tag.Equals("3");
            }
            return false;
        }
        private void UpdateSelectedBox(PictureBox picBox)
        {
            selectedTile = GetSelectedTile();
            //selectedTile.Location = new Point(picBox.Location.X, picBox.Location.Y);
            //selectedTile.Name = picBox.Name;
            //selectedTile.Top = picBox.Top;
            //selectedTile.Left = picBox.Left;
            //selectedTile.Tag = picBox.Tag;
            //selectedTile.BackgroundImage = picBox.BackgroundImage;
            //selectedTile.BorderStyle = picBox.BorderStyle;

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
            //ChangeCntrlButtonsActive(picBox);
        }
        private PictureBox GetTile(int row, int col)
        {
            return picBoxMapping[row, col];
        }
        private PictureBox GetSelectedTile()
        {
            PictureBox selected = null;
            foreach (Control control in pnlLoadTiles.Controls)
            {
                selected = control as PictureBox;
                if (selected.BorderStyle == BorderStyle.Fixed3D)
                {
                    break;
                } else
                {
                    selected = null;
                }
            }
            return selected;
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
        #endregion

        #region Control Buttons

        private void ChangeEnabledControlButtons(bool enabled)
        {
            foreach (Control button in pnlCntrlButtons.Controls)
            {
                Button dummy = button as Button;

                dummy.Enabled = enabled;

            }
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
            if (GetSelectedTile() == null)
            {
                MessageBox.Show("Select a box to move", "Can't move", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {

                Button dummy = sender as Button;
                string direction = dummy.Text;
                shouldMove = true;
                while (IsNeighbourEmpty(direction))
                {
                    UpdateSelectedBoxLocation();
                    UpdatePicBoxMappingArray();
                    pastMovement++;
                }
                UpdateRemainingBoxes();
                UpdateMoves();
                CheckWinner();
            }
        }
        #endregion

        #region Movement
        private bool IsNeighbourEmpty(string direction)
        {
            shouldMove = true;

            originalXPos = GetSelectedTile().Top / SIZE;
            originalYPos = GetSelectedTile().Left / SIZE;

            checkingX = originalXPos;
            checkingY = originalYPos;

            try
            {
                switch (direction)
                {

                    case "Up":
                        checkingX -= 1;
                        if (picBoxMapping[checkingX, checkingY] != null)
                        {
                            if (picBoxMapping[checkingX, checkingY].Tag.Equals(2) || picBoxMapping[checkingX, checkingY].Tag.Equals(3))
                            {
                                if (DoesDoorMatch())
                                {
                                    DeleteSelectedTile();
                                    UpdateRemainingBoxes();
                                    pastMovement++;
                                }

                            }
                            checkingX++;
                            shouldMove = false;
                        }
                        break;
                    case "Down":
                        checkingX += 1;
                        if (picBoxMapping[checkingX, checkingY] != null)
                        {
                            if (picBoxMapping[checkingX, checkingY].Tag.Equals(2) || picBoxMapping[checkingX, checkingY].Tag.Equals(4))
                            {
                                if (DoesDoorMatch())
                                {
                                    DeleteSelectedTile();
                                    UpdateRemainingBoxes();
                                    pastMovement++;
                                }

                            }

                            checkingX--;

                            shouldMove = false;
                        }
                        break;
                    case "Right":
                        checkingY += 1;
                        if (picBoxMapping[checkingX, checkingY] != null)
                        {
                            if (picBoxMapping[checkingX, checkingY].Tag.Equals(2) || picBoxMapping[checkingX, checkingY].Tag.Equals(3))
                            {
                                if (DoesDoorMatch())
                                {
                                    DeleteSelectedTile();
                                    UpdateRemainingBoxes();
                                    pastMovement++;
                                }

                            }
                            checkingY--;
                            shouldMove = false;
                        }
                        break;
                    case "Left":
                        checkingY -= 1;
                        if (picBoxMapping[checkingX, checkingY] != null)
                        {
                            if (picBoxMapping[checkingX, checkingY].Tag.Equals(3) || picBoxMapping[checkingX, checkingY].Tag.Equals(4))
                            {
                                if (DoesDoorMatch())
                                {
                                    DeleteSelectedTile();
                                    UpdateRemainingBoxes();
                                    pastMovement++;
                                }

                            }
                            checkingY++;
                            shouldMove = false;
                        }
                        break;
                }
            } catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("That was not supposed to happen", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }





            return shouldMove;
        }
        private void DeleteSelectedTile()
        {

            pnlLoadTiles.Controls.Remove(picBoxMapping[originalXPos, originalYPos]);
            picBoxMapping[originalXPos, originalYPos] = null;
        }
        private bool DoesDoorMatch()
        {
            if (picBoxMapping[originalXPos, originalYPos].Tag.Equals(3) && picBoxMapping[checkingX, checkingY].Tag.Equals(2)
                || picBoxMapping[originalXPos, originalYPos].Tag.Equals(5) && picBoxMapping[checkingX, checkingY].Tag.Equals(4))
                return true;

            return false;
        }
        private void UpdatePicBoxMappingArray()
        {
            picBoxMapping[checkingX, checkingY] = GetSelectedTile();
            //UpdateSelectedBox(picBoxMapping[checkingX, checkingY]);
            picBoxMapping[originalXPos, originalYPos] = null;
        }
        private void UpdateSelectedBoxLocation()
        {
            picBoxMapping[originalXPos, originalYPos].Top = checkingX * SIZE;
            picBoxMapping[originalXPos, originalYPos].Left = checkingY * SIZE;
            //selectedTile.Top = checkingX * SIZE;
            //selectedTile.Left =  checkingY * SIZE;
        }
        #endregion

        #region Updating Info
        private void UpdateRemainingBoxes()
        {
            boxesRemaining = 0;
            foreach (PictureBox ent in picBoxMapping)
            {
                if (ent != null)
                {

                    if (ent.Tag.Equals(3) || ent.Tag.Equals(5))
                    {
                        boxesRemaining++;
                    }
                }
            }
            txtNumbBoxes.Text = boxesRemaining.ToString();
        }
        private void CheckWinner()
        {
            if (boxesRemaining == 0)
            {
                ShowWinScreen();
            }
        }
        private void ShowWinScreen()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Congratulations, you won the game");
            //sb.AppendLine($"Movements used: {movements}");
            MessageBox.Show(sb.ToString(), "You won!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearMap();
        }
        private void ClearMap()
        {
            pnlLoadTiles.Controls.Clear();
            ChangeEnabledControlButtons(false);
        }
        private void UpdateMoves()
        {
            if (pastMovement != currentMovement)
            {
                movements++;
            }
            currentMovement = pastMovement;
            txtNumbMoves.Text = movements.ToString();
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

        #endregion
    }
}
