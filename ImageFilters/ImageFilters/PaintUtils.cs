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

        public static void GreyscaleFilter(Image image)
        {
            for(int i = 0; i < image.Width; i++)
            {
                for(int j = 0; j < image.Height; j++)
                {
                    RGBA color = ColorToGrayScale(image.GetPixelAt(i,j));
                    image.SetPixel(i, j, color);
                }
            }
        }
        
        public static void MultiplyColorsFilter(Image img, RGBA inputColor)
        {
            for(int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    RGBA outputColor = MultiplyColors(img.GetPixelAt(i,j), inputColor);

                    img.SetPixel(i, j, outputColor);
                }
            }
        }

        public static Image FlipImageFilter(Image inputImg)
        {
            Image outputImg = new Image();
            outputImg.Config(inputImg.Width, inputImg.Height);

            for (int i = 0; i < outputImg.Width; i++)
            {
                for(int j = 0; j < outputImg.Height; j++)
                {
                    RGBA currentPixel = inputImg.GetPixelAt(i,j);
                    outputImg.SetPixel(i, outputImg.Height - j, currentPixel);
                }
            }
            return outputImg;
        }

        public static RGBA MultiplyColors(RGBA c1, RGBA c2)
        {
            RGBA output = new RGBA();
            output.r = c1.r * c2.r;
            output.g = c1.b * c2.g;
            output.b = c1.b * c2.b;
            output.a = c1.a * c2.a;

            return output;
        }

        public static RGBA ColorToGrayScale(RGBA color)
        {
            double tone = GetAverage(color.r, color.b, color.g);

            return new RGBA(tone, tone, tone, 1);
        }

        public static double GetAverage(double a, double b, double c)
        {
            return (a + b + c) / 3;
        }
    }
}
