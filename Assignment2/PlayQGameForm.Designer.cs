namespace Assignment2
{
    partial class PlayQGameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlLoadTiles = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblRemBoxes = new System.Windows.Forms.Label();
            this.lblNumberMoves = new System.Windows.Forms.Label();
            this.txtNumbBoxes = new System.Windows.Forms.TextBox();
            this.txtNumbMoves = new System.Windows.Forms.TextBox();
            this.pnlCntrlButtons = new System.Windows.Forms.Panel();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlCntrlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMapToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(41, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadMapToolStripMenuItem
            // 
            this.loadMapToolStripMenuItem.Name = "loadMapToolStripMenuItem";
            this.loadMapToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.loadMapToolStripMenuItem.Text = "Load Map";
            this.loadMapToolStripMenuItem.Click += new System.EventHandler(this.loadMapToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // pnlLoadTiles
            // 
            this.pnlLoadTiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlLoadTiles.Location = new System.Drawing.Point(12, 30);
            this.pnlLoadTiles.Name = "pnlLoadTiles";
            this.pnlLoadTiles.Size = new System.Drawing.Size(538, 437);
            this.pnlLoadTiles.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblRemBoxes);
            this.panel2.Controls.Add(this.lblNumberMoves);
            this.panel2.Controls.Add(this.txtNumbBoxes);
            this.panel2.Controls.Add(this.txtNumbMoves);
            this.panel2.Location = new System.Drawing.Point(556, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(232, 148);
            this.panel2.TabIndex = 2;
            // 
            // lblRemBoxes
            // 
            this.lblRemBoxes.AutoSize = true;
            this.lblRemBoxes.Location = new System.Drawing.Point(9, 76);
            this.lblRemBoxes.Name = "lblRemBoxes";
            this.lblRemBoxes.Size = new System.Drawing.Size(144, 13);
            this.lblRemBoxes.TabIndex = 3;
            this.lblRemBoxes.Text = "Number of Remaining Boxes:";
            // 
            // lblNumberMoves
            // 
            this.lblNumberMoves.AutoSize = true;
            this.lblNumberMoves.Location = new System.Drawing.Point(9, 14);
            this.lblNumberMoves.Name = "lblNumberMoves";
            this.lblNumberMoves.Size = new System.Drawing.Size(94, 13);
            this.lblNumberMoves.TabIndex = 2;
            this.lblNumberMoves.Text = "Number of Moves:";
            // 
            // txtNumbBoxes
            // 
            this.txtNumbBoxes.Enabled = false;
            this.txtNumbBoxes.Location = new System.Drawing.Point(12, 92);
            this.txtNumbBoxes.Name = "txtNumbBoxes";
            this.txtNumbBoxes.Size = new System.Drawing.Size(199, 20);
            this.txtNumbBoxes.TabIndex = 1;
            this.txtNumbBoxes.Text = "0";
            this.txtNumbBoxes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNumbMoves
            // 
            this.txtNumbMoves.Enabled = false;
            this.txtNumbMoves.Location = new System.Drawing.Point(12, 30);
            this.txtNumbMoves.Name = "txtNumbMoves";
            this.txtNumbMoves.Size = new System.Drawing.Size(199, 20);
            this.txtNumbMoves.TabIndex = 0;
            this.txtNumbMoves.Text = "0";
            this.txtNumbMoves.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnlCntrlButtons
            // 
            this.pnlCntrlButtons.Controls.Add(this.btnLeft);
            this.pnlCntrlButtons.Controls.Add(this.btnRight);
            this.pnlCntrlButtons.Controls.Add(this.btnDown);
            this.pnlCntrlButtons.Controls.Add(this.btnUp);
            this.pnlCntrlButtons.Location = new System.Drawing.Point(556, 184);
            this.pnlCntrlButtons.Name = "pnlCntrlButtons";
            this.pnlCntrlButtons.Size = new System.Drawing.Size(232, 283);
            this.pnlCntrlButtons.TabIndex = 3;
            // 
            // btnLeft
            // 
            this.btnLeft.Enabled = false;
            this.btnLeft.Location = new System.Drawing.Point(37, 151);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(50, 50);
            this.btnLeft.TabIndex = 3;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.BtnCntrlClick);
            // 
            // btnRight
            // 
            this.btnRight.Enabled = false;
            this.btnRight.Location = new System.Drawing.Point(149, 151);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(50, 50);
            this.btnRight.TabIndex = 2;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.BtnCntrlClick);
            // 
            // btnDown
            // 
            this.btnDown.Enabled = false;
            this.btnDown.Location = new System.Drawing.Point(93, 151);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(50, 50);
            this.btnDown.TabIndex = 1;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.BtnCntrlClick);
            // 
            // btnUp
            // 
            this.btnUp.Enabled = false;
            this.btnUp.Location = new System.Drawing.Point(93, 95);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(50, 50);
            this.btnUp.TabIndex = 0;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.BtnCntrlClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            // 
            // PlayQGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 473);
            this.Controls.Add(this.pnlCntrlButtons);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlLoadTiles);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PlayQGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlayQGame";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlCntrlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Panel pnlLoadTiles;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblRemBoxes;
        private System.Windows.Forms.Label lblNumberMoves;
        private System.Windows.Forms.TextBox txtNumbBoxes;
        private System.Windows.Forms.TextBox txtNumbMoves;
        private System.Windows.Forms.Panel pnlCntrlButtons;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Timer timer1;
    }
}