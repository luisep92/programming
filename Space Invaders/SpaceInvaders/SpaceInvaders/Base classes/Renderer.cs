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
        float trail = 0;
        Vector2 pos1 = new Vector2();
        Vector2 pos2 = new Vector2();
        Vector2 pos3 = new Vector2();
        public bool paintTrail = false;

        public Renderer(GameObject parent)
        {
            gameObject = parent;

            pos1 = parent.transform.position;
            pos2 = pos1;
            pos3 = pos2;
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

        void RenderTrail(ICanvas canvas, Vector2 pos, float alpha)
        {
            Transform t = this.gameObject.transform;
            canvas.FillRectangle(
                pos.x - t.size.x / 2,
                pos.y - t.size.y / 2,
                t.size.x,
                t.size.y,
                this.sprite,
                0f, 0f, 1f, 1f, (float)color.r, (float)color.g, (float)color.b,
                alpha);
        }

        void UpdateTrailPos()
        {
            if(trail >= 0.05f)
            {
                trail = 0;
                pos3 = pos2;
                pos2 = pos1;
                pos1 = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            }
        }

        public override void Behavior(ICanvas canvas, IAssetManager manager, World world)
        {
            trail += Time.deltaTime;
            UpdateTrailPos();
            if (sprite != null)
            {
                if (paintTrail)
                {
                    RenderTrail(canvas, pos3, 0.4f);
                    RenderTrail(canvas, pos2, 0.6f);
                    RenderTrail(canvas, pos1, 0.8f);
                }
                
                Render(canvas);
            }
                
            else
                RenderRectangle(canvas, gameObject, color);
        }
    }
}
