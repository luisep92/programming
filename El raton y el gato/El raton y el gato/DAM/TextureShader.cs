using System;
using OpenTK.Graphics.OpenGL4;

namespace DAM
{
    public class TextureShader : IDisposable
    {
        private Shader _shader;
        private int mVertexArrayObject;
        int vertexColorLocation;
        int textureLocation;
        int vertexLocation;
        int texcoordLocation;


        public Shader Shader { get { return _shader; } }


        public static string GenPixelShader()
        {
            return @"
            #version 330
            out vec4 outputColor;
            in vec2 texCoord;
            uniform sampler2D texture0;
            uniform vec4 ourColor; 
            void main()
            {
                outputColor = texture(texture0, texCoord) * ourColor;
            }";
        }


        public static string GenVertexShader()
        {
            return @"
            #version 330 core
            layout(location = 0) in vec3 aPosition;
            layout(location = 1) in vec2 aTexCoords;
            out vec2 texCoord;
            void main(void)
            {
                gl_Position = vec4(aPosition, 1.0);
                texCoord = aTexCoords;
            }";
        }


        public TextureShader(int vertexBuffer)
        {
            string pixel_shader = GenPixelShader();
            string vertex_shader = GenVertexShader();
            _shader = Shader.CreateFromStrings(vertex_shader, pixel_shader);

            _shader.Use();

            vertexColorLocation = GL.GetUniformLocation(_shader.Handle, "ourColor");
            textureLocation = GL.GetUniformLocation(_shader.Handle, "texture0");
            vertexLocation = _shader.GetAttribLocation("aPosition");
            texcoordLocation = _shader.GetAttribLocation("aTexCoords");

            int stride = 4 * sizeof(float);

            mVertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(mVertexArrayObject);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBuffer);

            GL.VertexAttribPointer(vertexLocation, 2, VertexAttribPointerType.Float, false, stride, 0);
            GL.EnableVertexAttribArray(vertexLocation);

            GL.VertexAttribPointer(texcoordLocation, 2, VertexAttribPointerType.Float, false, stride, 2 * sizeof(float));
            GL.EnableVertexAttribArray(texcoordLocation);
        }

        internal void Use(Texture texture, float r, float g, float b, float a)
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
            texture.Use(TextureUnit.Texture0);
            GL.BindVertexArray(mVertexArrayObject);
        }

        public void Dispose()
        {
            GL.DeleteVertexArray(mVertexArrayObject);
            GL.DeleteProgram(_shader.Handle);
        }
    }
}

