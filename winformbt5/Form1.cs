using System;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace winformbt5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.Text = "Tahoma";
            toolStripComboBox2.Text = "14";
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                toolStripComboBox1.Items.Add(font.Name);
            }
            List<int> listSize = new List<int> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var s in listSize)
            {
                toolStripComboBox2.Items.Add(s);
            }
        }

        private void boldButton_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox.SelectionFont;
                System.Drawing.FontStyle newFontStyle = (richTextBox.SelectionFont.Bold) ? FontStyle.Regular : FontStyle.Bold;
                richTextBox.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void italicButton_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox.SelectionFont;
                System.Drawing.FontStyle newFontStyle = (richTextBox.SelectionFont.Italic) ? FontStyle.Regular : FontStyle.Italic;
                richTextBox.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void underlineButton_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox.SelectionFont;
                System.Drawing.FontStyle newFontStyle = (richTextBox.SelectionFont.Underline) ? FontStyle.Regular : FontStyle.Underline;
                richTextBox.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SelectionFont = fontDialog.Font;
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void OpenFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (Path.GetExtension(openFileDialog.FileName).ToLower() == ".rtf")
                    {
                        richTextBox.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.RichText);
                    }
                    else
                    {
                        richTextBox.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
                    }
                }
            }
        }

        private void SaveFile()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, richTextBox.Text);
                }
            }
        }
    }
}
