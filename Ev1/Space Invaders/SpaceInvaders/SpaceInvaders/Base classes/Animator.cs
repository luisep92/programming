﻿using DAM;
using Luis;

namespace SpaceInvaders
{
    // Yo la hubiese llamado SpriteAnimator
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
        // Esto se podría y se debería hacer así
        // public Animator(Renderer renderer, float time, GameObject parent, bool destroyOnEnd) : base(renderer, time, GameObject parent)
        // {
        //     this.destroyOnEnd = destroyOnEnd;
        // }

        public override void Behavior(ICanvas canvas, IAssetManager manager, World world)
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
                    GameObject.Destroy(this.gameObject, SpaceInvaders.world);
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
