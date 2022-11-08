using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;
using OpenTK.Audio.OpenAL;

namespace DAM
{
    // Be warned, there is a LOT of stuff here. It might seem complicated, but just take it slow and you'll be fine.
    // OpenGL's initial hurdle is quite large, but once you get past that, things will start making more sense.
    public class Window : GameWindow, ICanvas, IKeyboard, IWindow, IMouse, IAssetManager
    {

        private readonly float[] mRectangleBuffer = new float[64];

        private int mVertexBufferObject;


        private ColorEffect mColorEffect;
        private TextureShader mTextureEffect;

        private List<Texture?> mTextureList = new List<Texture?>();

        private KeyboardState mKeyboardState;
        private MouseState mMouseState;

        private IGameDelegate mDelegate;

        public float X => mMouseState.X;
        public float Y => mMouseState.Y;
        public float PrevX => mMouseState.PreviousX;
        public float PrevY => mMouseState.PreviousY;
        public float DX => mMouseState.Delta.X;
        public float DY => mMouseState.Delta.Y;
        public float ScrollX => mMouseState.Scroll.X;
        public float ScrollY => mMouseState.Scroll.Y;
        public float ScrollPrevX => mMouseState.PreviousScroll.X;
        public float ScrollPrevY => mMouseState.PreviousScroll.Y;
        public float ScrollDX => mMouseState.ScrollDelta.X;
        public float ScrollDY => mMouseState.ScrollDelta.Y;

        public int Width => Size.X;

        public int Height => Size.Y;

        public Window(IGameDelegate del, GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
            mDelegate = del;
        }

        // Now, we start initializing OpenGL.
        protected override void OnLoad()
        {
            base.OnLoad();
            mVertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, mVertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, mRectangleBuffer.Length * sizeof(float), IntPtr.Zero, BufferUsageHint.StaticDraw);
            //GL.BufferStorage(BufferTarget.ArrayBuffer, 2 * 4 * sizeof(float), p, BufferStorageFlags.DynamicStorageBit);

            mColorEffect = new ColorEffect(mVertexBufferObject);
            mTextureEffect = new TextureShader(mVertexBufferObject);

            mDelegate.OnLoad(this);
        }

        private void PrepareBuffer(float[] vertices, int byteCount)
        {
            GL.BindVertexArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, mVertexBufferObject);
            GL.BufferSubData(BufferTarget.ArrayBuffer, IntPtr.Zero, byteCount, vertices);
        }

        public void FillConvexPolygon(float[] vertices, float r, float g, float b, float a)
        {
            PrepareBuffer(vertices, vertices.Length * sizeof(float));
            mColorEffect.Use(r, g, b, a);
            GL.DrawArrays(PrimitiveType.Triangles, 0, vertices.Length >> 1);
        }

        public void FillRectangle(float x, float y, float w, float h, float r, float g, float b, float a)
        {
            mRectangleBuffer[0] = x;
            mRectangleBuffer[1] = y;
            mRectangleBuffer[2] = x;
            mRectangleBuffer[3] = y + h;
            mRectangleBuffer[4] = x + w;
            mRectangleBuffer[5] = y;
            mRectangleBuffer[6] = x + w;
            mRectangleBuffer[7] = y + h;

            PrepareBuffer(mRectangleBuffer, 8 * sizeof(float));
            mColorEffect.Use(r, g, b, a);
            GL.DrawArrays(PrimitiveType.TriangleStrip, 0, 4);
        }
        public void FillRectangle(float x, float y, float w, float h, RGBA color)
        {
            mRectangleBuffer[0] = x;
            mRectangleBuffer[1] = y;
            mRectangleBuffer[2] = x;
            mRectangleBuffer[3] = y + h;
            mRectangleBuffer[4] = x + w;
            mRectangleBuffer[5] = y;
            mRectangleBuffer[6] = x + w;
            mRectangleBuffer[7] = y + h;

            PrepareBuffer(mRectangleBuffer, 8 * sizeof(float));
            mColorEffect.Use((float)color.r, (float)color.g, (float)color.b, (float)color.a);
            GL.DrawArrays(PrimitiveType.TriangleStrip, 0, 4);
        }

        public void FillRectangle(float x, float y, float w, float h, Image? image, float ix, float iy, float iw, float ih, float r, float g, float b, float a)
        {
            Texture? t = null;
            if (image != null && image.IsValid)
            {
                t = mTextureList[image.Hash];
            }
            if (t != null)
            {
                mRectangleBuffer[0] = x;
                mRectangleBuffer[1] = y;
                mRectangleBuffer[2] = ix;
                mRectangleBuffer[3] = iy;

                mRectangleBuffer[4] = x;
                mRectangleBuffer[5] = y + h;
                mRectangleBuffer[6] = ix;
                mRectangleBuffer[7] = iy + ih;

                mRectangleBuffer[8] = x + w;
                mRectangleBuffer[9] = y;
                mRectangleBuffer[10] = ix + iw;
                mRectangleBuffer[11] = iy;

                mRectangleBuffer[12] = x + w;
                mRectangleBuffer[13] = y + h;
                mRectangleBuffer[14] = ix + iw;
                mRectangleBuffer[15] = iy + ih;

                PrepareBuffer(mRectangleBuffer, 16 * sizeof(float));

                mTextureEffect.Use(t, r, g, b, a);
                GL.DrawArrays(PrimitiveType.TriangleStrip, 0, 4);
            }
        }


        public void Clear(float r, float g, float b, float a)
        {
            GL.Disable(EnableCap.Blend);
            GL.ClearColor(r, g, b, a);
            GL.Clear(ClearBufferMask.ColorBufferBit);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            mDelegate.OnDraw(this, this, this);
            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            mKeyboardState = KeyboardState;
            mMouseState = MouseState;

            mDelegate.OnKeyboard(this, this, this, this);
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, ClientSize.X, ClientSize.Y);
        }

        protected override void OnUnload()
        {
            mDelegate.OnUnload(this);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);

            // Delete all the resources.
            GL.DeleteBuffer(mVertexBufferObject);

            mColorEffect.Dispose();
            mTextureEffect.Dispose();

            base.OnUnload();
        }

        public bool IsKeyDown(Keys keys)
        {
            return mKeyboardState.IsKeyDown((OpenTK.Windowing.GraphicsLibraryFramework.Keys)keys);
        }

        public bool IsPressed(MouseButton button)
        {
            return mMouseState.IsButtonPressed((OpenTK.Windowing.GraphicsLibraryFramework.MouseButton)button);
        }

        public Image LoadImage(string path)
        {
            var text = Texture.LoadFromFile(path);
            if (text == null)
                return new Image(-1);
            for (int i = 0; i < mTextureList.Count; i++)
            {
                if (mTextureList[i] == null)
                {
                    mTextureList[i] = text;
                    return new Image(i);
                }
            }
            mTextureList.Add(text);
            return new Image(mTextureList.Count - 1);
        }

        public void RemoveImage(Image image)
        {
            if (image.IsValid)
            {
                int index = image.Hash;
                mTextureList[index] = null;
            }
        }
    }
}
