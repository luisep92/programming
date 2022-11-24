

namespace Luis
{
    internal class Vector2
    {
        public float x;
        public float y;

        #region CONSTRUCTOR
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        
        public Vector2()
        {
            this.x = 0.0f;
            this.y = 0.0f;
        }
        #endregion

        #region PROPERTIES
        public float Min()
        {
            if (this.y < this.x)
                return y;
            return x;
        }
        public float Max()
        {
            if (this.y < this.x)
                return x;
            return y;
        }
        public static Vector2 Zero => new Vector2(0.0f, 0.0f);
        public string ToString()
        {
            string vx = x.ToString("F2");
            string vy = y.ToString("F2");
            return "(" + vx + ", " + vy + ")";
        }
        #endregion

        #region TOOLS
        public static float Distance(Vector2 a, Vector2 b)
        {
            float dx = a.x - b.x;
            float dy = a.y - b.y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }
        public static Vector2 Diference(Vector2 vec1, Vector2 vec2)
        {
            return new Vector2(vec1.Max() - vec1.Min(), vec2.Max() - vec2.Min());
        }
        #endregion
    }
}
