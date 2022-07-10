using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Be.IO;
using System.Diagnostics;


namespace saft
{
    public partial class MainMenu : Form
    {
        private SFT sftData;
        private SFTEntry currentlyEditedEntry;
        private string currentStreamDir = "Streams";
        private string lastSavePath = "yes.sft";
        //private SFTEntry[] afcFileData;

        private void MainMenu_Load(object sender, EventArgs e)
        {
            if (Program.argsProvided)
            {
                currentStreamDir = Program.streamFolder;
                loadSFT(Program.inFile);
            }

        }



        private void loadSFT(string file)
        {
            var fData = File.OpenRead(file);
            var w = new BeBinaryReader(fData);
            sftData = new SFT();
            sftData.readStream(w);
            lastSavePath = file;
            rebuildSFTList();
            fData.Close();
        }

        private void rebuildSelected()
        {
            lblLoop.Text = $"Loop: {currentlyEditedEntry.loop}";
            lblSamples.Text = $"Samples: {currentlyEditedEntry.sampleCount:X8}";
            lblSize.Text = $"Size: {currentlyEditedEntry.size:X8}";
            lblLoopPoint.Text = $"Loop Point: {currentlyEditedEntry.loopStart:X8}";
            ControlGroup.Enabled = true;
        }
        private void rebuildSFTList()
        {
            soundList.Items.Clear();
            if (sftData == null)
                return;
            for (int i = 0; i < sftData.entries.Length; i++)
                soundList.Items.Add(sftData.entries[i].name);
        }

        public MainMenu()
        {
            InitializeComponent();
        }


      
        private void saveSTMSFTToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (sftData==null)
            {
                MessageBox.Show("No SFT is opened to save.");
                return;
            }
            var fl = File.OpenWrite(lastSavePath);
            var writer = new BeBinaryWriter(fl);
            sftData.writeStream(writer);
            writer.Flush();
            writer.Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sftData == null)
            {
                MessageBox.Show("No SFT is opened to save.");
                return;
            }
            var fDialog = new SaveFileDialog();
            fDialog.Filter = "SFT Files|*.sft|All Files|*.*";
            if (fDialog.ShowDialog() == DialogResult.Cancel)
                return;
            lastSavePath = fDialog.FileName;
            fDialog.Dispose();

            var fl = File.Open(lastSavePath,FileMode.Open,FileAccess.ReadWrite);
            var writer = new BeBinaryWriter(fl);
            sftData.writeStream(writer);
            writer.Flush();
            writer.Close();
        }

        private void deleteFile_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("You're sure you want to do this?\n\nThis will shift all of the entries in front of it by 1.\nYou will have to remake your sound table, and change all of your custom sound ID's in your ASM.\nIf this is the last entry in the list. Don't worry about it. ", "Hold up!", MessageBoxButtons.OKCancel)==DialogResult.Cancel)
            {
                MessageBox.Show("Thought so.");
                return;
            }
            if (currentlyEditedEntry != null)
                removeFromSFT(currentlyEditedEntry);
            else
                MessageBox.Show("Nothing selected to delete!");
            rebuildSFTList();
        }

        private void openSTMSFTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fDialog = new OpenFileDialog();
            fDialog.Filter = "StreamFileTable Files|*.sft;*.stm;*.str|All Files|*.*";
            if (fDialog.ShowDialog() == DialogResult.Cancel)
                return;
            loadSFT(fDialog.FileName);
            fDialog.Dispose();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void removeFromSFT(SFTEntry entry)
        {
            for (int i = 0; i < sftData.entries.Length; i++)
                if (entry == sftData.entries[i])
                    sftData.entries[i] = null;

            var newSFT = new SFTEntry[sftData.entries.Length - 1];
            var idx = 0; 
            for (int i = 0; i < sftData.entries.Length; i++)
            {
                if (sftData.entries[i]!=null)
                {
                    newSFT[idx] = sftData.entries[i];
                    idx++;
                }
            }
            sftData.entries = newSFT;
        }

        private void addToSFT(SFTEntry entry)
        {
            Array.Resize(ref sftData.entries, sftData.entries.Length + 1);
            sftData.entries[sftData.entries.Length - 1] = entry;
            rebuildSFTList();           
        }

        private void checkAndExtendAFC(Stream handle, SFTEntry data)
        {
            if ( (handle.Length - data.size ) < 256 )
            {
                if (MessageBox.Show( "AFC file doesn't have any padding at the end\n\nThe game you're trying to play this on will very likely crash without this.\n\nDo you want to add this automatically?", "Warning" ,MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    var oldPos = handle.Position;
                    handle.Position = handle.Length;
                    handle.Write(new byte[0xFF], 0, 0xFF);
                    handle.Position = oldPos;
                    handle.Flush();
                }
            }
        }

        private void addFile_Click(object sender, EventArgs e)
        {
            var fDialog = new OpenFileDialog();
            fDialog.Filter = "AFC Files|*.afc|All Files|*.*";
            if (fDialog.ShowDialog() == DialogResult.Cancel)
                return;
            var fileName = fDialog.FileName;
            fDialog.Dispose();
            var wl1 = File.Open(fileName,FileMode.Open,FileAccess.ReadWrite);
            var reader = new BeBinaryReader(wl1);
            var header = new SFTEntry();
            header.readStream(reader, true);
            checkAndExtendAFC(wl1, header);
            wl1.Close();
            var fileNamePrompt = new FileNamePrompt();
            if (fileNamePrompt.ShowDialog() == DialogResult.Cancel)
                return;
            header.name = fileNamePrompt.FileText;
            fileNamePrompt.Dispose();
            File.Copy(fileName, $"{currentStreamDir}/{header.name}", true);
            addToSFT(header);
        }

        private void soundList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sftData == null)
                return;
            if (soundList.SelectedIndex > sftData.entries.Length -1 || soundList.SelectedIndex==-1)
                return;
           //Debug.WriteLine($"{soundList.SelectedIndex} vs {sftData.entries.Length}, who would in?");
            currentlyEditedEntry = sftData.entries[soundList.SelectedIndex];
            rebuildSelected();
        }

        private void btnReplaceAFC_Click(object sender, EventArgs e)
        {
            var fDialog = new OpenFileDialog();
            fDialog.Filter = "AFC Files|*.afc|All Files|*.*";
            if (fDialog.ShowDialog() == DialogResult.Cancel)
                return;
            var fileName = fDialog.FileName;
            fDialog.Dispose();
            var wl1 = File.Open(fileName, FileMode.Open, FileAccess.ReadWrite);
            var reader = new BeBinaryReader(wl1);
            var header = new SFTEntry();
            header.readStream(reader, true);
            checkAndExtendAFC(wl1, header);
            wl1.Close();
            Debug.WriteLine($"{currentStreamDir}/{currentlyEditedEntry.name}");
            Debug.WriteLine("================");
            Debug.WriteLine(fileName);

            File.Copy(fileName, $"{currentStreamDir}/{currentlyEditedEntry.name}", true);
            currentlyEditedEntry.loop = header.loop;
            currentlyEditedEntry.loopStart = header.loopStart;
            currentlyEditedEntry.format = header.format;
            currentlyEditedEntry.frameRate = header.frameRate;
            currentlyEditedEntry.sampleCount = header.sampleCount;
            currentlyEditedEntry.sampleRate = header.sampleRate;
            currentlyEditedEntry.size = header.size;
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ControlGroup_Enter(object sender, EventArgs e)
        {

        }
    }
}
