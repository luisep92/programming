using ChessLib;
using DAM;
using Luis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class Game : IGameDelegate
    {
        Board b = new Board();
        List<Position>? _availableMoves;
        Figure? _activeFigure;
        int turn = 0;
        public void OnDraw(GameDelegateEvent gameEvent, ICanvas canvas)
        {
            Renderer.canvas = canvas;
            canvas.Camera.SetRect(new Rect2D(1,1,8,8));
            canvas.Clear(Luis.Color.black);
            Renderer.DrawBoard();
            Renderer.RenderAvailablePositions(_availableMoves);
            Renderer.RenderFigures(b);
        }

        public void OnKeyboard(GameDelegateEvent gameEvent, IKeyboard keyboard, IMouse mouse)
        {
            ManageFigure(mouse, gameEvent);
        }

        public void OnLoad(GameDelegateEvent gameEvent)
        {
            Renderer.SetFigures(gameEvent, b);
        }

        public void OnUnload(GameDelegateEvent gameEvent)
        {
            
        }

        void ManageFigure(IMouse mouse, GameDelegateEvent gameEvent)
        {
            if (mouse.IsPressed(MouseButton.Left))
            {
                var pos = gameEvent.coordinateConversor.ViewToWorld(mouse.X, mouse.Y);
                Position position = new Position((int)pos.x, (int)pos.y);

                if(_availableMoves != null && Utils.IsInList(position, _availableMoves))
                {
                    b.MoveFigures(_activeFigure, position);
                    CrownPawn();
                    turn++;
                    _activeFigure = null;
                    _availableMoves = null;
                    return;
                }

                Figure f = b.GetFigureAt(position);

                if (f != null && f.Color == GetTurnColor(turn))
                {
                    _activeFigure = f;
                    _availableMoves = f.GetAvailablePositions(b);
                }
                else
                {
                    _availableMoves = null;
                }
            }

            void CrownPawn()
            {
                if((_activeFigure.GetPosition.y == 8 || _activeFigure.GetPosition.y == 1) && _activeFigure.GetFigureType() == FigureType.PAWN)
                {
                    Figure f = b.Figures[b.Figures.Count - 1];
                    f.renderer = new Renderer(f);
                }
            }

            ChessLib.Color GetTurnColor(int i)
            {
                if (turn % 2 == 0)
                    return ChessLib.Color.WHITE;
                else
                    return ChessLib.Color.BLACK;
            }
        }

    }
}
