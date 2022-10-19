using DAM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters
{
    internal class PaintUtils
    {
        public static void FillRectangle(Image image, RGBA color, int width, int height, int x, int y)
        {
            for (int i = x; i < x + width; i++)
            {
                for (int j = y; j < y + height; j++)
                {
                    image.SetPixel(i, j, color);
                }
            }
        }
    }
}
