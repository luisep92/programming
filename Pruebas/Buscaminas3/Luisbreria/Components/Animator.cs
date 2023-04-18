using UDK;

namespace Luisbreria
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
            if (t >= time)
            {
                ChangeSprite();
                t = 0;
            }
        }

        //revisar
        public void ChangeSprite()
        {
            i++;
            if (i == ren.sprites.Count)
            {
                if (destroyOnEnd)
                {//revisar null
                    GameObject.Destroy(this.gameObject, null);
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