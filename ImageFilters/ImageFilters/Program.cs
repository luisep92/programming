using DAM;
namespace ImageFilters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\Luis\\Desktop\\Images\\test.png";
            Image img = new Image();
            img.Config(800, 600, new RGBA(1, 0.864, 0.793, 1));
            PaintUtils.FillRectangle(img, new RGBA(0, 1, 0, 1), 200, 300, 100, 100);
            img.Save(path);
        }
    }
}