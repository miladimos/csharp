using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace notepad
{
    public partial class frmMain : Form
    {
        private bool fileAlreadySaved;
        private bool fileUpdated;
        private string currentFileName;
        private string formTitle;

        public frmMain()
        {
            InitializeComponent();


        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            fileAlreadySaved = false;
            fileUpdated = false;
            currentFileName = null;



        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxMain.Clear();
        }

        private void newWidnowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMain newWindow = new frmMain();
            newWindow.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Open";
            fileDialog.Multiselect = false;
            fileDialog.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(fileDialog.FileName) == ".txt")
                {
                    richTextBoxMain.LoadFile(fileDialog.FileName, RichTextBoxStreamType.PlainText);
                    this.Text = Path.GetFileName(fileDialog.FileName);
                }
                else if (Path.GetExtension(fileDialog.FileName) == ".rtf")
                {
                    richTextBoxMain.LoadFile(fileDialog.FileName, RichTextBoxStreamType.RichText);
                    this.Text = Path.GetFileName(fileDialog.FileName);
                }
                else
                {
                    this.Text = "Selected File is not text file";
                }

                fileAlreadySaved = true;
                fileUpdated = false;
                currentFileName = fileDialog.FileName;
                formTitle = "";

            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty("") && fileAlreadySaved)
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Title = "Save";
                fileDialog.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBoxMain.SaveFile(fileDialog.FileName, RichTextBoxStreamType.PlainText);
                    this.Text = fileDialog.FileName;
                }
            }
            else
            {
                richTextBoxMain.SaveFile("");
            }

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "Save As";
            fileDialog.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBoxMain.SaveFile(fileDialog.FileName, RichTextBoxStreamType.PlainText);
                this.Text = fileDialog.FileName;
            }

            fileAlreadySaved = true;
            fileUpdated = false;
            currentFileName = fileDialog.FileName;
            formTitle = "";
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.ShowDialog();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxMain.Undo();
        }


        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxMain.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxMain.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxMain.Copy();

        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxMain.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void searchWithBingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void findPreviousToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gotoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxMain.SelectAll();

        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime nowDateTime = DateTime.Now;
            richTextBoxMain.SelectedText = nowDateTime.ToString();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = richTextBoxMain.Font;
            DialogResult dialogResult = fontDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                richTextBoxMain.Font = fontDialog.Font;
            }
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapToolStripMenuItem.Checked == true)
            {
                wordWrapToolStripMenuItem.Checked = false;
                richTextBoxMain.WordWrap = false;
            }
            else
            {
                wordWrapToolStripMenuItem.Checked = true;

                richTextBoxMain.WordWrap = true;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBoxMain.ForeColor = colorDialog.Color;
            }
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBoxMain.BackColor = colorDialog.Color;
            }
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusBarToolStripMenuItem.Checked == true)
            {
                statusBarToolStripMenuItem.Checked = false;
                statusStripMain.Visible = false;
            }
            else
            {
                statusBarToolStripMenuItem.Checked = true;
                statusStripMain.Visible = true;
            }
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void restorDefaultZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sendFeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void richTextBoxMain_TextChanged(object sender, EventArgs e)
        {
            fileUpdated = true;
        }
    }
}
