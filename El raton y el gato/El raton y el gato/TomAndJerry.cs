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
        int width = 0;
        int height = 0;
        #region DELEGATES
        public void OnDraw(IAssetManager assetManager, IWindow window, ICanvas canvas) //cada frame
        {
            canvas.Clear(0.15f, 0.15f, 0.40f, 1);
            Utils.RenderGrid(canvas);
            DrawCharacters(characterList, canvas);
            HuntRat(characterList[0], characterList[1]);
            ResizeCharacters();
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
        public void ResizeCharacters()
        {
            foreach (Character c in characterList)
            {
                if (World.window.Width != width || World.window.Height != height)
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
