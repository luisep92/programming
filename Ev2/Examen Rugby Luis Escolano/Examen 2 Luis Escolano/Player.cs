using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_2_Luis_Escolano
{
    public abstract class Player : Character
    {
        private int _scoreQuantity;
        private string _name;
        private double _skill;
        private Vector2 _startpos;
        protected int _turnsDisabled;
        protected double _accuracy;
        public Team Team;

        public double Skill => _skill;

        protected Player(Vector2 position, Team team, string name, int scoreQuantity) : base(position)
        {
            Team = team;
            _scoreQuantity = scoreQuantity;
            _name = name;
            _skill = Utils.RandomRange(40.0, 60.0);
            _startpos = position;
        }

        public void RestartPosition()
        {
            Position = _startpos;
        }
        public void ScoreGoal(Partido p)
        {
            Team? t = p.GoalerTeam();
            if(t != null)
            {
                t.AddScore(_scoreQuantity);
                Console.WriteLine(ToString() + " GOLASO" +"  "  + GetType());
                p.Restart();
            }
        }

        public override CharType GetCharType()
        {
            return CharType.PLAYER;
        }

        public bool IsBallInRange(Partido p, int range)
        {
            Vector2 ballPos = p.Ball.Position;
            return Distance(ballPos) <= range;
        }

        
        protected Team EnemyTeam(Partido p)
        {
            return p.EnemyTeam(this);
        }

        protected bool HasBall(Partido p)
        {
            return p.HasBall(this);
        }

        protected void RandomPassBall(Partido p)
        {
            p.MoveBall(p.GetRandomPlayer(Team).Position);
        }

        public void DropBall(Partido p, int distance, bool onlyBorder)
        {
            List<Vector2> list;
            if (onlyBorder)
                list = GetPositionsSquare(p, distance);
            else
                list = GetPositionsAround(p, distance);

            int index = Utils.RandomRangeInt(0, list.Count);

            p.MoveBall(list[index]);
        }

        public bool IsEnabled()
        {
            return _turnsDisabled <= 0;
        }

        public void Disable(int turns)
        {
            _turnsDisabled += turns;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
