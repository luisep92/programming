using DAM;
using ChessGame;
namespace Luis
{
    internal class Animator : Component
    {
        float time;
        int i = 0;
        Renderer ren;
        float t = 0;
        bool destroyOnEnd = false;

        public Animator(Renderer renderer, float time, GameObject parent)
        {
            ren = renderer;
            this.time = time;
            gameObject = parent;
            gameObject.AddComponent(this);
        }
        public Animator(Renderer renderer, float time, GameObject parent, bool destroyOnEnd)
        {
            ren = renderer;
            this.time = time;
            gameObject = parent;
            gameObject.AddComponent(this);
            this.destroyOnEnd = destroyOnEnd;
        }

        public override void Behavior(ICanvas canvas, IAtomicDecoder manager, Scene world)
        {
            AnimateOnTime();
        }

        public void AnimateOnTime()
        {
            t += Time.deltaTime;
            if(t >= time)
            {
                ChangeSprite();
                t = 0;
            }
        }
        public void ChangeSprite()
        {
            i++;
            if (i == ren.sprites.Count)
            {
                if (destroyOnEnd)
                {
                    GameObject.Destroy(this.gameObject, ChessGame.Game.MainScene);
                }  
                i = 0;
            }
            ren.sprite = ren.sprites[i];
        }

        public void Reset()
        {
            i = 0;
            t = 0;
            ren.sprite = ren.sprites[0];
        }
    }
}
