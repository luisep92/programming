using DAM;
using Luis;
using static Luis.Utils;

namespace SpaceInvaders
{
    internal class Renderer : Component
    {
        public Image sprite;
        public List<Image> sprites = new List<Image>();
        public RGBA color = Color.white;

        public Renderer(GameObject parent)
        {
            gameObject = parent;

            parent.AddComponent(this);
        }
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
        public void RenderRectangle(ICanvas canvas, GameObject go)
        {
            FillRectangle(
                canvas,
                go.transform.position.x - go.transform.size.x / 2,
                go.transform.position.y - go.transform.size.y / 2,
                go.transform.size.x,
                go.transform.size.y,
                Color.white);
        }
        public void Render(ICanvas canvas)
        {
            Transform t = this.gameObject.transform;
            canvas.FillRectangle(
                t.position.x - t.size.x / 2,
                t.position.y - t.size.y / 2,
                t.size.x,
                t.size.y,
                this.sprite,
                0f, 0f, 1f, 1f, (float)color.r, (float)color.g, (float)color.b,
                (float)color.a);
        }

        public override void Behavior(ICanvas canvas, IAssetManager manager, World world)
        {
            if (sprite != null)
                Render(canvas);
            else
                RenderRectangle(canvas, gameObject, color);
        }
    }
}
