using ChessLib;
using DAM;
using Luis;
using OpenTK.Windowing.Common.Input;

namespace ChessGame
{
    internal class Renderer : IDrawable
    {
        public static List<IBuffer>? FigureImages;
        public static ICanvas? canvas;
        public IBuffer? image;

        public Renderer(Figure figure)
        {
            image = AssignImage(figure);
        }
        public void Render(Figure figure)
        {
            canvas.FillShader.SetImage(image, Luis.Color.white);
            canvas.Transform.SetTranslation(figure.GetPosition.x, figure.GetPosition.y);
            canvas.FillRectangle(new Rect2D(0, 0, 1, 1));
        }
        public static void DrawBoard()
        {
            for(int i = 1; i < 9; i++)
            {
                RGBA color;
                if (i % 2 == 0) 
                    color = Luis.Color.white;
                else
                    color = Luis.Color.black;

                for(int j = 1; j < 9; j++)
                {
                    Rect2D transform = new Rect2D(j, i, 1, 1);
                    FillRectangle(color, transform);
                    color = !color;
                    color.a = 1;
                }
            }
        }
        public static void FillRectangle(RGBA color, Rect2D r)
        {
            canvas.FillShader.SetColor(color);
            canvas.Transform.SetTranslation(r.x, r.y);
            canvas.FillRectangle(new Rect2D(0, 0, r.width, r.height));
        }
        public static void FillImage(IBuffer image, Position pos)
        {
            canvas.FillShader.SetImage(image);
            canvas.Transform.SetTranslation(pos.x, pos.y);
            canvas.FillRectangle(new Rect2D(0, 0, 1, 1));
        }
        public static IBuffer? LoadImage(string path, GameDelegateEvent gameEvent)
        {
            return IAtomicDecoder.LoadFromFile(path).CloneToBuffer(gameEvent.canvasContext, new CreateBufferParams(), true);
        }


        public static List<IBuffer> LoadImages(GameDelegateEvent gameEvent)
        {
            string path = "resources/Figures/";
            List<IBuffer> images = new List<IBuffer>();
            for (int i = 1; i < 13; i++)
            {
                images.Add(LoadImage(path+i+".png", gameEvent));
            }
            return images;
        }
        public static IBuffer AssignImage(Figure fig)
        {
            if(fig.GetFigureType() == FigureType.BISHOP)
            {
                if (fig.Color == ChessLib.Color.WHITE)
                    return FigureImages[7];
                else
                    return FigureImages[1];
            }
            else if(fig.GetFigureType() == FigureType.KNIGHT)
            {
                if (fig.Color == ChessLib.Color.WHITE)
                    return FigureImages[9];
                else
                    return FigureImages[3];
            }
            else if (fig.GetFigureType() == FigureType.TOWER)
            {
                if (fig.Color == ChessLib.Color.WHITE)
                    return FigureImages[12];
                else
                    return FigureImages[6];
            }
            else if (fig.GetFigureType() == FigureType.QUEEN)
            {
                if (fig.Color == ChessLib.Color.WHITE)
                    return FigureImages[11];
                else
                    return FigureImages[5];
            }
            else if (fig.GetFigureType() == FigureType.PAWN)
            {
                if (fig.Color == ChessLib.Color.WHITE)
                    return FigureImages[10];
                else
                    return FigureImages[4];
            }
            else if (fig.GetFigureType() == FigureType.KING)
            {
                if (fig.Color == ChessLib.Color.WHITE)
                    return FigureImages[8];
                else
                    return FigureImages[2];
            }
            return null;
        }
    }
}
