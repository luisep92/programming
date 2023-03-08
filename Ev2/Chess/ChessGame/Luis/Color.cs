using DAM;

namespace Luis
{
    public class Color
    {
        public static RGBA red = new RGBA(1, 0, 0, 0.99999f);
        public static RGBA white = new RGBA(1, 1, 1, 0.99999f);
        public static RGBA black = new RGBA(0, 0, 0, 0.99999f);
        public static RGBA blue = new RGBA(0, 0, 1, 0.99999);
        public static RGBA green = new RGBA(0, 1, 0, 0.99999f);
        public static RGBA grey = new RGBA(0.7f, 0.7f, 0.7f, 0.99999f);
        public static RGBA yellow = new RGBA(1, 1, 0, 0.99999f);
        public static RGBA pink = new RGBA(1, 0, 1, 0.99999f);
        public static RGBA cyan = new RGBA(0, 1, 1, 0.99999f);
        public static RGBA brown = new RGBA(0.82f, 0.41f, 0.12f, 0.99999f);

        public static RGBA Red(float alpha)
        {
            return new RGBA(1, 0, 0, alpha);
        }
        public static RGBA White(float alpha)
        {
            return new RGBA(1, 1, 1, alpha);
        }
        public static RGBA Black(float alpha)
        {
            return new RGBA(0, 0, 0, alpha);
        }
        public static RGBA Blue(float alpha)
        {
            return new RGBA(0, 0, 1, alpha);
        }
        public static RGBA Green(float alpha)
        {
            return new RGBA(0, 1, 0, alpha);
        }
        public static RGBA Grey(float alpha)
        {
            return new RGBA(0.7f, 0.7f, 0.7f, alpha);
        }
        public static RGBA Yellow(float alpha)
        {
            return new RGBA(1, 1, 0, alpha);
        }
        public static RGBA Pink(float alpha)
        {
            return new RGBA(1, 0, 1, alpha);
        }
        public static RGBA Cyan(float alpha)
        {
            return new RGBA(0, 1, 1, alpha);
        }
        public static RGBA Brown(float alpha)
        {
            return new RGBA(0.82f, 0.41f, 0.12f, alpha);
        }
    }
}
