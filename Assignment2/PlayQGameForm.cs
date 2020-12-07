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
       
        /// <summary>
        /// Reads the selected file and sets up the starting grid
        /// </summary>
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
                        //Thread.sleep(10)
                    }
                }
                UpdateRemainingBoxes();
                ChangeEnabledControlButtons(true);
                //PrintTilesArray();
            }
        }
        /// <summary>
        /// Checks if theres a loaded map
        /// </summary>
        /// <returns></returns>
        private bool HasLoadedMap()
        {
            foreach (Control cntrl in pnlLoadTiles.Controls)
            {
                if (cntrl is PictureBox) return true;
            }
            return false;
        }
        /// <summary>
        /// Sets the attributes for every picture box created
        /// </summary>
        /// <param name="picBox"></param>
        /// <param name="tile"></param>
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
        /// <summary>
        /// Displays the information from a PictureBox (Debbuging only)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayPicInfo(object sender, EventArgs e)
        {
            PictureBox picBox = sender as PictureBox;
            StringBuilder sb = new StringBuilder();
            sb.Append($"Position X: {picBox.Top / SIZE}, Y: {picBox.Left / SIZE}");
            sb.Append($" Tag: {picBox.Tag}");
            Console.WriteLine(sb);
        }
        /// <summary>
        /// Selects a box to be moved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectTile(object sender, EventArgs e)
        {
            PictureBox picBox = sender as PictureBox;
            DisplayPicInfo(picBox, EventArgs.Empty);
            if (IsTileABox(picBox)) UpdateSelectedBox(picBox);
        }
        /// <summary>
        /// Checks if the selected tile is a box
        /// </summary>
        /// <param name="picBox"></param>
        /// <returns></returns>
        private bool IsTileABox(PictureBox picBox)
        {
            if (picBoxMapping[picBox.Top / SIZE, picBox.Left / SIZE] != null)
            {
                return picBox.Name.Equals("greenBox") || picBoxMapping[picBox.Top / SIZE, picBox.Left / SIZE].Tag.Equals("5")
                    || picBox.Name.Equals("redBox") || picBoxMapping[picBox.Top / SIZE, picBox.Left / SIZE].Tag.Equals("3");
            }
            return false;
        }
        /// <summary>
        /// Updates the information from the selected box
        /// </summary>
        /// <param name="picBox"></param>
        private void UpdateSelectedBox(PictureBox picBox)
        {
            selectedTile = GetSelectedTile();

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
        /// <summary>
        /// Gets the selected tyle
        /// </summary>
        /// <returns>PictureBox selected tyle</returns>
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
        /// <summary>
        /// Sets the tag from the selected tyle
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="tileTag"></param>
        /// <param name="position"></param>
        /// <returns>Entity class depending on the tag</returns>
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
        /// <summary>
        /// Changed the enabled property from the control buttons
        /// </summary>
        /// <param name="enabled"></param>
        private void ChangeEnabledControlButtons(bool enabled)
        {
            foreach (Control button in pnlCntrlButtons.Controls)
            {
                Button dummy = button as Button;

                dummy.Enabled = enabled;

            }
        }
        /// <summary>
        /// Deals with the click from the control buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Checks if the neighbour from a tile is empty
        /// </summary>
        /// <param name="direction"></param>
        /// <returns>true if empty / null / tag = 0</returns>
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
        /// <summary>
        /// Deletes the selected tile from the array / control panel
        /// </summary>
        private void DeleteSelectedTile()
        {

            pnlLoadTiles.Controls.Remove(picBoxMapping[originalXPos, originalYPos]);
            picBoxMapping[originalXPos, originalYPos] = null;
        }
        /// <summary>
        /// Checks if the collided door matches with the collided box
        /// </summary>
        /// <returns>True if dooe and box match</returns>
        private bool DoesDoorMatch()
        {
            if (picBoxMapping[originalXPos, originalYPos].Tag.Equals(3) && picBoxMapping[checkingX, checkingY].Tag.Equals(2)
                || picBoxMapping[originalXPos, originalYPos].Tag.Equals(5) && picBoxMapping[checkingX, checkingY].Tag.Equals(4))
                return true;

            return false;
        }
        /// <summary>
        /// Updates the PictureBox array
        /// </summary>
        private void UpdatePicBoxMappingArray()
        {
            picBoxMapping[checkingX, checkingY] = GetSelectedTile();
            //UpdateSelectedBox(picBoxMapping[checkingX, checkingY]);
            picBoxMapping[originalXPos, originalYPos] = null;
        }
        /// <summary>
        /// Updates the current selected tile location
        /// </summary>
        private void UpdateSelectedBoxLocation()
        {
            picBoxMapping[originalXPos, originalYPos].Top = checkingX * SIZE;
            picBoxMapping[originalXPos, originalYPos].Left = checkingY * SIZE;
            //selectedTile.Top = checkingX * SIZE;
            //selectedTile.Left =  checkingY * SIZE;
        }
        #endregion

        #region Updating Info
        /// <summary>
        /// Updates the amount of boxes remaining on the grid
        /// </summary>
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
        /// <summary>
        /// Checks if the amount of remaing boxes is 0
        /// </summary>
        private void CheckWinner()
        {
            if (boxesRemaining == 0)
            {
                ShowWinScreen();
            }
        }
        /// <summary>
        /// Shows a message notifying the victory
        /// </summary>
        private void ShowWinScreen()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Congratulations, you won the game");
            //sb.AppendLine($"Movements used: {movements}");
            MessageBox.Show(sb.ToString(), "You won!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearMap();
        }
        /// <summary>
        /// Clears all the controls from the panel
        /// </summary>
        private void ClearMap()
        {
            pnlLoadTiles.Controls.Clear();
            ChangeEnabledControlButtons(false);
        }
        /// <summary>
        /// Updates the amount of movements 
        /// </summary>
        private void UpdateMoves()
        {
            if (pastMovement != currentMovement)
            {
                movements++;
            }
            currentMovement = pastMovement;
            txtNumbMoves.Text = movements.ToString();
        }
        /// <summary>
        /// Prints the .Tyle property from the picBoxMapping array (debbugin)
        /// </summary>
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
