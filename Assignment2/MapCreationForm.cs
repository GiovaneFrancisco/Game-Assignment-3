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
    public partial class MapCreationForm : Form
    {
        #region Variables
        //General variables to be used throught the project
        private int rows = 10;
        private int columns = 10;
        private string selectedTile = "";
        public const int SIZE = 64;

        private const string fileName = "mapTiles.txt";

        int countWall = 0, countRedDoor = 0, countRedBox = 0, countGreenDoor = 0, countGreenBox = 0;
        private StringBuilder saveMessage = new StringBuilder();
        private StringBuilder saveTitle = new StringBuilder();
        private MessageBoxIcon saveIcon;

        private Tile[,] tileMapping;
        List<PictureBox> picturesList = new List<PictureBox>();
        #endregion

        #region Constructor
        public MapCreationForm()
        {
            InitializeComponent();

        }
        #endregion

        #region Calculation
        /// <summary>
        /// Calculates the location based on the default 64px size and return the Location
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns>new Location</returns>
        public Location CalculateLocation(int row, int column)
        {
            int x = column * SIZE;
            int y = row * SIZE;

            return new Location(x, y);
        }
        #endregion

        #region User Inputs
        /// <summary>
        /// Clear the txtBoxes Row/Column
        /// </summary>
        private void ClearInputs()
        {
            txtRows.Clear();
            txtColumns.Clear();
        }
        #endregion

        #region Error Checking

        /// <summary>
        /// Checks the values given for the Row/Column
        /// </summary>
        /// <returns>True is no errors/exceptions were found</returns>
        private bool ShouldCreateMap()
        {
            bool mapCreated = false;
            int rows;
            int cols;
            if (!int.TryParse(txtRows.Text, out rows) || !int.TryParse(txtColumns.Text, out cols))
            {
                ShowErrorMessage("Values for Rows/Columns must be integers", "Error generating new map!");
            } else
            {
                if (rows < 0 || cols < 0)
                {
                    ShowErrorMessage("Values for Rows/Columns must be positive", "Error generating new map!");
                } else
                {
                    if (rows > 10 || cols > 10)
                    {
                        ShowErrorMessage("Maximum size for Rows/Columns is 10", "Error generating new map!");
                    } else
                    {
                        mapCreated = true;
                    }
                }
            }
            return mapCreated;
        }


        /// <summary>
        /// Displays a MessageBox with the message and the title
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        private void ShowErrorMessage(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            ClearInputs();
        }

        #endregion

        #region Map Creation
        /// <summary>
        /// Checks if there's no errors in the Row/Column Texboxes
        /// If true, Generate the tiles 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerateMap_Click(object sender, EventArgs e)
        {
            if (HasCreatedMap()) ClearMap();

            if (ShouldCreateMap()) GenerateTiles();
        }

        private void ClearMap()
        {
            pnlMap.Controls.Clear();
        }

        /// <summary>
        /// Creates the starting tiles, with the texture floor.png
        /// Uses the given Row/Column values to create X amount of generic PictureBoxes
        /// Sets the size, background image, location, border style, name, tag and a click event
        /// Changes the visibility for pnlResources and btnSaveMap to true
        /// Changes the visibility for btnGenerateMap to false
        /// </summary> 
        public void GenerateTiles()
        {
            rows = int.Parse(txtRows.Text);
            columns = int.Parse(txtColumns.Text);
            if (pnlMap.Controls.Count > 0)
            {
                foreach (Control item in pnlMap.Controls.OfType<PictureBox>())
                {
                    pnlMap.Controls.Remove(item);
                }

            }
            tileMapping = new Tile[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    PictureBox picBox = new PictureBox();
                    None none = MapGeneration.CreateStartingGrid(CalculateLocation(row, column));
                    picBox.BackgroundImage = none.Image;
                    picBox.Location = new Point(none.Location.X, none.Location.Y);
                    picBox.Size = new System.Drawing.Size(none.Size.Width, none.Size.Height);
                    picBox.BorderStyle = BorderStyle.FixedSingle;
                    picBox.Click += new EventHandler(ChangeSelectedTile);
                    picBox.Name = "None";
                    picBox.Tag = 0;
                    pnlMap.Controls.Add(picBox);
                    tileMapping[row, column] = null;
                }
            }
            pnlResources.Visible = true;
        }

        /// <summary>
        /// Creates the map if the key "Enter" is pressed while the txtColumns has the focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtColumns_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (ShouldCreateMap()) GenerateTiles();
            }
        }


        #endregion

        #region Tile/Button Dealing

        /// <summary>
        /// Changes the selected object to one of the Tiles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeSelectedTile(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;

            if (selectedTile != "")
            {
                CreateNewTileObject(pic, selectedTile, new Location(pic.Location.X, pic.Location.Y));
            }
        }

        /// <summary>
        /// Selects the respective Button behind the selected Tile PictureBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FocusTileButton(object sender, EventArgs e)
        {
            Control control;
            if (sender is PictureBox)
            {
                control = sender as PictureBox;
            } else
            {
                control = sender as Button;
            }
            switch (control.Name)
            {
                case "pixboxNone":
                    btnTileNone.Select();
                    break;
                case "picboxWall":
                    btnTileWall.Select();
                    break;
                case "picboxRedDoor":
                    btnTileRedDoor.Select();
                    break;
                case "picboxGreenDoor":
                    btnTileGreenDoor.Select();
                    break;
                case "picboxGreenBox":
                    btnTileGreenBox.Select();
                    break;
                case "picboxRedBox":
                    btnTileRedBox.Select();
                    break;
            }
        }


        private void TileButtonClick(object sender, EventArgs e)
        {
            FocusTileButton(sender, e);
            SelectTile(sender, e);
        }

        /// <summary>
        /// Creates a new object depending on which Structure is selected
        /// Sets the image, location and tag
        /// </summary>
        /// <param name="picBox"></param>
        /// <param name="selectedObject"></param>
        /// <param name="location"></param>
        private void CreateNewTileObject(PictureBox picBox, string selectedObject, Location location)
        {
            None none;
            Wall wall;
            GreenBox greenBox;
            GreenDoor greenDoor;
            RedBox redBox;
            RedDoor redDoor;

            switch (selectedObject)
            {
                case "None":
                    none = new None(location);
                    ChangeTileImageAndNameTag(picBox, none, "None");
                    break;

                case "Wall":
                    wall = new Wall(location);
                    ChangeTileImageAndNameTag(picBox, wall, "Wall");
                    break;

                case "RedDoor":
                    redDoor = new RedDoor(location);
                    ChangeTileImageAndNameTag(picBox, redDoor, "RedDoor");
                    break;

                case "RedBox":
                    redBox = new RedBox(location);
                    ChangeTileImageAndNameTag(picBox, redBox, "RedBox");
                    break;

                case "GreenDoor":
                    greenDoor = new GreenDoor(location);
                    ChangeTileImageAndNameTag(picBox, greenDoor, "GreenDoor");
                    break;

                case "GreenBox":
                    greenBox = new GreenBox(location);
                    ChangeTileImageAndNameTag(picBox, greenBox, "GreenBox");
                    break;
            }

        }

        /// <summary>
        /// Changes the Generic PictureBox's image to be the selected Tile
        /// If no Tile is select, nothing happens
        /// </summary>
        /// <param name="picBox"></param>
        /// <param name="entity"></param>
        /// <param name="name"></param>
        private void ChangeTileImageAndNameTag(PictureBox picBox, Entity entity, string name)
        {
            picBox.BackgroundImage = entity.Image;
            picBox.Name = name;
            switch (name)
            {
                case "None":
                    picBox.Tag = 0;
                    break;
                case "Wall":
                    picBox.Tag = 1;
                    break;
                case "RedDoor":
                    picBox.Tag = 2;
                    break;
                case "RedBox":
                    picBox.Tag = 3;
                    break;
                case "GreenDoor":
                    picBox.Tag = 4;
                    break;
                case "GreenBox":
                    picBox.Tag = 5;
                    break;
            }
        }


        /// <summary>
        /// Sets the selectedTile to the same as the selected PictureBox Tile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectTile(object sender, EventArgs e)
        {
            Control pic;
            string name;
            if (sender is PictureBox)
            {
                pic = sender as PictureBox;
                name = pic.Name.Substring(6);

            } else
            {
                pic = sender as Button;
                name = pic.Name.Substring(7);
            }
            selectedTile = name;
        }

        #endregion

        #region Save Map

        /// <summary>
        /// Updates the Save Message to be shown
        /// Error message if the Door and Box count isn't the same
        /// Success message if the file is saved
        /// </summary>
        private void UpdateSaveMessage()
        {
            bool save = true;
            saveMessage.Clear();
            saveTitle.Clear();

            saveTitle.Append("Error saving the map");
            saveIcon = MessageBoxIcon.Error;

            CountTotalBoxesDoors(picturesList);
            if (!HasCreatedMap())
            {
                save = false;
                saveMessage.AppendLine("You must create a map before saving it!");
            } else
            {


                if (countGreenBox == 0 || countGreenDoor == 0 || countRedBox == 0 || countRedDoor == 0)
                {
                    if (countGreenDoor == 0 && countRedDoor == 0)
                    {
                        save = false;
                        saveMessage.AppendLine("There should be at least one Door and one matching Box");
                    }
                    if (countGreenDoor != 0 && countGreenBox == 0)
                    {
                        save = false;
                        saveMessage.AppendLine("There should be at least one Green Box");
                    }
                    if (countRedDoor != 0 && countRedBox == 0)
                    {
                        save = false;
                        saveMessage.AppendLine("There should be at least one Red Box");
                    }
                }
                if (save)
                {
                    saveTitle.Clear();
                    saveTitle.Append("Map saved successfully");
                    saveIcon = MessageBoxIcon.Information;
                    saveMessage.AppendLine($"Total number of walls: {countWall}");
                    saveMessage.AppendLine($"Total number of doors: {countRedDoor + countGreenDoor}");
                    saveMessage.AppendLine($"Total number of boxes: {countRedBox + countGreenBox}");
                }

            }
        }

        private void CountTotalBoxesDoors(List<PictureBox> picturesList)
        {
            countGreenBox = 0;
            countGreenDoor = 0;
            countRedBox = 0;
            countRedDoor = 0;
            foreach (PictureBox pic in picturesList)
            {
                if ((int)pic.Tag == 2)
                {
                    countRedDoor++;
                } else if ((int)pic.Tag == 3)
                {
                    countRedBox++;
                } else if ((int)pic.Tag == 4)
                {
                    countGreenDoor++;
                } else if ((int)pic.Tag == 5)
                {
                    countGreenBox++;
                }
            }
        }

        /// <summary>
        /// Checks if the map should be saved or not
        /// </summary>
        /// <param name="picList"></param>
        /// <returns>true if should be saved</returns>
        private bool ShouldSaveMap(List<PictureBox> picList)
        {
            CountTotalBoxesDoors(picList);
            if (countGreenDoor == 0 && countRedDoor == 0 || !HasCreatedMap())
            {

                return false;
            } else
            {
                if (countGreenDoor != 0 && countGreenBox == 0 || countRedDoor != 0 && countRedBox == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private bool HasCreatedMap()
        {
            foreach (Control control in pnlMap.Controls)
            {
                if (control != null) return true;
            }
            return false;
        }

        /// <summary>
        /// Counts how many Wall tiles are in the grid
        /// Updates the countWall variable
        /// </summary>
        /// <param name="picList"></param>
        private void CountWall(List<PictureBox> picList)
        {
            countWall = 0;
            foreach (PictureBox pic in picList)
            {
                if ((int)pic.Tag == 1)
                {
                    countWall++;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureBox picBox;
            picturesList.Clear();
            foreach (Control cntrl in pnlMap.Controls)
            {
                picBox = cntrl as PictureBox;
                picturesList.Add(picBox);
            }
            if (ShouldSaveMap(picturesList))
            {
                SaveMap(picturesList);
            }
            CountWall(picturesList);
            UpdateSaveMessage();
            ShowSaveMessage();
        }

        /// <summary>
        /// Saves the board size in the first line (row - column)
        /// Goes through all the items in the received list
        /// Saves it's position (row - column) and it's Tag 
        ///                                             0 -> None
        ///                                             1 -> Wall
        ///                                             2 -> Red Door
        ///                                             3 -> Red Box
        ///                                             4 -> Green Door
        ///                                             5 -> Green Box
        /// </summary>
        /// <param name="picList"></param>
        private void SaveMap(List<PictureBox> picList)
        {
            PictureBox picBox;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "QGame (*.qgame)|*.qgame";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                int row = rows;
                int col = columns;

                if (File.Exists(saveFileDialog.FileName) && File.ReadAllLines(saveFileDialog.FileName) != null)
                {
                    File.WriteAllText(saveFileDialog.FileName, "");
                }


                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName, true))
                {
                    writer.Write(row);
                    writer.WriteLine(col);

                    string name;
                    string tag;
                    int count = 0;
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            picBox = picList[count];
                            count++;
                            row = picBox.Top / SIZE;
                            col = picBox.Left / SIZE;
                            name = picBox.Name;
                            tag = picBox.Tag.ToString();
                            writer.Write(row + "" + col + "" + tag + "\n");
                            switch (tag)
                            {
                                case "1":
                                    countWall++;
                                    break;
                                case "2":
                                    countRedDoor++;
                                    break;
                                case "3":
                                    countRedBox++;
                                    break;
                                case "4":
                                    countGreenDoor++;
                                    break;
                                case "5":
                                    countGreenBox++;
                                    break;
                            }
                        }
                    }
                }
            } else
            {
                saveTitle.Clear();
                saveTitle.Append("Map saved successfully");
                saveMessage.Append("Map not saved");
                saveIcon = MessageBoxIcon.Information;
            }
        }

        private void ShowSaveMessage()
        {
            MessageBox.Show(saveMessage.ToString(), saveTitle.ToString(), MessageBoxButtons.OK, saveIcon);
        }
        #endregion

        #region Close Application
        /// <summary>
        /// Closes the application once the X is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void OnFormClosing(object sender, FormClosingEventArgs e)
        //{
        //    Environment.Exit(0);

        //}
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
