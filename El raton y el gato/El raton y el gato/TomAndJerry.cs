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

namespace El_raton_y_el_gato
{
    internal class TomAndJerry : IGameDelegate
    {
        public List<Character> characterList;
        public Vector2 dimensions;
        
       
        public void OnDraw(IAssetManager assetManager, IWindow window, ICanvas canvas) //cada frame
        {
            canvas.Clear(0.15f, 0.15f, 0.40f, 1);
            Utils.RenderGrid(window, canvas, this);
            DrawCharacters(characterList, canvas, window);
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

        public List<Character> CreateCharacters()
        {
            List<Character> list = new List<Character>();


            list.Add(new Character(Type.CAT, new Vector2(9, 6.5f), new Vector2(2f,2f), new RGBA(1, 0, 0, 1), 200f));
            list.Add(new Character(Type.RAT, new Vector2(-9, 6.5f), new Vector2(2f, 2f), new RGBA(0, 1, 0, 1), 20f));

            return list;
        }

        public float Unit(float resX, float resY)
        {
            return (1f / (dimensions.x / 2f));
        }
        public void DrawCharacters(List<Character> list, ICanvas canvas, IWindow window)
        {
            foreach (Character c in list)
            {
                c.Render(canvas, window);
            }
        }
        public void MoveCharacters(IKeyboard keyboard)
        {
            foreach (Character c in characterList)
            {
                c.Move(keyboard);
            }
        }
        public static float AspectRatio()
        {
            return Utils.AspectRatio(800, 600);
        }
       public static Vector2 Dimensions()
        {
            return new Vector2(20, 20 / AspectRatio());
        }
    }
}
