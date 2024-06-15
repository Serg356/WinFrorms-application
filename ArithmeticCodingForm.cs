using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArithmeticCoding;
using Microsoft.SolverFoundation.Common;
namespace Kursach
{
    public partial class ArithmeticCodingForm : Form
    {
        public string inputText;
        private Graphics g;
        private Graphics g_test;
        private float lineLengh;
        private double code;
        private SegmentLine line;
        public ArithmeticCodingForm()
        {
            InitializeComponent();
            g = splitContainer1.Panel1.CreateGraphics();

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            //draw();

        }
        private void draw()
        {

            if (g == null)
            {
                return;
            }
            g.Clear(BackColor);
            g = drawingPanel.CreateGraphics();
            line.draw(g, (float)code, ArithmeticCoding.ArithmeticCoding.segments);


        }
        //private void draw()
        //{

        //    if (g == null)
        //    {
        //        return;
        //    }
        //    var panel = splitContainer1.Panel1;
        //    g = panel.CreateGraphics();
        //    //g.DrawRectangle(new Pen(Color.Green, Width * 0.005f), g.VisibleClipBounds.X, g.VisibleClipBounds.Y, g.VisibleClipBounds.Width, g.VisibleClipBounds.Height);
        //    var lineWidth = 0.005f * panel.Width;
        //    //g.DrawLine(new Pen(Color.Black, lineWidth), 0, 0, panel.Width, panel.Height);
        //    var start = new PointF(panel.Width * 0.3f, panel.Height * 0.1f);
        //    var end = new PointF(start.X + panel.Width * 0.3f, start.Y);
        //    var length = end.X - start.X;
        //    g.DrawLine(new Pen(Color.Black, lineWidth), start, end);
        //    float coord = length * (float)code + start.X;
        //    g.DrawLine(new Pen(Color.Cyan, lineWidth), coord, start.Y, coord, start.Y + 0.1f * length);
        //    g.DrawString(code.ToString("0.##"), new Font(panel.Font.FontFamily, 13), new SolidBrush(panel.ForeColor), coord - 22, start.Y + 0.1f*length);
        //    foreach (var pair in ArithmeticCoding.ArithmeticCoding.createCharFreq(ArithmeticCoding.ArithmeticCoding.charCounts))
        //    {
        //        var ch = pair.Key;
        //        var freq = pair.Value;
        //        float x = length * (float)freq + start.X;
        //        g.DrawLine(new Pen(Color.Black, lineWidth), x, start.Y, x, start.Y + 0.1f * length);
        //        //g.DrawString(freq.ToString("0.##"), new Font(panel.Font.FontFamily, 13), new SolidBrush(panel.ForeColor), x, start.Y + 0.1f);
        //    }


        //}
        public void ArithmeticCodingForm_Load(object sender, EventArgs e)
        {
            inputTextTextBox.Text = inputText;
            code = ArithmeticCoding.ArithmeticCoding.encode(inputText);
            if (code == -1) { MessageBox.Show("Файл cлишком большой", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); Close(); }
            //line = new SegmentLine(Width * 0.3f, Height * 0.1f, Width*0.3f, Color.Black);
            line = new SegmentLine(0, Height * 0.1f, Width * 0.3f, Color.Black);
            listBox1.Items.Clear();
            foreach (var pair in ArithmeticCoding.ArithmeticCoding.charCounts)
            {
                var c = pair.Key;
                var count = pair.Value;
                listBox1.Items.Add(c.ToString() +  ": " + count.ToString() + $"({ArithmeticCoding.ArithmeticCoding.charFreqs[c].ToString("0.##")})");
            }

        }

        private void ArithmeticCodingForm_Paint(object sender, PaintEventArgs e)
        {
            g_test = this.CreateGraphics();
            g_test.DrawLine(new Pen(Color.Black, Width * 0.005f), 0, 0, Width, Height);
        }

        private void increaseSizeButton_Click(object sender, EventArgs e)
        {
            line.zoom(1.5f);
            //linePanel.Width = (int)(line.X + line.Length) + 1;
            this.Refresh();

            draw();
        }

        private void decreaseSizeButton_Click(object sender, EventArgs e)
        {
            line.zoom(2f / 3f);
            this.Refresh();
            draw();
        }

        private void zoomPanel_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                //line.move(drawingPanel.AutoScrollPosition.X, drawingPanel.AutoScrollPosition.Y);
                line.move(e.OldValue - e.NewValue, 0);

            }
            else
            {
                line.move(0, e.OldValue - e.NewValue);
            }

        }

        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {
            drawingPanel.AutoScrollMinSize = new Size((int)(line.Length), drawingPanel.Height);
            draw();
            //g.TranslateTransform(drawingPanel.AutoScrollPosition.X, drawingPanel.AutoScrollPosition.Y);

        }

        private void drawingPanel_Resize(object sender, EventArgs e)
        {
            line.X = 0;
            line.Y = Height * 0.1f;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var f = new FileInfo(saveFileDialog1.FileName);
                if (f.Extension == ".txt")
                {
                    var sw = new StreamWriter(f.FullName);
                    sw.Write(inputText);
                    sw.Close();
                    return;
                }
                var bw = new BinaryWriter(saveFileDialog1.OpenFile());
                //if (code.Numerator > int.MaxValue || code.Denominator > int.MaxValue) { MessageBox.Show("ПЕреполнение"); }
                bw.Write(code);
                bw.Write(inputText.Length);
                foreach (var pair in ArithmeticCoding.ArithmeticCoding.charCounts)
                {
                    bw.Write(pair.Key);
                    bw.Write(pair.Value);
                }
               bw.Close();
               Close();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listBox = (ListBox)sender;
            if (listBox.SelectedItem == null) {  return; }
            var ch = listBox.SelectedItem.ToString()[0];
            line.SelectedSegment = ArithmeticCoding.ArithmeticCoding.segments[ch];
            draw();
            inputTextTextBox.Select(0, 1);
            inputTextTextBox.Select(2, 4);
        }

        private void cancleButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    class SegmentLine
    {
        public float X {  get; set; }
        public float Y { get; set; }
        public float Length { get; set; }
        public Color LineColor { get; set; }
        public Color SegmentStartColor { get; set; } = Color.Blue;
        public Color SegmentEndColor { get; set; } = Color.Red;
        public Color CodeColor { get; set; } = Color.YellowGreen;
        public Color SelectionColor { get; set; } = Color.Green;
        public Segment SelectedSegment { get; set; } = new Segment(-1, -1);
        //public float Width { get; set; } = 1.0f;
        public SegmentLine(float x, float y, float length, Color color)
        {
            X = x;
            Y = y;
            Length = length;
            LineColor = color;
        }
        //private void drawSegment(Graphics g, Segment seg)
        //{
        //    g.DrawLine(new Pen(SegmentStartColor, Length * 0.005f), X + Length * (float)seg.left, Y, X + Length * (float)seg.left, Y + 0.1f*Length);
        //    g.DrawLine(new Pen(SegmentEndColor, Length * 0.005f), X + Length * (float)seg.right, Y, X + Length * (float)seg.right, Y + 0.1f * Length);
        //}
        public void draw(Graphics g, float code, Dictionary<char, Segment> segments)
        {
            var color = SegmentEndColor;
            foreach (var pair in segments)
            {
                if (color == SegmentStartColor)
                {
                    color = SegmentEndColor;
                }
                else { color = SegmentStartColor; }
                char c = pair.Key;
                var seg = pair.Value;
                g.DrawLine(new Pen(color, Length * 0.005f), X + Length * (float)seg.left, Y, X + Length * (float)seg.left, Y + 0.1f * Length);

            }
            g.DrawLine(new Pen(CodeColor, Length * 0.005f), X + Length * code, Y, X + Length * code, Y + 0.1f * Length);
            g.DrawLine(new Pen(LineColor, Length * 0.005f), X, Y, X + Length, Y);
            if (SelectedSegment.left != -1)
            {
                g.DrawLine(new Pen(SelectionColor, Length * 0.005f), X + Length * (float)SelectedSegment.left, Y, X + Length * (float)SelectedSegment.right, Y);
            }
        }
        public void zoom(float zoom)
        {
            Length = Length * zoom;
        }
        public void move(float dx, float dy)
        {
            X += dx;
            Y += dy;
        }
    }
}
