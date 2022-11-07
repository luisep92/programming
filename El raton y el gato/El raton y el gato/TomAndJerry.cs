﻿using DAM;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace El_raton_y_el_gato
{
    internal class TomAndJerry : IGameDelegate
    {
        public List<Character> characterList;


        #region STATIC
        public static float AspectRatio()
        {
            return Utils.AspectRatio(800, 600);
        }
        public static Vector2 Dimensions()
        {
            return new Vector2(20, 20 / AspectRatio());
        }
        public static float Meter(float axis)
        {
            return (1f / (axis / 2f));
        }
        #endregion

        #region DELEGATES
        public void OnDraw(IAssetManager assetManager, IWindow window, ICanvas canvas) //cada frame
        {
            canvas.Clear(0.15f, 0.15f, 0.40f, 1);
            Utils.RenderGrid(canvas);
            DrawCharacters(characterList, canvas);
            HuntRat(characterList[0], characterList[1]);
        }


        public void OnKeyboard(IAssetManager assetManager, IWindow window, IKeyboard keyboard, IMouse mouse) //cada frame
        {
            MoveCharacters(keyboard);
        }


        public void OnLoad(IAssetManager assetManager) //al iniciar la aplicacion
        {
            characterList = CreateCharacters();
        }

        public void OnUnload(IAssetManager assetManager) //al cerrar la aplicacion
        {
            
        }
        #endregion

        #region LOOPS_CARACTERS
        public List<Character> CreateCharacters()
        {
            List<Character> list = new List<Character>();

            list.Add(new Character(Type.CAT, new Vector2(5, 0), new Vector2(2f,2f), new RGBA(1, 0, 0, 1), 80f));
            list.Add(new Character(Type.RAT, new Vector2(-5, 0), new Vector2(2f, 2f), new RGBA(0, 1, 0, 1), 60f));

            return list;
        }
        public void DrawCharacters(List<Character> list, ICanvas canvas)
        {
            foreach (Character c in list)
            {
                c.Render(canvas);
            }
        }
        public void MoveCharacters(IKeyboard keyboard)
        {
            foreach (Character c in characterList)
            {
                c.Move(keyboard);
            }
        }
        public void HuntRat(Character cat, Character rat)
        {
            if (Vector2.Distance(cat.position, rat.position) < 2 * Meter(Dimensions().x))
            {
                float randX = Utils.RandomRange(-Dimensions().x, Dimensions().x)/2;
                float randY = Utils.RandomRange(-Dimensions().y, Dimensions().y)/2;

                characterList.Remove(rat);
                characterList.Add(new Character(Type.RAT, new Vector2(randX, randY), new Vector2(2f, 2f), new RGBA(0, 1, 0, 1), 60f));
            }
        }
        #endregion
    }
}
