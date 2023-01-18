using DAM;
using Luis;
using static Luis.Utils;

namespace Luis
{
    internal class Renderer : Component
    {
        public IBuffer? sprite;
        public List<IBuffer> sprites = new List<IBuffer>();
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
            canvas.FillShader.SetImage(this.sprite, new RGBA(color.r, color.g, color.b, color.a));
            canvas.Transform.SetTranslation((double)t.position.x - t.size.x / 2, (double)t.position.y - t.size.y / 2);
            canvas.FillRectangle(new Rect2D(0,0, (double)t.size.x, (double)t.size.y));
        }
        void RenderTrail(ICanvas canvas, Vector2 pos, float alpha)
        {
            Transform t = this.gameObject.transform;
            canvas.FillShader.SetImage(this.sprite, new RGBA(color.r, color.g, color.b, alpha));
            canvas.Transform.SetTranslation(0.0, 0.0);
            canvas.FillRectangle(new Rect2D((double)pos.x - t.size.x / 2, (double)pos.y - t.size.y / 2, (double)t.size.x, (double)t.size.y));
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
        public override void Behavior(ICanvas canvas, IAtomicDecoder manager, Scene world)
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
