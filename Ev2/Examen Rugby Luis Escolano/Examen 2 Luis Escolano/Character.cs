using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_2_Luis_Escolano
{
    public enum CharType { DEMENTOR, PLAYER }
    public abstract class Character
    {
        public Vector2 Position;


        public Character(Vector2 position)
        {
            Position = position;
        }


        //Devuelve posiciones que no esten ocupadas
        public List<Vector2> GetAvailablePositions(Partido p, int distance)
        {
            List<Vector2> positions = new();
            for (int i = Position.x - distance; i <= Position.x +distance; i++)
            {
                for(int j = Position.y - distance; j <= Position.y + distance; j++)
                {
                    Vector2 pos = new Vector2(i, j);
                    if (pos == Position)
                        continue;
                    if (p.IsInside(pos) && !p.IsOcupped(pos) && pos != Position)
                        positions.Add(pos);
                }
            }
            return positions;
        }

        //Este solo devuelve el "borde" del cuadrado. No comprueba si la casilla está ocupada.
        public List<Vector2> GetPositionsSquare(Partido p, int distance)
        {
            List<Vector2> positions = new();
            for (int i = Position.x - distance; i <= Position.x + distance; i++)
            {
                for (int j = Position.y - distance; j <= Position.y + distance; j++)
                {
                    if (!(i == Position.x + distance || i == Position.x - distance ||
                          j == Position.y + distance || j == Position.y - distance))
                        continue;

                    Vector2 pos = new Vector2(i, j);
                    if (p.IsInside(pos))
                        positions.Add(pos);
                }
            }
            return positions;
        }


        //Devuelve posiciones esten ocupadas o no
        public List<Vector2> GetPositionsAround(Partido p, int distance)
        {
            List<Vector2> list = new();

            for(int i = 1; i <= distance; i++)
            {
                foreach(Vector2 vec in GetPositionsSquare(p, distance))
                {
                    list.Add(vec);
                }
            }
            return list;
        }

        public List<Player> GetPlayersAround(Partido p, int distance)
        {
            List<Player> list = new();
            var l = GetPositionsSquare(p, distance);

            foreach(Vector2 pos in l)
            {
                Player? player = p.GetPlayerAtPosition(pos);

                if (player != null && player.Position != Position)
                {
                    list.Add(player);
                }
            }
            return list;
        }

        protected bool MoveTo(Partido p, Vector2 pos)
        {
            Vector2 direction = new Vector2(0, 0);

            if (pos.x - Position.x > 1)
                direction.x = 1;
            if (pos.x - Position.x < -1)
                direction.x = -1;
            if (pos.y - Position.y > 1)
                direction.y = 1;
            if (pos.y - Position.x < -1)
                direction.y = -1;

            Vector2 nextPos = Position + direction;
            if (!p.IsOcupped(nextPos) && p.IsInside(nextPos))
            {
                Position = nextPos;
                return true;
            }
            return false;
        }

        protected int Distance(Vector2 p)
        {
            int disX = Math.Abs(p.x - Position.x);
            int disY = Math.Abs(p.y - Position.y);

            if ( disX< disY)
                return disY;
            return disX;
        }

        public void SortByPlayersAround(List<Vector2> list, Partido p)
        {
            list.Sort((a, b) =>
            {
                Vector2 aux = Position;
                Position = a;
                int playersAroundA = GetPlayersAround(p, 1).Count;

                Position = b;
                int playersAroundB = GetPlayersAround(p, 2).Count;

                Position = aux;

                if (playersAroundA > playersAroundB) 
                    return 1;
                if (playersAroundA < playersAroundB)
                    return -1;
                return 0;
            });
        }

        public abstract CharType GetCharType();
        public abstract void Execute(Partido partido);
    }
}
