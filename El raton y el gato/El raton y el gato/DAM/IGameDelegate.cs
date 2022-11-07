using System;

namespace DAM
{
    public interface IGameDelegate
    {
        void OnLoad(IAssetManager manager);
        void OnDraw(IAssetManager manager, IWindow window, ICanvas canvas);
        void OnKeyboard(IAssetManager manager, IWindow window, IKeyboard keyboard, IMouse mouse);
        void OnUnload(IAssetManager manager);
    }
}

