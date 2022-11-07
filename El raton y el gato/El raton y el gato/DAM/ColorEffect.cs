using System;
using OpenTK.Graphics.OpenGL4;

namespace DAM
{
    public class ColorEffect : IDisposable
    {
        private Shader _shader;
        private int mVertexArrayObject;
        int vertexColorLocation;


        public Shader Shader { get { return _shader; } }

        public static string GenPixelShader()
        {
            return @"
            #version 330
            out vec4 outputColor;
            uniform vec4 ourColor; 
            void main()
            {
                outputColor = ourColor;
            }";
        }

        public static string GenVertexShader()
        {
            return @"
            #version 330 core
            layout(location = 0) in vec3 aPosition;
            void main(void)
            {
                gl_Position = vec4(aPosition, 1.0);
            }";
        }

        public ColorEffect(int vertexBuffer)
        {
            string pixel_shader = GenPixelShader();
            string vertex_shader = GenVertexShader();
            _shader = Shader.CreateFromStrings(vertex_shader, pixel_shader);

            _shader.Use();
            vertexColorLocation = GL.GetUniformLocation(_shader.Handle, "ourColor");

            mVertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(mVertexArrayObject);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBuffer);
            GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 2 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

        }

        internal void Use(float r, float g, float b, float a)
        {
            _shader.Use();
            GL.Uniform4(vertexColorLocation, r, g, b, a);
            if (a < 1.0)
            {
                GL.Enable(EnableCap.Blend);
                GL.BlendFuncSeparate(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha, BlendingFactorSrc.One, BlendingFactorDest.Zero);
            }
            else
            {
                GL.Disable(EnableCap.Blend);
            }
            GL.BindVertexArray(mVertexArrayObject);
        }

        public void Dispose()
        {
            GL.DeleteVertexArray(mVertexArrayObject);
            GL.DeleteProgram(_shader.Handle);
        }
    }
}

