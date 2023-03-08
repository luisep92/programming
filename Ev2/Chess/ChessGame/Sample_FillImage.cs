using System;
using DAM;
using Luis;

namespace TestDAMNuget
{
    public class Sample_FillImage : IGameDelegate
    {
        DAM.IBuffer? image;
        Scene mainScene = new Scene();
        double y = 4;
        public void OnDraw(GameDelegateEvent gameEvent, ICanvas canvas)
        {
            mainScene.SetCamera(canvas);
            canvas.Clear(Color.black);

            if (image != null)
            {
                canvas.FillShader.SetImage(image, new RGBA(1, 1, 1, 1));
                canvas.Transform.SetTranslation(4, y);
                canvas.FillRectangle(new Rect2D(0, 0, 1, 1));
            }
        }

        public void OnKeyboard(GameDelegateEvent gameEvent, IKeyboard keyboard, IMouse mouse)
        {
            if (keyboard.IsKeyDown(Keys.Escape))
                gameEvent.window.Close();

            if (Input.GetKey(keyboard, Keys.W))
                y += 0.01;
            if (Input.GetKey(keyboard, Keys.S))
                y -= 0.01;
        }

        public void OnLoad(GameDelegateEvent gameEvent)
        {
            image = IAtomicDecoder.LoadFromFile("resources/dices.png").CloneToBuffer(gameEvent.canvasContext, new CreateBufferParams(), true);
        }

        public void OnUnload(GameDelegateEvent gameEvent)
        {
        }
    }
}


