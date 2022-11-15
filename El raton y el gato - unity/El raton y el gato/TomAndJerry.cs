using DAM;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace El_raton_y_el_gato
{
    internal class TomAndJerry : IGameDelegate
    {
        public List<Character> characterList;
        
        public void OnDraw(ICanvas canvas) //cada frame
        {
            canvas.Clear(0.15f, 0.15f, 0.40f, 1);
            DrawCharacters(characterList, canvas);
        }

        public void OnKeyboard(IWindow window, IKeyboard keyboard, IMouse mouse) //cada frame
        {
            MoveCharacters(keyboard);
        }


        public void OnLoad() //al iniciar la aplicacion
        {
            characterList = CreateCharacters();
        }

        public void OnUnload() //al cerrar la aplicacion
        {
            
        }

        public List<Character> CreateCharacters()
        {
            List<Character> list = new List<Character>();

            list.Add(new Character(Type.CAT, new Vector2(-1f, -0.5f), new Vector2(0.4f, 0.4f), new RGBA(1, 0, 0, 1), 2f));
            list.Add(new Character(Type.RAT, new Vector2(1, 0.5f), new Vector2(0.4f, 0.4f), new RGBA(0, 1, 0, 1), 4f));

            return list;
        }

        
        public void DrawCharacters(List<Character> list, ICanvas canvas)
        {
            
            foreach (Character c in list)
            {
                var ccc = c.GetComponent2<SpriteRenderer>();
                foreach(SpriteRenderer sRen in c.components)
                {
                    sRen.Render(canvas,c);
                }
            }
        }
        public void MoveCharacters(IKeyboard keyboard)
        {
            foreach (Character c in characterList)
            {
                c.Move(keyboard);
            }
        }
    }
}
