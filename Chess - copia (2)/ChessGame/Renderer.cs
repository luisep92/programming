using ChessLib;
using DAM;
using Luis;

namespace ChessGame
{
    internal class Renderer : IDrawable
    {
        public static List<IBuffer>? FigureImages;
        public static ICanvas canvas;
        public IBuffer? image;

        public Renderer(Figure figure)
        {
            image = AssignImage(figure);
        }

        public static void RenderFigures(Board board)
        {
            int max = board.Figures.Count;

            for (int i = 0; i < max; i++)
            {
                Figure f = board.Figures[i];
                f.renderer?.RenderFigure(f);
            }
        }
        public void RenderFigure(Figure figure)
        {
            canvas.FillShader.SetImage(image, Luis.Color.white);
            canvas.Transform.SetTranslation(figure.GetPosition.x, figure.GetPosition.y);
            canvas.FillRectangle(new Rect2D(0, 0, 1, 1));
        }
        public static void RenderAvailablePositions(List<Position>? list)
        {
            if (list == null)
                return;
            else
            {
                for(int i = 0; i < list.Count; i++)
                {
                    FillRectangle(Luis.Color.Green(0.4f), new Rect2D(list[i].x, list[i].y, 1, 1));
                }
            }
        }
        public static void DrawBoard()
        {
            for(int i = 1; i < 9; i++)
            {
                RGBA color = BoardColor(i);

                for(int j = 1; j < 9; j++)
                {
                    Rect2D transform = new Rect2D(j, i, 1, 1);
                    FillRectangle(color, transform);
                    color = BoardColor(j + i);
                }
            }
        }
        static RGBA BoardColor(int n)
        {
            if(n % 2 == 0)
                return Luis.Color.lightBrown;
            else
                return Luis.Color.brown;
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
            try
            {
                return IAtomicDecoder.LoadFromFile(path).CloneToBuffer(gameEvent.canvasContext, new CreateBufferParams(), true);
            }
            catch
            {
                Console.WriteLine("Error al cargar la imagen con ruta: " + path);
                return null;
            }
        }


        private static List<IBuffer> LoadImages(GameDelegateEvent gameEvent)
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
                    return FigureImages[6];
                else
                    return FigureImages[0];
            }
            else if(fig.GetFigureType() == FigureType.KNIGHT)
            {
                if (fig.Color == ChessLib.Color.WHITE)
                    return FigureImages[8];
                else
                    return FigureImages[2];
            }
            else if (fig.GetFigureType() == FigureType.TOWER)
            {
                if (fig.Color == ChessLib.Color.WHITE)
                    return FigureImages[11];
                else
                    return FigureImages[5];
            }
            else if (fig.GetFigureType() == FigureType.QUEEN)
            {
                if (fig.Color == ChessLib.Color.WHITE)
                    return FigureImages[10];
                else
                    return FigureImages[4];
            }
            else if (fig.GetFigureType() == FigureType.PAWN)
            {
                if (fig.Color == ChessLib.Color.WHITE)
                    return FigureImages[9];
                else
                    return FigureImages[3];
            }
            else if (fig.GetFigureType() == FigureType.KING)
            {
                if (fig.Color == ChessLib.Color.WHITE)
                    return FigureImages[7];
                else
                    return FigureImages[1];
            }
            return null;
        }
        public static void SetFigures(GameDelegateEvent e, Board b)
        {
            Renderer.FigureImages = Renderer.LoadImages(e);
            for (int i = 0; i < b.Figures.Count; i++)
            {
                Figure f = b.Figures[i];
                Renderer ren = new Renderer(f);
                f.renderer = ren;
            }
        }
    }
}
