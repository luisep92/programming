namespace Luisbreria
{
    public class Transform
    {
        public Vector2 position;
        public Vector2 size;

        #region CONSTRUCTOR
        public Transform(Vector2 position, Vector2 size)
        {
            this.position = position;
            this.size = size;
        }
        public Transform()
        {
            this.position = Vector2.Zero;
            this.size = new Vector2(1f, 1f);
        }
        #endregion
    }
}
