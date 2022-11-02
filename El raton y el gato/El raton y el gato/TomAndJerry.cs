using DAM;
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
        
        public void OnDraw(ICanvas canvas)
        {
            canvas.Clear(0, 0, 0, 1);
            foreach(Character c in characterList)
            {
                DrawCharacter(c, canvas);
                c.Move();
            }
        }

        public void OnKeyboard(IWindow window, IKeyboard keyboard, IMouse mouse)
        {
            
        }

        public void OnLoad()
        {
            characterList = CreateCharacters();
        }

        public void OnUnload()
        {
            
        }

        public List<Character> CreateCharacters()
        {
            List<Character> list = new List<Character>();

            list.Add(new Character(Type.CAT, new Vector2(-1f, -0.2f), new Vector2(0.4f, 0.4f), new RGBA(1, 0, 0, 1)));
            list.Add(new Character(Type.RAT, new Vector2(0.6f, -0.2f), new Vector2(0.4f, 0.4f), new RGBA(0, 1, 0, 1)));

            return list;
        }

        public void DrawCharacter(Character c, ICanvas canvas)
        {
            canvas.FillRectangle(
                c.position.x, 
                c.position.y, 
                c.scale.x, 
                c.scale.y, 
                (float)c.color.r, 
                (float)c.color.g, 
                (float)c.color.b, 
                (float)c.color.a);
        }
    }
}
