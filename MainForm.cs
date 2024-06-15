using Microsoft.SolverFoundation.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
namespace Kursach
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            stateIndicator.Visible = false;
            /*System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 2000;
            var splashScreen = new SplashScreen();
            Opacity = 0;
            splashScreen.Show();
            timer.Tick += new EventHandler((s, ev) =>
            {
                splashScreen.Close();
                timer.Dispose();
                Opacity += 1;
                InitializeComponent();

            });
            timer.Start();*/
        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        public void showArithmeticCodingForm()
        {
            var charCounts = new Dictionary<char, int>();
            var br = new BinaryReader(openFileDialog1.OpenFile());
            var code = br.ReadDouble(); 
            int textLength = br.ReadInt32();
            while (br.BaseStream.Position != br.BaseStream.Length)
            {
                charCounts.Add(br.ReadChar(), br.ReadInt32());
            }
            var segments = ArithmeticCoding.ArithmeticCoding.defineSegments(ArithmeticCoding.ArithmeticCoding.createCharFreq(charCounts));
            string text = ArithmeticCoding.ArithmeticCoding.decode(segments, code, textLength);
            var form = new ArithmeticCodingForm();
            form.inputText = text;
            form.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FileCreationForm form = new FileCreationForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                openFile(form.filePath);
                
            }
        }

        private void openFile(string newPath)
        {
            if (file != null && file.FullName != newPath &&
                    MessageBox.Show("Текущий файл будет закрыт. Сохранить его?",
                    "Сообщение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                сщхранитьToolStripMenuItem_Click(null, null);
            }
            FileStream f;
            try
            {
                file = new FileInfo(newPath);
                f = File.Open(file.FullName, FileMode.OpenOrCreate);
                f.Close();

            }
            catch (Exception ex)
            {
                return;
            }
            if (file.Extension == ".arch")
            {
                showArithmeticCodingForm();
                return;
            }
            StreamReader sr = new StreamReader(file.FullName);
            try
            {
                richTextBox1.Text = sr.ReadToEnd();
                label1.Text = file.Name;
                richTextBox1.Visible = true;
            }
            catch (System.UnauthorizedAccessException)
            {
                MessageBox.Show("Невозможно открыть файл. Отказано в доступе");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //operationStateLabel.Text = "Файл успешно открыт";
                setState("Файл успешно открыт");
                сщхранитьToolStripMenuItem.Enabled = true;
                закодироватьToolStripMenuItem.Enabled = true;
            }
            sr.Close();
        }
        private void setState(string state, int textVisibleTime = 1000)
        {
            Timer timer = new Timer();
            timer.Interval = textVisibleTime;
            stateIndicator.Text = state;
            stateIndicator.Visible = true;
            //pictureBox1.Visible = true;
            timer.Tick += new EventHandler((s, e) => { stateIndicator.Visible = false; ; timer.Stop(); });
            timer.Start();
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFile(openFileDialog1.FileName);

            }
        }
        private FileInfo file = null;

        private void сщхранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sw = new StreamWriter(file.FullName);
            try
            {
                sw.Write(richTextBox1.Text);
            }
            catch (System.UnauthorizedAccessException) {
                MessageBox.Show("Невозможно открыть файл. Отказано в доступе");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //operationStateLabel.Text = "Файл успешно сохранён";
                setState("Файл успешно сохранён");
            }
            sw.Close();
            
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S) && сщхранитьToolStripMenuItem.Enabled)
            {
                сщхранитьToolStripMenuItem_Click(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void stateIndicator_Click(object sender, EventArgs e)
        {

        }

        private void арифметическогоКодированияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ArithmeticCodingForm();
            form.inputText = richTextBox1.Text;
            form.ShowDialog();

        }
    }
}
