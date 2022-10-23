using DAM;

namespace ImageFilters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test3();
        }
        static void Test2()
        {
            string path = "C:\\Users\\Luis\\Desktop\\Images\\";

            Image img = new Image();
            img.Load(path +"pepe.jpg");
            PaintUtils.GreyscaleFilter(img);
            img.Save(path + "pepe2.jpg");
        }
        static void Test1()
        {
            string path = "C:\\Users\\Luis\\Desktop\\Images\\test.png";
            Image img = new Image();
            img.Config(800, 600, new RGBA(1, 0.864, 0.793, 1));
            PaintUtils.FillRectangle(img, new RGBA(0, 1, 0, 1), 200, 300, 100, 100);
            img.Save(path);
        }
        static void Test3()
        {
            string path = "C:\\Users\\Luis\\Desktop\\Images\\";

            Image img = new Image();
            RGBA color = new RGBA(1, 0, 0, 1);
            img.Load(path + "pepe.jpg");
            
            PaintUtils.MultiplyColorsFilter(img, color);
            img.Save(path + "pepe3.jpg");
        }
        static void Test4()
        {
            string path = "C:\\Users\\Luis\\Desktop\\Images\\";

            Image img = new Image();
            img.Load(path + "pepe.jpg");
            img = PaintUtils.FlipImageFilter(img);
            img.Save(path + "pepe4.jpg");
        }
    }
}