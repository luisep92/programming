using DAM;
using Luis;

namespace SpaceInvaders
{
    internal class Animator : Component
    {
        public float time;
        public Renderer ren;
        float t = 0;
        int i = 0;

        public Animator(Renderer renderer, float time, GameObject parent)
        {
            ren = renderer;
            this.time = time;
            gameObject = parent;
            gameObject.AddComponent(this);
        }

        public override void Behavior(ICanvas canvas)
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
            ren.sprite = ren.sprites[i];
            i++;
            if (i == ren.sprites.Count)
                i = 0;
        }
    }
}
