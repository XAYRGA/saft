
namespace saft
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.logo = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSTMSFTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSTMSFTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soundList = new System.Windows.Forms.ListBox();
            this.addFile = new System.Windows.Forms.Button();
            this.ControlGroup = new System.Windows.Forms.GroupBox();
            this.lblLoopPoint = new System.Windows.Forms.Label();
            this.lblLoop = new System.Windows.Forms.Label();
            this.lblSamples = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.btnReplaceAFC = new System.Windows.Forms.Button();
            this.deleteFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.ControlGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Image = global::saft.Properties.Resources.saftlogo;
            this.logo.Location = new System.Drawing.Point(413, 12);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(90, 62);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 0;
            this.logo.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(503, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSTMSFTToolStripMenuItem,
            this.saveSTMSFTToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openSTMSFTToolStripMenuItem
            // 
            this.openSTMSFTToolStripMenuItem.Name = "openSTMSFTToolStripMenuItem";
            this.openSTMSFTToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openSTMSFTToolStripMenuItem.Text = "Open STM/SFT";
            this.openSTMSFTToolStripMenuItem.Click += new System.EventHandler(this.openSTMSFTToolStripMenuItem_Click);
            // 
            // saveSTMSFTToolStripMenuItem
            // 
            this.saveSTMSFTToolStripMenuItem.Name = "saveSTMSFTToolStripMenuItem";
            this.saveSTMSFTToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveSTMSFTToolStripMenuItem.Text = "Save";
            this.saveSTMSFTToolStripMenuItem.Click += new System.EventHandler(this.saveSTMSFTToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save As....";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // soundList
            // 
            this.soundList.FormattingEnabled = true;
            this.soundList.Location = new System.Drawing.Point(12, 27);
            this.soundList.Name = "soundList";
            this.soundList.Size = new System.Drawing.Size(217, 498);
            this.soundList.TabIndex = 2;
            this.soundList.SelectedIndexChanged += new System.EventHandler(this.soundList_SelectedIndexChanged);
            // 
            // addFile
            // 
            this.addFile.Location = new System.Drawing.Point(13, 532);
            this.addFile.Name = "addFile";
            this.addFile.Size = new System.Drawing.Size(216, 23);
            this.addFile.TabIndex = 3;
            this.addFile.Text = "Add new file";
            this.addFile.UseVisualStyleBackColor = true;
            this.addFile.Click += new System.EventHandler(this.addFile_Click);
            // 
            // ControlGroup
            // 
            this.ControlGroup.Controls.Add(this.lblLoopPoint);
            this.ControlGroup.Controls.Add(this.lblLoop);
            this.ControlGroup.Controls.Add(this.lblSamples);
            this.ControlGroup.Controls.Add(this.lblSize);
            this.ControlGroup.Controls.Add(this.btnReplaceAFC);
            this.ControlGroup.Enabled = false;
            this.ControlGroup.Location = new System.Drawing.Point(235, 80);
            this.ControlGroup.Name = "ControlGroup";
            this.ControlGroup.Size = new System.Drawing.Size(256, 508);
            this.ControlGroup.TabIndex = 5;
            this.ControlGroup.TabStop = false;
            this.ControlGroup.Text = "Operations";
            this.ControlGroup.Enter += new System.EventHandler(this.ControlGroup_Enter);
            // 
            // lblLoopPoint
            // 
            this.lblLoopPoint.AutoSize = true;
            this.lblLoopPoint.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoopPoint.Location = new System.Drawing.Point(41, 89);
            this.lblLoopPoint.Name = "lblLoopPoint";
            this.lblLoopPoint.Size = new System.Drawing.Size(207, 19);
            this.lblLoopPoint.TabIndex = 4;
            this.lblLoopPoint.Text = "Loop Point: 00000000";
            // 
            // lblLoop
            // 
            this.lblLoop.AutoSize = true;
            this.lblLoop.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoop.Location = new System.Drawing.Point(96, 70);
            this.lblLoop.Name = "lblLoop";
            this.lblLoop.Size = new System.Drawing.Size(111, 19);
            this.lblLoop.TabIndex = 3;
            this.lblLoop.Text = "Loop: False";
            // 
            // lblSamples
            // 
            this.lblSamples.AutoSize = true;
            this.lblSamples.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSamples.Location = new System.Drawing.Point(66, 51);
            this.lblSamples.Name = "lblSamples";
            this.lblSamples.Size = new System.Drawing.Size(182, 19);
            this.lblSamples.TabIndex = 2;
            this.lblSamples.Text = "Samples: 00000000";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.Location = new System.Drawing.Point(101, 32);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(147, 19);
            this.lblSize.TabIndex = 1;
            this.lblSize.Text = "Size: 00000000";
            // 
            // btnReplaceAFC
            // 
            this.btnReplaceAFC.Location = new System.Drawing.Point(6, 479);
            this.btnReplaceAFC.Name = "btnReplaceAFC";
            this.btnReplaceAFC.Size = new System.Drawing.Size(244, 23);
            this.btnReplaceAFC.TabIndex = 0;
            this.btnReplaceAFC.Text = "Replace File";
            this.btnReplaceAFC.UseVisualStyleBackColor = true;
            this.btnReplaceAFC.Click += new System.EventHandler(this.btnReplaceAFC_Click);
            // 
            // deleteFile
            // 
            this.deleteFile.Location = new System.Drawing.Point(13, 562);
            this.deleteFile.Name = "deleteFile";
            this.deleteFile.Size = new System.Drawing.Size(216, 23);
            this.deleteFile.TabIndex = 4;
            this.deleteFile.Text = "Delete Selected";
            this.deleteFile.UseVisualStyleBackColor = true;
            this.deleteFile.Click += new System.EventHandler(this.deleteFile_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 600);
            this.Controls.Add(this.ControlGroup);
            this.Controls.Add(this.deleteFile);
            this.Controls.Add(this.addFile);
            this.Controls.Add(this.soundList);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainMenu";
            this.Text = "SAFT";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ControlGroup.ResumeLayout(false);
            this.ControlGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSTMSFTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSTMSFTToolStripMenuItem;
        private System.Windows.Forms.ListBox soundList;
        private System.Windows.Forms.Button addFile;
        private System.Windows.Forms.GroupBox ControlGroup;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button deleteFile;
        private System.Windows.Forms.Button btnReplaceAFC;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.Label lblLoopPoint;
        private System.Windows.Forms.Label lblLoop;
        private System.Windows.Forms.Label lblSamples;
        private System.Windows.Forms.Label lblSize;
    }
}

