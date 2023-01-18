using DAM;
using Luis;

namespace ChessGame
{
    public class Game : IGameDelegate
    {
        internal static Scene MainScene = new Scene();
        public static float Time = 0f;
        GameObject gggg;

        public void OnLoad(GameDelegateEvent gameEvent)
        {
            gggg = GameObject.Instantiate(prueba(gameEvent), new Vector2(4,4));
        }

        public void OnDraw(GameDelegateEvent gameEvent, ICanvas canvas)
        {
            canvas.Clear(Color.black);
            MainScene.SetCamera(canvas);
            MainScene.OnDrawBehavior(canvas, null, MainScene);

            GameObject.InstanceAndDestroyObjects(MainScene);

            Utils.Debug(canvas,MainScene);

        }

        public void OnKeyboard(GameDelegateEvent gameEvent, IKeyboard keyboard, IMouse mouse)
        {
            Utils.SetDebugMode(keyboard);
            
            if (gggg.transform.position.y + gggg.transform.size.y / 2 < MainScene.Y.Max)
            {
                if (Input.GetKey(keyboard, Keys.W))
                    gggg.transform.position.y += 0.01f;
            }
            if (Input.GetKey(keyboard, Keys.S))
                gggg.transform.position.y -= 0.01f;
        }

        public void OnUnload(GameDelegateEvent gameEvent)
        {
        }

        GameObject prueba(GameDelegateEvent gameEvent)
        {
            GameObject go = new GameObject();
            Renderer ren = new Renderer(go);

            go.transform.size = new Vector2(2f, 1f);
            ren.sprite = IAtomicDecoder.LoadFromFile("resources/cat.png").CloneToBuffer(gameEvent.canvasContext, new CreateBufferParams(), true);
            return go;
        }
    }
}
