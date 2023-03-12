using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_2_Luis_Escolano
{
    public class Striker : Player
    {
        double _mamon;

        public Striker(Vector2 position, Team team, string name) : base(position, team, name, 10)
        {
            _mamon = Utils.RandomRange(75.0, 100.0);
            _accuracy = Utils.RandomRange(20.0, 40.0);
        }
        public override void Execute(Partido p)
        {
            if (!IsEnabled())
            {
                _turnsDisabled--;
                return;
            }

            if (HasBall(p))
                MoveWithBall(p);
            else
                MoveWithoutBall(p);
        }

        protected void MoveWithBall(Partido p)
        {
            if(Utils.Probability(_mamon))
            {
                List<Vector2> list = GetAvailablePositions(p, 1);
                Utils.SoryByY(list);
                if (Team.TeamSide == TeamSide.UP)
                    list.Reverse();
                TryMove(list, p);
                p.Ball.Position = Position;

                if (Utils.Probability(20))
                    MoveWithBall(p);
            }
            else
            {
                if (Utils.Probability(_accuracy))
                    RandomPassBall(p);
                else
                    p.GetRandomPlayer(Team).DropBall(p, 2, true);
            }
        }

        protected void MoveWithoutBall(Partido p)
        {
            List<Vector2> list = GetAvailablePositions(p, 1);
            Utils.SoryByY(list);
            if (Team.TeamSide == TeamSide.DOWN)
                list.Reverse();
            
            SortByPlayersAround(list, p);
            
            TryMove(list, p);
        }
        

        private void TryMove(List<Vector2> positions, Partido p)
        {
            foreach (Vector2 pos in positions)
            {
                if (!p.IsOcupped(pos) && p.IsInside(pos))
                {
                    Position = pos;
                    return;
                }
            }
        }
    }
}
