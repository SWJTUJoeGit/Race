using DanielLewis.DrawingPrimitives.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DrawingPrimitives
{
    public partial class MainForm : Form
    {

        private PrimitiveDrawer _drawer;


        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var drawingArea = new Bitmap(this.ClientRectangle.Width,
                this.ClientRectangle.Height,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            _drawer = new PrimitiveDrawer(drawingArea);

            _drawer.DrawSquareWithLines(10,10,120, Color.Red);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(_drawer.Bitmap, 0, 0, _drawer.Bitmap.Width, _drawer.Bitmap.Height);
        }
    }
}
