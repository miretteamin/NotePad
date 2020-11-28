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

namespace NotePad
{
    public partial class File : Form
    {
        public File()
        {
            InitializeComponent();
        }

        string fname="";
        StreamWriter s=null;
        private System.Drawing.Printing.PrintDocument dp = new System.Drawing.Printing.PrintDocument();

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.Undo();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.Cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TextBox.Text != "")
            {
                TextBox.Text = "";
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.SelectAll();
        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.Text += DateTime.Now.ToString();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            TextBox.Find(TextBox.SelectedText);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TextBox.Text != "")
            {
                DialogResult click = MessageBox.Show("The text in the Untitled has changed.\n\n Do you want to save the changes?", " My Notepad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                if (click == DialogResult.Yes)
                {
                    if (fname == "")
                    {
                        saveFileDialog1.Filter = "Text Files|*.txt";
                        DialogResult result = saveFileDialog1.ShowDialog();
                        if (result == DialogResult.Cancel)
                        {
                            return;
                        }
                        fname = saveFileDialog1.FileName;
                    }

                    StreamWriter write = new StreamWriter(fname);
                    write.WriteLine(TextBox.Text);
                    write.Flush();
                    write.Close();

                    TextBox.Text = "";
                    fname = "";
                }
                else if (click == DialogResult.No)
                {
                    TextBox.Text = "";
                    fname = "";
                }
            }
            else
            {
                TextBox.Text = "";
                fname = "";
            }
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusBarToolStripMenuItem.Checked==true)
            {
                statusStrip1.Hide();
                statusBarToolStripMenuItem.Checked = false;
            }
            else  if (statusBarToolStripMenuItem.Checked == false)
            {
                statusStrip1.Show();
                statusBarToolStripMenuItem.Checked = true;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FontDialog fdlg = new FontDialog();
            fdlg.ShowColor = true;

            if (fdlg.ShowDialog()==DialogResult.OK)
            {
                TextBox.SelectionFont = fdlg.Font;
                TextBox.SelectionColor = fdlg.Color;
            }
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (TextBox.Text != "")
            {
                DialogResult click = MessageBox.Show("The text in the Untitled has changed.\n\n Do you want to save the changes?", " My Notepad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                if (click == DialogResult.Yes)
                {
                    if (fname == "")
                    {
                        saveFileDialog1.Filter = "Text Files|*.txt";
                        DialogResult result = saveFileDialog1.ShowDialog();
                        if (result == DialogResult.Cancel)
                        {
                            return;
                        }
                        fname = saveFileDialog1.FileName;
                    }

                    StreamWriter write = new StreamWriter(fname);
                    write.WriteLine(TextBox.Text);
                    write.Flush();
                    write.Close();
                }
                else if (click == DialogResult.No)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fname == "")
            {
                saveFileDialog1.Filter = "Text Files|*.txt";
                DialogResult result = saveFileDialog1.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                try
                {
                    fname = saveFileDialog1.FileName;
                    s = new StreamWriter(fname);
                    s.WriteLine(TextBox.Text);
                    s.Flush();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                finally
                {
                    s.Close();
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            try
            {
                DialogResult result = openFileDialog1.ShowDialog();
                if (result==DialogResult.OK)
                {
                    string str = openFileDialog1.FileName;
                    FileStream fs=new FileStream(str , FileMode.Open, FileAccess.ReadWrite);
                    StreamReader sr = new StreamReader(fs);
                    TextBox.Text = sr.ReadToEnd();
                    fs.Close();
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (fname!=null)
            {

            }
            else
            {

            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dp = printDialog1.Document;
                DialogResult result = printDialog1.ShowDialog();
                if (result==DialogResult.OK)
                {
                    dp.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error");
            }
            
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Len : " + TextBox.TextLength;
            toolStripStatusLabel2.Text = "Line : " + TextBox.Lines.Count();
        }
    }
}
