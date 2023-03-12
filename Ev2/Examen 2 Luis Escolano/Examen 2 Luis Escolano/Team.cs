using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_2_Luis_Escolano
{
    public enum TeamSide { UP, DOWN }
    public class Team
    {
        private string _name;
        private TeamSide _teamSide;
        private int _score;
        public TeamSide TeamSide => _teamSide;
        public string Name => _name;
        public int Score => _score;

        public Team(string name, TeamSide side)
        {
            _name = name;
            _teamSide = side;
            _score = 0;
        }

        public void AddScore(int quantity)
        {
            _score += quantity;
        }

        public bool HasBall(Partido p)
        {
            foreach(Player player in p.GetTeamList(this))
            {
                if (p.HasBall(player))
                    return true;
            }
            return false;
        }
    }
}
