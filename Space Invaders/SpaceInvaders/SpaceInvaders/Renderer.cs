using DAM;
using Luis;
using OpenTK.Graphics.OpenGL;
using static Luis.Utils;

namespace SpaceInvaders
{
    internal class Renderer
    {
        public Image sprite;
        public List<Image> sprites = new List<Image>();
        public float opacity;
        public void RenderRectangle(ICanvas canvas, GameObject go, RGBA color)
        {
            FillRectangle(
                canvas,
                go.transform.position.x - go.transform.size.x / 2,
                go.transform.position.y - go.transform.size.y / 2,
                go.transform.size.x,
                go.transform.size.y,
                color);
        }
        public void Render(ICanvas canvas, GameObject go)
        {
            canvas.FillRectangle(
                go.transform.position.x - go.transform.size.x / 2,
                go.transform.position.y - go.transform.size.y / 2,
                go.transform.size.x,
                go.transform.size.y,
                this.sprite,
                0f, 0f, 1f, 1f, 1f, 1f, 1f,
                opacity);
        }
    }
}
