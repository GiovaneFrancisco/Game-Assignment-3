using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class StartScreenForm : Form
    {
        public StartScreenForm()
        {
            InitializeComponent();
        }

        private void btnCreateNewMap_Click(object sender, EventArgs e)
        {
            MapCreationForm mc = new MapCreationForm();
            mc.Show();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            PlayQGameForm pg = new PlayQGameForm();
            pg.Show();
        }

        

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
