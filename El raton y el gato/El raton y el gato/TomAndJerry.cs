using DAM;
using static El_raton_y_el_gato.World;
using static El_raton_y_el_gato.Utils;
using static El_raton_y_el_gato.Collision;
namespace El_raton_y_el_gato
{
    internal class TomAndJerry : IGameDelegate
    {
        public List<Character> characterList;
        public Image background;
        public static float time = 0;

        #region DELEGATES
        public void OnDraw(IAssetManager assetManager, IWindow window, ICanvas canvas) //cada frame
        {
            time += 1f / 60f;
            canvas.SetCamera(X.Min(), Y.Min(), X.Max(), Y.Max(),true);
            ClearCanvas(canvas, Color.Black());
            canvas.FillRectangle(X.Min(), Y.Min(), Dimensions().x, Dimensions().y, background, 0,0,1,1, 0.9f,0.9f,0.9f,0.99f);
            if(Utils.isDebugging)
                RenderGrid(canvas,window, X, Y);
            DrawCharacters(characterList, canvas);
            HuntRat(characterList[0], characterList[1]);
        }

        public void OnKeyboard(IAssetManager assetManager, IWindow window, IKeyboard keyboard, IMouse mouse) //cada frame
        {
            if (keyboard.IsKeyDown(Keys.Escape))
                CloseGame(window);
            MoveCharacters(keyboard);
            SetDebugMode(keyboard);
        }

        public void OnLoad(IAssetManager assetManager, IWindow window) //al iniciar la aplicacion
        {
            background = assetManager.LoadImage("resources/background.jpg");
            characterList = CreateCharacters(assetManager);
            //window.ToggleFullScreen();
        }

        public void OnUnload(IAssetManager assetManager, IWindow window) //al cerrar la aplicacion
        {
            
        }
        #endregion

        #region GAME
        void CloseGame(IWindow window)
        {
            window.Close();
        }
        #endregion

        #region LOOPS_CHARACTERS
        public List<Character> CreateCharacters(IAssetManager assetManager)
        {
            List<Character> list = new List<Character>();
            Image cat = assetManager.LoadImage("resources/cat.png");
            Image rat = assetManager.LoadImage("resources/rat.png");

            list.Add(new Character(Type.CAT, new Vector2(2, 0), new Vector2(2f,2f), Color.Red(), cat, 80f));
            list.Add(new Character(Type.RAT, new Vector2(-2, 0), new Vector2(2f, 2f), Color.White(), rat, 80f));

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
            float dist = cat.size.x;

           // bool col = SquareCollision(cat.position, cat.size, rat.position, rat.size);
            if (Vector2.Distance(cat.position, rat.position) < dist)
            {
                float randX = RandomRange(X.Min(), X.Max());
                float randY = RandomRange(Y.Min(), Y.Max());

                characterList.Remove(rat);
                characterList.Add(new Character(Type.RAT, new Vector2(randX, randY), rat.size, Color.White(), rat.sprite, 80f));
            }
        }
        #endregion
    }
}
