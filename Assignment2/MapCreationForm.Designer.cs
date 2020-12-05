using System;
using System.Windows.Forms;

namespace Assignment2
{
    partial class MapCreationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapCreationForm));
            this.pnlResources = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnTileRedBox = new System.Windows.Forms.Button();
            this.btnTileGreenBox = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTileGreenDoor = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStructure = new System.Windows.Forms.Label();
            this.btnTileWall = new System.Windows.Forms.Button();
            this.btnTileRedDoor = new System.Windows.Forms.Button();
            this.btnTileNone = new System.Windows.Forms.Button();
            this.pnlMap = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupControl = new System.Windows.Forms.GroupBox();
            this.btnGenerateMap = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtColumns = new System.Windows.Forms.TextBox();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picboxRedBox = new System.Windows.Forms.PictureBox();
            this.picboxGreenBox = new System.Windows.Forms.PictureBox();
            this.picboxGreenDoor = new System.Windows.Forms.PictureBox();
            this.picboxRedDoor = new System.Windows.Forms.PictureBox();
            this.picboxWall = new System.Windows.Forms.PictureBox();
            this.pixboxNone = new System.Windows.Forms.PictureBox();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlResources.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupControl.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxRedBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxGreenBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxGreenDoor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxRedDoor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxWall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixboxNone)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlResources
            // 
            this.pnlResources.Controls.Add(this.label8);
            this.pnlResources.Controls.Add(this.label7);
            this.pnlResources.Controls.Add(this.picboxRedBox);
            this.pnlResources.Controls.Add(this.btnTileRedBox);
            this.pnlResources.Controls.Add(this.picboxGreenBox);
            this.pnlResources.Controls.Add(this.btnTileGreenBox);
            this.pnlResources.Controls.Add(this.label5);
            this.pnlResources.Controls.Add(this.picboxGreenDoor);
            this.pnlResources.Controls.Add(this.btnTileGreenDoor);
            this.pnlResources.Controls.Add(this.label6);
            this.pnlResources.Controls.Add(this.label4);
            this.pnlResources.Controls.Add(this.label3);
            this.pnlResources.Controls.Add(this.picboxRedDoor);
            this.pnlResources.Controls.Add(this.picboxWall);
            this.pnlResources.Controls.Add(this.pixboxNone);
            this.pnlResources.Controls.Add(this.lblStructure);
            this.pnlResources.Controls.Add(this.btnTileWall);
            this.pnlResources.Controls.Add(this.btnTileRedDoor);
            this.pnlResources.Controls.Add(this.btnTileNone);
            this.pnlResources.Location = new System.Drawing.Point(12, 144);
            this.pnlResources.Name = "pnlResources";
            this.pnlResources.Size = new System.Drawing.Size(175, 569);
            this.pnlResources.TabIndex = 0;
            this.pnlResources.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(88, 415);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Red Box";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(88, 505);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Green Box";
            // 
            // btnTileRedBox
            // 
            this.btnTileRedBox.Location = new System.Drawing.Point(12, 381);
            this.btnTileRedBox.Name = "btnTileRedBox";
            this.btnTileRedBox.Size = new System.Drawing.Size(149, 75);
            this.btnTileRedBox.TabIndex = 25;
            this.btnTileRedBox.UseVisualStyleBackColor = true;
            this.btnTileRedBox.Click += new System.EventHandler(this.TileButtonClick);
            // 
            // btnTileGreenBox
            // 
            this.btnTileGreenBox.Location = new System.Drawing.Point(12, 471);
            this.btnTileGreenBox.Name = "btnTileGreenBox";
            this.btnTileGreenBox.Size = new System.Drawing.Size(149, 75);
            this.btnTileGreenBox.TabIndex = 22;
            this.btnTileGreenBox.UseVisualStyleBackColor = true;
            this.btnTileGreenBox.Click += new System.EventHandler(this.TileButtonClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(88, 328);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Green Door";
            // 
            // btnTileGreenDoor
            // 
            this.btnTileGreenDoor.Location = new System.Drawing.Point(12, 294);
            this.btnTileGreenDoor.Name = "btnTileGreenDoor";
            this.btnTileGreenDoor.Size = new System.Drawing.Size(149, 75);
            this.btnTileGreenDoor.TabIndex = 19;
            this.btnTileGreenDoor.UseVisualStyleBackColor = true;
            this.btnTileGreenDoor.Click += new System.EventHandler(this.TileButtonClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(88, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Red Door";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Wall";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "None";
            // 
            // lblStructure
            // 
            this.lblStructure.AutoSize = true;
            this.lblStructure.Location = new System.Drawing.Point(0, 19);
            this.lblStructure.Name = "lblStructure";
            this.lblStructure.Size = new System.Drawing.Size(55, 13);
            this.lblStructure.TabIndex = 0;
            this.lblStructure.Text = "Structures";
            // 
            // btnTileWall
            // 
            this.btnTileWall.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnTileWall.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnTileWall.Location = new System.Drawing.Point(12, 122);
            this.btnTileWall.Name = "btnTileWall";
            this.btnTileWall.Size = new System.Drawing.Size(149, 75);
            this.btnTileWall.TabIndex = 15;
            this.btnTileWall.UseVisualStyleBackColor = true;
            this.btnTileWall.Click += new System.EventHandler(this.TileButtonClick);
            // 
            // btnTileRedDoor
            // 
            this.btnTileRedDoor.Location = new System.Drawing.Point(12, 209);
            this.btnTileRedDoor.Name = "btnTileRedDoor";
            this.btnTileRedDoor.Size = new System.Drawing.Size(149, 75);
            this.btnTileRedDoor.TabIndex = 16;
            this.btnTileRedDoor.UseVisualStyleBackColor = true;
            this.btnTileRedDoor.Click += new System.EventHandler(this.TileButtonClick);
            // 
            // btnTileNone
            // 
            this.btnTileNone.BackColor = System.Drawing.Color.Transparent;
            this.btnTileNone.Location = new System.Drawing.Point(13, 37);
            this.btnTileNone.Name = "btnTileNone";
            this.btnTileNone.Size = new System.Drawing.Size(148, 75);
            this.btnTileNone.TabIndex = 0;
            this.btnTileNone.UseVisualStyleBackColor = false;
            this.btnTileNone.Click += new System.EventHandler(this.TileButtonClick);
            // 
            // pnlMap
            // 
            this.pnlMap.Location = new System.Drawing.Point(193, 144);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Size = new System.Drawing.Size(640, 569);
            this.pnlMap.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupControl);
            this.panel1.Location = new System.Drawing.Point(12, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 100);
            this.panel1.TabIndex = 2;
            // 
            // groupControl
            // 
            this.groupControl.Controls.Add(this.btnGenerateMap);
            this.groupControl.Controls.Add(this.label2);
            this.groupControl.Controls.Add(this.label1);
            this.groupControl.Controls.Add(this.txtColumns);
            this.groupControl.Controls.Add(this.txtRows);
            this.groupControl.Location = new System.Drawing.Point(3, 3);
            this.groupControl.Name = "groupControl";
            this.groupControl.Size = new System.Drawing.Size(450, 94);
            this.groupControl.TabIndex = 0;
            this.groupControl.TabStop = false;
            this.groupControl.Text = "Controls";
            // 
            // btnGenerateMap
            // 
            this.btnGenerateMap.Location = new System.Drawing.Point(255, 43);
            this.btnGenerateMap.Name = "btnGenerateMap";
            this.btnGenerateMap.Size = new System.Drawing.Size(103, 23);
            this.btnGenerateMap.TabIndex = 4;
            this.btnGenerateMap.Text = "Generate Map";
            this.btnGenerateMap.UseVisualStyleBackColor = true;
            this.btnGenerateMap.Click += new System.EventHandler(this.btnGenerateMap_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Columns";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rows";
            // 
            // txtColumns
            // 
            this.txtColumns.Location = new System.Drawing.Point(134, 46);
            this.txtColumns.Name = "txtColumns";
            this.txtColumns.Size = new System.Drawing.Size(100, 20);
            this.txtColumns.TabIndex = 1;
            this.txtColumns.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtColumns_KeyPress);
            // 
            // txtRows
            // 
            this.txtRows.Location = new System.Drawing.Point(28, 46);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(100, 20);
            this.txtRows.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(854, 27);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(41, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // picboxRedBox
            // 
            this.picboxRedBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.picboxRedBox.Image = ((System.Drawing.Image)(resources.GetObject("picboxRedBox.Image")));
            this.picboxRedBox.Location = new System.Drawing.Point(18, 387);
            this.picboxRedBox.Name = "picboxRedBox";
            this.picboxRedBox.Size = new System.Drawing.Size(64, 64);
            this.picboxRedBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxRedBox.TabIndex = 23;
            this.picboxRedBox.TabStop = false;
            this.picboxRedBox.Click += new System.EventHandler(this.TileButtonClick);
            // 
            // picboxGreenBox
            // 
            this.picboxGreenBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.picboxGreenBox.Image = ((System.Drawing.Image)(resources.GetObject("picboxGreenBox.Image")));
            this.picboxGreenBox.Location = new System.Drawing.Point(18, 477);
            this.picboxGreenBox.Name = "picboxGreenBox";
            this.picboxGreenBox.Size = new System.Drawing.Size(64, 64);
            this.picboxGreenBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxGreenBox.TabIndex = 20;
            this.picboxGreenBox.TabStop = false;
            this.picboxGreenBox.Click += new System.EventHandler(this.TileButtonClick);
            // 
            // picboxGreenDoor
            // 
            this.picboxGreenDoor.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.picboxGreenDoor.Image = ((System.Drawing.Image)(resources.GetObject("picboxGreenDoor.Image")));
            this.picboxGreenDoor.Location = new System.Drawing.Point(18, 300);
            this.picboxGreenDoor.Name = "picboxGreenDoor";
            this.picboxGreenDoor.Size = new System.Drawing.Size(64, 64);
            this.picboxGreenDoor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxGreenDoor.TabIndex = 17;
            this.picboxGreenDoor.TabStop = false;
            this.picboxGreenDoor.Click += new System.EventHandler(this.TileButtonClick);
            // 
            // picboxRedDoor
            // 
            this.picboxRedDoor.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.picboxRedDoor.Image = ((System.Drawing.Image)(resources.GetObject("picboxRedDoor.Image")));
            this.picboxRedDoor.Location = new System.Drawing.Point(18, 215);
            this.picboxRedDoor.Name = "picboxRedDoor";
            this.picboxRedDoor.Size = new System.Drawing.Size(64, 64);
            this.picboxRedDoor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxRedDoor.TabIndex = 4;
            this.picboxRedDoor.TabStop = false;
            this.picboxRedDoor.Click += new System.EventHandler(this.TileButtonClick);
            // 
            // picboxWall
            // 
            this.picboxWall.Image = ((System.Drawing.Image)(resources.GetObject("picboxWall.Image")));
            this.picboxWall.Location = new System.Drawing.Point(18, 128);
            this.picboxWall.Name = "picboxWall";
            this.picboxWall.Size = new System.Drawing.Size(64, 64);
            this.picboxWall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxWall.TabIndex = 2;
            this.picboxWall.TabStop = false;
            this.picboxWall.Click += new System.EventHandler(this.TileButtonClick);
            // 
            // pixboxNone
            // 
            this.pixboxNone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pixboxNone.Image = ((System.Drawing.Image)(resources.GetObject("pixboxNone.Image")));
            this.pixboxNone.Location = new System.Drawing.Point(18, 42);
            this.pixboxNone.Name = "pixboxNone";
            this.pixboxNone.Size = new System.Drawing.Size(64, 64);
            this.pixboxNone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pixboxNone.TabIndex = 1;
            this.pixboxNone.TabStop = false;
            this.pixboxNone.Click += new System.EventHandler(this.TileButtonClick);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // MapCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 778);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlMap);
            this.Controls.Add(this.pnlResources);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MapCreationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map Creation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.pnlResources.ResumeLayout(false);
            this.pnlResources.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupControl.ResumeLayout(false);
            this.groupControl.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxRedBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxGreenBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxGreenDoor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxRedDoor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxWall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixboxNone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlResources;
        private System.Windows.Forms.PictureBox picboxRedDoor;
        private System.Windows.Forms.PictureBox picboxWall;
        private System.Windows.Forms.PictureBox pixboxNone;
        private System.Windows.Forms.Label lblStructure;
        private System.Windows.Forms.Panel pnlMap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupControl;
        private System.Windows.Forms.Button btnGenerateMap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtColumns;
        private System.Windows.Forms.TextBox txtRows;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTileNone;
        private System.Windows.Forms.Button btnTileWall;
        private System.Windows.Forms.Button btnTileRedDoor;
        private Label label5;
        private PictureBox picboxGreenDoor;
        private Button btnTileGreenDoor;
        private Label label8;
        private Label label7;
        private PictureBox picboxRedBox;
        private Button btnTileRedBox;
        private PictureBox picboxGreenBox;
        private Button btnTileGreenBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
    }
}

