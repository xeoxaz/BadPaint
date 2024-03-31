using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BadPaint
{
    public partial class frmBadPaint : Form
    {
        public Graphics graphics;
        public Pen pen1;
        public Pen pen2;
        public Pen currentPen;
        public int cursorX, cursorY = -1;
        public bool drawing = false;
        public int lineWidth = 5;
        public List<List<Color>> palettes;
        public List<PictureBox> paletteBoxes;
        public Bitmap imageBuffer;

        Options_Form of;

        public frmBadPaint() // <-- Console code
        {
            //
            // Please do not put form code inside console code.
            // --> Windows objects like "Forms" must be loaded first.
            //
            InitializeComponent();

            // form_Load();
        }

        private void pnlCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            drawing = true;

            if (e.Button == MouseButtons.Right)
            {
                currentPen = pen2;
            }
            else
            {
                currentPen = pen1;
            }

            cursorX = e.X;
            cursorY = e.Y;
        }

        private void pnlCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
            cursorX = 0;
            cursorY = 0;
        }

        private void pnlCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (cursorX != 0 && cursorY != 0 && drawing)
            {
                graphics.DrawLine(currentPen, new Point(cursorX, cursorY), e.Location);
                cursorX = e.X;
                cursorY = e.Y;
                Graphics pnlgfx = pnlCanvas.CreateGraphics();
                pnlgfx.DrawImage(imageBuffer, 0, 0);
                pnlgfx.Dispose();
            }
        }

        private void frmBadPaint_Load(object sender, EventArgs e)
        {
            of = new Options_Form(this, pnlCanvas);

            
            imageBuffer = new Bitmap(pnlCanvas.Width, pnlCanvas.Height);
            graphics = Graphics.FromImage(imageBuffer);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            pen1 = new Pen(Color.Black, lineWidth);
            pen1.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen1.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            pen2 = new Pen(Color.White, lineWidth);
            pen2.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen2.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            palettes = new List<List<Color>>();
            of.addPalettes();
            int count = 0;
            foreach (List<Color> pal in palettes)
            {
                count += pal.Count;
            }
        }
        private void pnlCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(imageBuffer, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            of.Show();
        }
    }
}
