using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_2_Luis_Escolano
{
    public class Defensor : Player
    {
        public Defensor(Vector2 position, Team team, string name) : base(position, team, name, 3)
        {
            _accuracy = Utils.RandomRange(20, 80);
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

        private void MoveWithBall(Partido p)
        {
            if(Utils.RandomRange(0,100) < 50)
            {
                 List<Vector2> avMoves = GetAvailablePositions(p, 1);
                 if (avMoves.Count > 0)
                 {
                    Position = avMoves[Utils.RandomRangeInt(0,avMoves.Count)];
                    p.Ball.Position = Position;
                 }
            }
            else
            {
                if(Utils.Probability(_accuracy))
                    RandomPassBall(p);
                else
                    DropBall(p, 2, true);
            }
        }

        private void MoveWithoutBall(Partido p)
        {
            if (PickUpBall(p))
            {
                MoveWithBall(p);
                return;
            }
            StealBall(p);

            if(Team.HasBall(p) && Utils.RandomRange(0.0, 100.0) < 50)
            {
                MoveTo(p, p.GetRandomPlayer(EnemyTeam(p)).Position);                
            }
            else
            {
                MoveTo(p, p.Ball.Position);
            }
        }

        protected bool PickUpBall(Partido p)
        {
            if (p.IsBallAlone() && IsBallInRange(p, 1))
            {
                p.MoveBall(Position);
                return true;
            }
            return false;                
        }

        protected void StealBall(Partido p)
        {
            foreach(Player player in GetPlayersAround(p, 1))
            {
                if (player.Team != Team && p.HasBall(player) && Utils.RandomRange(0, 100) < player.Skill)
                {
                    DropBall(p, 2, false);
                }
            }
        }
    }
}
