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
            this.buttonUndo = new System.Windows.Forms.Button();
            this.buttonGoTo = new System.Windows.Forms.Button();
            this.listBoxStates = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelRightTrack = new System.Windows.Forms.Label();
            this.labelLeftTrack = new System.Windows.Forms.Label();
            this.nudCapacity = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.nudFlow = new System.Windows.Forms.NumericUpDown();
            this.labelRight = new System.Windows.Forms.Label();
            this.labelLeft = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarLeft = new System.Windows.Forms.TrackBar();
            this.trackBarRight = new System.Windows.Forms.TrackBar();
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
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRight)).BeginInit();
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
            this.newToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.newToolStripMenuItem.Text = "New grid";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveWithoutAsToolStripMenuItem
            // 
            this.saveWithoutAsToolStripMenuItem.Name = "saveWithoutAsToolStripMenuItem";
            this.saveWithoutAsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.saveWithoutAsToolStripMenuItem.Text = "Save grid";
            this.saveWithoutAsToolStripMenuItem.Click += new System.EventHandler(this.saveWithoutAsToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.saveAsToolStripMenuItem.Text = "Save as grid";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem1_Click);
            // 
            // openFileStripMenuItem
            // 
            this.openFileStripMenuItem.Name = "openFileStripMenuItem";
            this.openFileStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.openFileStripMenuItem.Text = "Open grid";
            this.openFileStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // clearGridToolStripMenuItem
            // 
            this.clearGridToolStripMenuItem.Name = "clearGridToolStripMenuItem";
            this.clearGridToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.clearGridToolStripMenuItem.Text = "Clear grid";
            this.clearGridToolStripMenuItem.Click += new System.EventHandler(this.clearGridToolStripMenuItem_Click);
            // 
            // closeGridToolStripMenuItem
            // 
            this.closeGridToolStripMenuItem.Name = "closeGridToolStripMenuItem";
            this.closeGridToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.closeGridToolStripMenuItem.Text = "Close grid";
            this.closeGridToolStripMenuItem.Click += new System.EventHandler(this.closeGridToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PapayaWhip;
            this.groupBox1.Controls.Add(this.buttonUndo);
            this.groupBox1.Controls.Add(this.buttonGoTo);
            this.groupBox1.Controls.Add(this.listBoxStates);
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
            this.groupBox1.Size = new System.Drawing.Size(152, 652);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Toolbox";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // buttonUndo
            // 
            this.buttonUndo.Location = new System.Drawing.Point(11, 337);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(117, 23);
            this.buttonUndo.TabIndex = 17;
            this.buttonUndo.Text = "Undo ";
            this.buttonUndo.UseVisualStyleBackColor = true;
            this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
            // 
            // buttonGoTo
            // 
            this.buttonGoTo.Location = new System.Drawing.Point(11, 307);
            this.buttonGoTo.Name = "buttonGoTo";
            this.buttonGoTo.Size = new System.Drawing.Size(117, 23);
            this.buttonGoTo.TabIndex = 16;
            this.buttonGoTo.Text = "Go before change";
            this.buttonGoTo.UseVisualStyleBackColor = true;
            this.buttonGoTo.Click += new System.EventHandler(this.buttonGoTo_Click);
            // 
            // listBoxStates
            // 
            this.listBoxStates.FormattingEnabled = true;
            this.listBoxStates.Location = new System.Drawing.Point(11, 219);
            this.listBoxStates.Name = "listBoxStates";
            this.listBoxStates.Size = new System.Drawing.Size(123, 82);
            this.listBoxStates.TabIndex = 15;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelRightTrack);
            this.groupBox2.Controls.Add(this.labelLeftTrack);
            this.groupBox2.Controls.Add(this.nudCapacity);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.nudFlow);
            this.groupBox2.Controls.Add(this.labelRight);
            this.groupBox2.Controls.Add(this.labelLeft);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.trackBarLeft);
            this.groupBox2.Controls.Add(this.trackBarRight);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 366);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(152, 291);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Properties";
            // 
            // labelRightTrack
            // 
            this.labelRightTrack.AutoSize = true;
            this.labelRightTrack.Location = new System.Drawing.Point(79, 161);
            this.labelRightTrack.Name = "labelRightTrack";
            this.labelRightTrack.Size = new System.Drawing.Size(27, 13);
            this.labelRightTrack.TabIndex = 15;
            this.labelRightTrack.Text = "50%";
            // 
            // labelLeftTrack
            // 
            this.labelLeftTrack.AutoSize = true;
            this.labelLeftTrack.Location = new System.Drawing.Point(36, 161);
            this.labelLeftTrack.Name = "labelLeftTrack";
            this.labelLeftTrack.Size = new System.Drawing.Size(27, 13);
            this.labelLeftTrack.TabIndex = 14;
            this.labelLeftTrack.Text = "50%";
            // 
            // nudCapacity
            // 
            this.nudCapacity.DecimalPlaces = 1;
            this.nudCapacity.Enabled = false;
            this.nudCapacity.Location = new System.Drawing.Point(80, 86);
            this.nudCapacity.Maximum = new decimal(new int[] {
            2147483646,
            0,
            0,
            0});
            this.nudCapacity.Name = "nudCapacity";
            this.nudCapacity.Size = new System.Drawing.Size(54, 20);
            this.nudCapacity.TabIndex = 13;
            this.nudCapacity.ValueChanged += new System.EventHandler(this.nudCapacity_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Capacity";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(16, 256);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 23);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // nudFlow
            // 
            this.nudFlow.DecimalPlaces = 1;
            this.nudFlow.Enabled = false;
            this.nudFlow.Location = new System.Drawing.Point(80, 62);
            this.nudFlow.Maximum = new decimal(new int[] {
            2147483646,
            0,
            0,
            0});
            this.nudFlow.Name = "nudFlow";
            this.nudFlow.Size = new System.Drawing.Size(54, 20);
            this.nudFlow.TabIndex = 9;
            this.nudFlow.ValueChanged += new System.EventHandler(this.nudFlow_ValueChanged);
            // 
            // labelRight
            // 
            this.labelRight.AutoSize = true;
            this.labelRight.Location = new System.Drawing.Point(104, 234);
            this.labelRight.Name = "labelRight";
            this.labelRight.Size = new System.Drawing.Size(32, 13);
            this.labelRight.TabIndex = 2;
            this.labelRight.Text = "Right";
            // 
            // labelLeft
            // 
            this.labelLeft.AutoSize = true;
            this.labelLeft.Location = new System.Drawing.Point(13, 234);
            this.labelLeft.Name = "labelLeft";
            this.labelLeft.Size = new System.Drawing.Size(25, 13);
            this.labelLeft.TabIndex = 1;
            this.labelLeft.Text = "Left";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Flow";
            // 
            // trackBarLeft
            // 
            this.trackBarLeft.Enabled = false;
            this.trackBarLeft.Location = new System.Drawing.Point(6, 104);
            this.trackBarLeft.Maximum = 100;
            this.trackBarLeft.Name = "trackBarLeft";
            this.trackBarLeft.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarLeft.Size = new System.Drawing.Size(45, 127);
            this.trackBarLeft.TabIndex = 6;
            this.trackBarLeft.Value = 50;
            this.trackBarLeft.ValueChanged += new System.EventHandler(this.trackBarLeft_ValueChanged);
            // 
            // trackBarRight
            // 
            this.trackBarRight.Enabled = false;
            this.trackBarRight.Location = new System.Drawing.Point(107, 104);
            this.trackBarRight.Maximum = 100;
            this.trackBarRight.Name = "trackBarRight";
            this.trackBarRight.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarRight.Size = new System.Drawing.Size(45, 127);
            this.trackBarRight.TabIndex = 5;
            this.trackBarRight.Value = 50;
            this.trackBarRight.ValueChanged += new System.EventHandler(this.trackBarRight_ValueChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 51);
            this.label5.TabIndex = 8;
            this.label5.Text = "Component";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolSink
            // 
            this.toolSink.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.toolSink.Image = ((System.Drawing.Image)(resources.GetObject("toolSink.Image")));
            this.toolSink.Location = new System.Drawing.Point(82, 121);
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
            this.toolSplitter.Location = new System.Drawing.Point(11, 121);
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
            this.toolPipe.Location = new System.Drawing.Point(82, 72);
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
            this.toolRemove.Location = new System.Drawing.Point(80, 25);
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
            this.toolPump.Location = new System.Drawing.Point(11, 72);
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
            this.toolSplitterAdj.Location = new System.Drawing.Point(11, 170);
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
            this.toolMerger.Location = new System.Drawing.Point(82, 170);
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
            this.toolEdit.Location = new System.Drawing.Point(11, 25);
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
            this.grid.Size = new System.Drawing.Size(802, 652);
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
            this.ClientSize = new System.Drawing.Size(949, 680);
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
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRight)).EndInit();
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
        private System.Windows.Forms.NumericUpDown nudFlow;
        private System.Windows.Forms.Label labelRight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarRight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox grid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem closeGridToolStripMenuItem;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.NumericUpDown nudCapacity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelRightTrack;
        private System.Windows.Forms.Label labelLeftTrack;
        private System.Windows.Forms.Label labelLeft;
        private System.Windows.Forms.TrackBar trackBarLeft;
        private System.Windows.Forms.Button buttonGoTo;
        private System.Windows.Forms.ListBox listBoxStates;
        private System.Windows.Forms.Button buttonUndo;
    }
}

