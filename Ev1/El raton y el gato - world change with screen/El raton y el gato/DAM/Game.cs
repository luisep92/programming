using System;
using El_raton_y_el_gato;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace DAM
{
    public class Game
    {
        public static void Launch(IGameDelegate del)
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(800, 600),
                Title = "LearnOpenTK - Creating a Window",
                // This is needed to run on macos
                Flags = ContextFlags.ForwardCompatible,
            };

            using (var window = new DAM.Window(del, GameWindowSettings.Default, nativeWindowSettings))
            {
                World.window = window;
                window.Run();
            }

        }
    }
}

