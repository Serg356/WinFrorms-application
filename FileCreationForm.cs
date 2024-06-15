using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach
{
    public partial class FileCreationForm : Form
    {
        public FileCreationForm()
        {
            InitializeComponent();
        }




        public string filePath;
        private void button1_Click(object sender, EventArgs e)
        {
            if (fileNameTextBox.Text.Length == 0 || pathTextBox.Text.Length == 0)
            {
                MessageBox.Show("Не все поля заполненны");
                return;
            }
            filePath = pathTextBox.Text + @"\" + fileNameTextBox.Text;
            if (!pathTextBox.Text.EndsWith(".txt"))
            {
                filePath += ".txt";
            }
            try
            {
                File.Create(filePath).Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void pathChangeButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                pathTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
