using DAM;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static El_raton_y_el_gato.World;

namespace El_raton_y_el_gato
{
    internal class TomAndJerry : IGameDelegate
    {
        public List<Character> characterList;

        public static float time = 0;

        int width = 0;
        int height = 0;
        #region DELEGATES
        public void OnDraw(IAssetManager assetManager, IWindow window, ICanvas canvas) //cada frame
        {
            time += 1f / 60f;
            canvas.SetCamera(-10,-5,10,5,true);
            canvas.Clear(0.15f, 0.15f, 0.40f, 1);
            // Utils.RenderGrid(canvas);
            canvas.FillRectangle(-10, -5, 20, 10, 1.0f, 1.0f, 0.0f, 1.0f);
            DrawCharacters(characterList, canvas);
           // HuntRat(characterList[0], characterList[1]);
           // ResizeCharacters();
        }


        public void OnKeyboard(IAssetManager assetManager, IWindow window, IKeyboard keyboard, IMouse mouse) //cada frame
        {
            MoveCharacters(keyboard);
        }


        public void OnLoad(IAssetManager assetManager, IWindow window) //al iniciar la aplicacion
        {
            characterList = CreateCharacters(assetManager);
        }

        public void OnUnload(IAssetManager assetManager, IWindow window) //al cerrar la aplicacion
        {
            
        }
        #endregion

        #region LOOPS_CARACTERS
        public List<Character> CreateCharacters(IAssetManager assetManager)
        {
            List<Character> list = new List<Character>();
            DAM.Image cat = assetManager.LoadImage("C:\\Users\\Luis\\Desktop\\Images\\cat.jpg");
            DAM.Image rat = assetManager.LoadImage("C:\\Users\\Luis\\Desktop\\Images\\rat.jpg");

            list.Add(new Character(Type.CAT, new Vector2(1, 0), new Vector2(2f,2f), new RGBA(1, 0, 0, 1), cat, 80f));
            list.Add(new Character(Type.RAT, new Vector2(0, 0), new Vector2(2f, 2f), new RGBA(0, 1, 0, 1), rat, 60f));

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
            float dist = cat.initScale.x * Meter(Dimensions().x);

            if (Vector2.Distance(cat.position, rat.position) < dist)
            {
                float randX = Utils.RandomRange(-Dimensions().x, Dimensions().x)/2;
                float randY = Utils.RandomRange(-Dimensions().y, Dimensions().y)/2;

                characterList.Remove(rat);
                characterList.Add(new Character(Type.RAT, new Vector2(randX, randY), new Vector2(2f, 2f), new RGBA(0, 1, 0, 1), rat.sprite, 60f));
            }
        }
        public void ResizeCharacters()
        {
            if (World.window.Width != width || World.window.Height != height)
            {
                foreach (Character c in characterList)
                {
                    c.Resize(World.window);
                }
            }
            width = World.window.Width;
            height = World.window.Height;
        }
        #endregion
    }
}
