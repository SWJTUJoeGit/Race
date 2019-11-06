using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DanielLewis.DrawingPrimitives.Core
{
    public class PrimitiveDrawer
    {

        //private readonly Bitmap _drawingArea;

        public Bitmap Bitmap { get; private set; }

        public PrimitiveDrawer(Bitmap drawingArea)
        {
            Bitmap = drawingArea;
        }

        public void DrawVerticalLine(int startX, int startY, int length, Color color)
        {
            for (int i = 0; i < length; i++)
            {
                Bitmap.SetPixel(startX, startY + i, color);
            }
        }

        public void DrawHorizontalLine(int startX, int startY, int length, Color color)
        {
            for (int i = 0; i < length; i++)
            {
                Bitmap.SetPixel(startX + i, startY, color);
            }
        }

        public void DrawSquareWithLines(int startX, int startY, int length, Color color)
        {
            // Draw the top line of the square
            DrawHorizontalLine(startX, startY, length, color);

            // Draw the right  line of the square
            DrawVerticalLine(startX, startY, length, color);

            // Draw the bottom line of the square
            DrawHorizontalLine(startX, startY + length, length, color);

            // Draw the Left line of the square
            DrawVerticalLine(startX + length, startY, length, color);
        }

        /// <summary>
        /// Draws a square to the Bitmap object using a Raster-style scan algorithm
        /// Certainly sub-optimal, but shows one technique to "check" each pixel
        /// before it is renderd
        /// </summary>
        /// <param name="startX">The X position of the top corner of the square</param>
        /// <param name="startY">The Y Position of the top corner of the square</param>
        /// <param name="length">The length of the square in pixels</param>
        /// <param name="color">The color of the square</param>
        public void DrawSquare(int startX, int startY, int length, Color color)
        {
            for (int y = 0; y < Bitmap.Height; y++)
            {
                for (int x = 0; x < Bitmap.Width; x++)
                {
                    // draws the top line
                    if (x >= startX && x <= startX + length && y == startY)
                    {
                        Bitmap.SetPixel(x, y, color);
                    }

                    // draws the left line
                    if (x == startX && y >= startY && y <= startY + length)
                    {
                        Bitmap.SetPixel(x, y, color);
                    }

                    // draws the right line
                    if (x == startX + length && y >= startY && y <= startY + length)
                    {
                        Bitmap.SetPixel(x, y, color);
                    }

                    // draws the bottom line
                    if (x >= startX && x <= startX + length && y == startY + length)
                    {
                        Bitmap.SetPixel(x, y, color);
                    }
                }
            }
        }

        public void IteratePixels()
        {
            Debug.WriteLine("Starting...");
            for (int y = 0; y < Bitmap.Height; y++)
            {
                for (int x = 0; x < Bitmap.Width; x++)
                {
                    Debug.WriteLine("At X = {0}, Y = {1}", x, y);
                }
            }
            Debug.WriteLine("Finished.");
        }
    }
}
