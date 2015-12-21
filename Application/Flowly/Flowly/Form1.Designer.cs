namespace Flowly
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveWithoutAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.toolSink = new System.Windows.Forms.PictureBox();
            this.toolSplitter = new System.Windows.Forms.PictureBox();
            this.toolPipe = new System.Windows.Forms.PictureBox();
            this.toolRemove = new System.Windows.Forms.PictureBox();
            this.toolPump = new System.Windows.Forms.PictureBox();
            this.toolSplitterAdj = new System.Windows.Forms.PictureBox();
            this.toolMerger = new System.Windows.Forms.PictureBox();
            this.toolEdit = new System.Windows.Forms.PictureBox();
            this.process1 = new System.Diagnostics.Process();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.grid = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolSink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolSplitter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolPipe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolPump)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolSplitterAdj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolMerger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(949, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveWithoutAsToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.openFileStripMenuItem,
            this.clearGridToolStripMenuItem,
            this.closeGridToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
<<<<<<< Updated upstream
            this.newToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.newToolStripMenuItem.Text = "New";
=======
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New grid";
>>>>>>> Stashed changes
            this.newToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveWithoutAsToolStripMenuItem
            // 
            this.saveWithoutAsToolStripMenuItem.Name = "saveWithoutAsToolStripMenuItem";
<<<<<<< Updated upstream
            this.saveWithoutAsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.saveWithoutAsToolStripMenuItem.Text = "Save";
=======
            this.saveWithoutAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveWithoutAsToolStripMenuItem.Text = "Save grid";
            this.saveWithoutAsToolStripMenuItem.Click += new System.EventHandler(this.saveWithoutAsToolStripMenuItem_Click);
>>>>>>> Stashed changes
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
<<<<<<< Updated upstream
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
=======
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save as grid";
>>>>>>> Stashed changes
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem1_Click);
            // 
            // openFileStripMenuItem
            // 
            this.openFileStripMenuItem.Name = "openFileStripMenuItem";
<<<<<<< Updated upstream
            this.openFileStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.openFileStripMenuItem.Text = "Open file";
=======
            this.openFileStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openFileStripMenuItem.Text = "Open grid";
>>>>>>> Stashed changes
            this.openFileStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // clearGridToolStripMenuItem
            // 
            this.clearGridToolStripMenuItem.Name = "clearGridToolStripMenuItem";
            this.clearGridToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.clearGridToolStripMenuItem.Text = "Clear grid";
            this.clearGridToolStripMenuItem.Click += new System.EventHandler(this.clearGridToolStripMenuItem_Click);
            // 
            // closeGridToolStripMenuItem
            // 
            this.closeGridToolStripMenuItem.Name = "closeGridToolStripMenuItem";
            this.closeGridToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeGridToolStripMenuItem.Text = "Close grid";
            this.closeGridToolStripMenuItem.Click += new System.EventHandler(this.closeGridToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PapayaWhip;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.toolSink);
            this.groupBox1.Controls.Add(this.toolSplitter);
            this.groupBox1.Controls.Add(this.toolPipe);
            this.groupBox1.Controls.Add(this.toolRemove);
            this.groupBox1.Controls.Add(this.toolPump);
            this.groupBox1.Controls.Add(this.toolSplitterAdj);
            this.groupBox1.Controls.Add(this.toolMerger);
            this.groupBox1.Controls.Add(this.toolEdit);
            this.groupBox1.Location = new System.Drawing.Point(-1, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 633);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Toolbox";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.trackBar2);
            this.groupBox2.Controls.Add(this.trackBar1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(0, 333);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(152, 302);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Properties";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "50% : 50%";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(47, 60);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            2147483646,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(54, 20);
            this.numericUpDown1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Direction";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(83, 250);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(45, 17);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "right";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(13, 250);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(43, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Left";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Right";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Left";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Flow";
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(16, 83);
            this.trackBar2.Maximum = 100;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar2.Size = new System.Drawing.Size(45, 127);
            this.trackBar2.TabIndex = 6;
            this.trackBar2.Value = 50;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(101, 83);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 127);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.Value = 50;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 51);
            this.label5.TabIndex = 8;
            this.label5.Text = "Element";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolSink
            // 
            this.toolSink.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.toolSink.Image = ((System.Drawing.Image)(resources.GetObject("toolSink.Image")));
            this.toolSink.Location = new System.Drawing.Point(82, 194);
            this.toolSink.Name = "toolSink";
            this.toolSink.Size = new System.Drawing.Size(46, 43);
            this.toolSink.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.toolSink.TabIndex = 8;
            this.toolSink.TabStop = false;
            // 
            // toolSplitter
            // 
            this.toolSplitter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.toolSplitter.Image = ((System.Drawing.Image)(resources.GetObject("toolSplitter.Image")));
            this.toolSplitter.Location = new System.Drawing.Point(11, 194);
            this.toolSplitter.Name = "toolSplitter";
            this.toolSplitter.Size = new System.Drawing.Size(46, 43);
            this.toolSplitter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.toolSplitter.TabIndex = 6;
            this.toolSplitter.TabStop = false;
            // 
            // toolPipe
            // 
            this.toolPipe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.toolPipe.Image = ((System.Drawing.Image)(resources.GetObject("toolPipe.Image")));
            this.toolPipe.Location = new System.Drawing.Point(82, 145);
            this.toolPipe.Name = "toolPipe";
            this.toolPipe.Size = new System.Drawing.Size(46, 43);
            this.toolPipe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.toolPipe.TabIndex = 5;
            this.toolPipe.TabStop = false;
            this.toolPipe.Click += new System.EventHandler(this.toolPipe_Click);
            // 
            // toolRemove
            // 
            this.toolRemove.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.toolRemove.Image = ((System.Drawing.Image)(resources.GetObject("toolRemove.Image")));
            this.toolRemove.Location = new System.Drawing.Point(80, 47);
            this.toolRemove.Name = "toolRemove";
            this.toolRemove.Size = new System.Drawing.Size(46, 43);
            this.toolRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.toolRemove.TabIndex = 4;
            this.toolRemove.TabStop = false;
            this.toolRemove.Click += new System.EventHandler(this.toolRemove_Click);
            // 
            // toolPump
            // 
            this.toolPump.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.toolPump.Image = ((System.Drawing.Image)(resources.GetObject("toolPump.Image")));
            this.toolPump.Location = new System.Drawing.Point(11, 145);
            this.toolPump.Name = "toolPump";
            this.toolPump.Size = new System.Drawing.Size(46, 43);
            this.toolPump.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.toolPump.TabIndex = 3;
            this.toolPump.TabStop = false;
            this.toolPump.Click += new System.EventHandler(this.toolPump_Click);
            this.toolPump.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolPump_MouseDown);
            // 
            // toolSplitterAdj
            // 
            this.toolSplitterAdj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.toolSplitterAdj.Image = ((System.Drawing.Image)(resources.GetObject("toolSplitterAdj.Image")));
            this.toolSplitterAdj.Location = new System.Drawing.Point(11, 243);
            this.toolSplitterAdj.Name = "toolSplitterAdj";
            this.toolSplitterAdj.Size = new System.Drawing.Size(46, 43);
            this.toolSplitterAdj.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.toolSplitterAdj.TabIndex = 2;
            this.toolSplitterAdj.TabStop = false;
            // 
            // toolMerger
            // 
            this.toolMerger.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.toolMerger.Image = ((System.Drawing.Image)(resources.GetObject("toolMerger.Image")));
            this.toolMerger.Location = new System.Drawing.Point(82, 243);
            this.toolMerger.Name = "toolMerger";
            this.toolMerger.Size = new System.Drawing.Size(46, 43);
            this.toolMerger.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.toolMerger.TabIndex = 1;
            this.toolMerger.TabStop = false;
            // 
            // toolEdit
            // 
            this.toolEdit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.toolEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolEdit.Image")));
            this.toolEdit.Location = new System.Drawing.Point(11, 47);
            this.toolEdit.Name = "toolEdit";
            this.toolEdit.Size = new System.Drawing.Size(46, 43);
            this.toolEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.toolEdit.TabIndex = 0;
            this.toolEdit.TabStop = false;
            this.toolEdit.Click += new System.EventHandler(this.toolEdit_Click);
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // grid
            // 
            this.grid.Location = new System.Drawing.Point(147, 24);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(802, 627);
            this.grid.TabIndex = 2;
            this.grid.TabStop = false;
            this.grid.Click += new System.EventHandler(this.grid_Click);
            this.grid.DragEnter += new System.Windows.Forms.DragEventHandler(this.grid_DragEnter);
            this.grid.Paint += new System.Windows.Forms.PaintEventHandler(this.grid_Paint);
            this.grid.MouseLeave += new System.EventHandler(this.grid_MouseLeave);
            this.grid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grid_MouseMove);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(600, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(949, 648);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Flowly - flow system / (New grid)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolSink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolSplitter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolPipe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolPump)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolSplitterAdj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolMerger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveWithoutAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearGridToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox toolSink;
        private System.Windows.Forms.PictureBox toolSplitter;
        private System.Windows.Forms.PictureBox toolPipe;
        private System.Windows.Forms.PictureBox toolRemove;
        private System.Windows.Forms.PictureBox toolPump;
        private System.Windows.Forms.PictureBox toolSplitterAdj;
        private System.Windows.Forms.PictureBox toolMerger;
        private System.Windows.Forms.PictureBox toolEdit;
        private System.Diagnostics.Process process1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox grid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem closeGridToolStripMenuItem;
    }
}

