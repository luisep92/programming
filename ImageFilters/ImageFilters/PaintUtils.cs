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

        public static Image RotateHue(Image img, double hueInc)
        {
            Image outputImg = new Image();
            outputImg.Config(img.Width, img.Height);

            for(int i = 0; i < outputImg.Width; i++)
            {
                for(int j = 0; j < outputImg.Height; j++)
                {
                    RGBA rgbColor = img.GetPixelAt(i, j);
                    HSLA hslColor = rgbColor.ToHSL();
                    hslColor.h += hueInc;
                    hslColor.h = Circular(hslColor.h, 0, 1);
                    rgbColor = hslColor.ToRGBA();
                    outputImg.SetPixel(i, j, rgbColor);
                }
            }
            return outputImg;
        }
        public static Image RotateSelectedHue(Image img, double hueInc, double minVal, double maxVal)
        {
            Image outputImg = new Image();
            outputImg.Config(img.Width, img.Height);

            for (int i = 0; i < outputImg.Width; i++)
            {
                for (int j = 0; j < outputImg.Height; j++)
                {
                    RGBA rgbColor = img.GetPixelAt(i, j);
                    HSLA hslColor = rgbColor.ToHSL();

                    if(hslColor.h > minVal && hslColor.h < maxVal)
                    {
                        hslColor.h += hueInc;
                        hslColor.h = Circular(hslColor.h, 0, 1);
                        rgbColor = hslColor.ToRGBA();
                        outputImg.SetPixel(i, j, rgbColor);
                    }
                    
                }
            }
            return outputImg;
        }

        public static Image Discretize(Image img, double hueMin, double hueMax)
        {
            Image outputImg = new Image();
            outputImg.Config(img.Width, img.Height);

            for (int i = 0; i < outputImg.Width; i++)
            {
                for (int j = 0; j < outputImg.Height; j++)
                {
                    RGBA rgbColor = img.GetPixelAt(i, j);
                    HSLA hslColor = rgbColor.ToHSL();

                    if (hslColor.h > hueMin && hslColor.h < hueMax)
                        hslColor.l = 1;
                    else
                        hslColor.l = 0;

                    rgbColor = hslColor.ToRGBA();
                    outputImg.SetPixel(i, j, rgbColor);
                }
            }
            return outputImg;
        }

        public static Image Blur(Image inputImg)
        {
            Image outputImg = new Image();
            outputImg.Config(inputImg.Width,inputImg.Height);

            for(int i = 0; i < inputImg.Width; i++)
            {
                for(int j = 0; j < inputImg.Height; j++)
                {
                    RGBA color = AverageColor(inputImg, i, j);
                    outputImg.SetPixel(i, j, color);
                }
            }
            return outputImg;
        }

        public static RGBA AverageColor(Image img, int x, int y)
        {
           
            RGBA avgColor = new RGBA(0,0,0,0);


            for(int i = x - 1; i <= x+1; i++)
            {
                for(int j = y- 1; j <= y+1; j++)
                {
                    avgColor = SumColors(avgColor, img.GetPixelAt(i, j));
                }
            }
            
            return DivideColor(avgColor,9);
        }

        public static double Circular(double n, double min, double max)
        {
            double range = max - min;

            if (n > max)
                return Circular(n - range, min, max);
            if (n < min)
                return Circular(n + range, min, max);
            return n;
        }

        public static double Circular2(double n, double min, double max)
        {
            double range = max - min;

            while (n < min)
            {
                n += range;
            }
            while (n > max)
            {
                n -= range;
            }
            return n;
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

        public static RGBA SumColors(RGBA c1, RGBA c2)
        {
            RGBA color = new RGBA();
            color.r = c1.r + c2.r;
            color.g = c1.g + c2.g;
            color.b = c1.b + c2.b;
            color.a = c1.a + c2.a;
            return color;
        }

        public static RGBA DivideColor(RGBA color, double value)
        {
            color.r /= value;
            color.g /= value;
            color.b /= value;
            color.a /= value;
            return color;
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
