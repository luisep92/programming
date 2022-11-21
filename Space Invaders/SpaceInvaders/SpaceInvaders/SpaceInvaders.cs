﻿using DAM;
using static Luis.Utils;
using static Luis.Color;
using Luis;

namespace SpaceInvaders
{
    internal class SpaceInvaders : IGameDelegate
    {
        public void OnDraw(IAssetManager manager, IWindow window, ICanvas canvas)
        {
            Time.UpdateDeltaTime();
            canvas.SetCamera(World.X.Min(), World.Y.Min(), World.X.Max(), World.Y.Max(), true);
            ClearCanvas(canvas, black);
            Debug(canvas, window);
            World.OnDrawBehavior(canvas);
            GameObject.InstanceAndDestroyObjects();
        }
        public void OnKeyboard(IAssetManager manager, IWindow window, IKeyboard keyboard, IMouse mouse)
        {
            SetDebugMode(keyboard);
            World.InputBehavior(keyboard);
        }

        public void OnLoad(IAssetManager manager, IWindow window)
        {
            Vector2 playerPos = new Vector2(0, World.Y.Min() + 3f);
            GameObject.Instantiate(Player.prefab(manager), playerPos);

            
            GameObject muro = GameObject.Instantiate(new GameObject(),Vector2.Zero);
            muro.transform.size = new Vector2(20, 1);
            Renderer ren = new Renderer(muro);
            muro.tag = Tag.ENEMY;
        }

        public void OnUnload(IAssetManager manager, IWindow window)
        {
            
        }
    }
}