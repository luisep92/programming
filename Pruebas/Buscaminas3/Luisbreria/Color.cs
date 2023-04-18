using UDK;

namespace Luisbreria
{
    public class Color
    {
        public static readonly rgba_f64 red = new rgba_f64(1, 0, 0, 0.99999f);
        public static readonly rgba_f64 white = new rgba_f64(1, 1, 1, 0.99999f);
        public static readonly rgba_f64 black = new rgba_f64(0, 0, 0, 0.99999f);
        public static readonly rgba_f64 blue = new rgba_f64(0, 0, 1, 0.99999);
        public static readonly rgba_f64 green = new rgba_f64(0, 1, 0, 0.99999f);
        public static readonly rgba_f64 grey = new rgba_f64(0.7f, 0.7f, 0.7f, 0.99999f);
        public static readonly rgba_f64 yellow = new rgba_f64(1, 1, 0, 0.99999f);
        public static readonly rgba_f64 pink = new rgba_f64(1, 0, 1, 0.99999f);
        public static readonly rgba_f64 cyan = new rgba_f64(0, 1, 1, 0.99999f);
        public static readonly rgba_f64 brown = new rgba_f64(0.7f, 0.41f, 0.0f, 0.99999f);
        public static readonly rgba_f64 lightBrown = new rgba_f64(1f, 0.9f, 0.8f, 0.99999f);

        public static rgba_f64 Red(float alpha)
        {
            return new rgba_f64(1, 0, 0, alpha);
        }
        public static rgba_f64 White(float alpha)
        {
            return new rgba_f64(1, 1, 1, alpha);
        }
        public static rgba_f64 Black(float alpha)
        {
            return new rgba_f64(0, 0, 0, alpha);
        }
        public static rgba_f64 Blue(float alpha)
        {
            return new rgba_f64(0, 0, 1, alpha);
        }
        public static rgba_f64 Green(float alpha)
        {
            return new rgba_f64(0, 1, 0, alpha);
        }
        public static rgba_f64 Grey(float alpha)
        {
            return new rgba_f64(0.7f, 0.7f, 0.7f, alpha);
        }
        public static rgba_f64 Yellow(float alpha)
        {
            return new rgba_f64(1, 1, 0, alpha);
        }
        public static rgba_f64 Pink(float alpha)
        {
            return new rgba_f64(1, 0, 1, alpha);
        }
        public static rgba_f64 Cyan(float alpha)
        {
            return new rgba_f64(0, 1, 1, alpha);
        }
        public static rgba_f64 Brown(float alpha)
        {
            return new rgba_f64(0.82f, 0.41f, 0.12f, alpha);
        }
    }
}