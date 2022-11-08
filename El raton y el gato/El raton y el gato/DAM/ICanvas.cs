
namespace DAM
{
    public interface ICanvas
    {
        void Clear(float r, float g, float b, float a);
        void FillConvexPolygon(float[] vertices, float r, float g, float b, float a);
        void FillRectangle(float x, float y, float w, float h, float r, float g, float b, float a);
        void FillRectangle(float x, float y, float w, float h, RGBA color);
        void FillRectangle(float x, float y, float w, float h, Image? image, float ix, float iy, float iw, float ih, float r, float g, float b, float a);
    }
}

