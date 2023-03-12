using System.Collections.Generic;
using static Examen_2_Luis_Escolano.Utils;

namespace Examen_2_Luis_Escolano
{
    public delegate void Visitor(Character character);
    public class Partido
    {
        private List<Character> _charList = new();
        private Vector2 _size;
        private Team _teamUp;
        private Team _teamDown;
        private int _duration;
        public  Ball Ball;

        public Vector2 Size => _size;

        //Algunas cosas como la duracion o el tamaño se podrían pasar por parametro pero como pone las cantidades en el enunciado, lo dejo así
        public Partido(string TeamNameUp, string TeamNameDown)
        {
            _size = new Vector2(10, 20);
            _duration = 1000;
            Ball = new(GetRandomPosition());
            _teamUp = new Team(TeamNameUp, TeamSide.UP);
            _teamDown = new Team(TeamNameDown, TeamSide.DOWN);
        }

        public void Start()
        {
            Ball.Position = GetRandomPosition();
            _charList.Add(new Dementor(GetRandomPosition()));
            _charList.Add(new Dementor(GetRandomPosition()));
            _charList.Add(new Dementor(GetRandomPosition()));
            _charList.Add(new Dementor(GetRandomPosition()));

            _charList.Add(new Striker(new Vector2(4, 19), _teamUp, RandomName()));
            _charList.Add(new Striker(new Vector2(5, 19), _teamUp, RandomName()));
            _charList.Add(new Striker(new Vector2(6, 19), _teamUp, RandomName()));
            _charList.Add(new Striker(new Vector2(7, 19), _teamUp, RandomName()));
            _charList.Add(new Defensor(new Vector2(4, 20), _teamUp, RandomName()));
            _charList.Add(new Defensor(new Vector2(5, 20), _teamUp, RandomName()));
            _charList.Add(new Defensor(new Vector2(6, 20), _teamUp, RandomName()));
            _charList.Add(new Defensor(new Vector2(7, 20), _teamUp, RandomName()));
            _charList.Add(new SpecialDefensor(new Vector2(3, 20), _teamUp, RandomName()));
            _charList.Add(new SpecialDefensor(new Vector2(8, 20), _teamUp, RandomName()));

            _charList.Add(new Striker(new Vector2(4, 2), _teamDown, RandomName()));
            _charList.Add(new Striker(new Vector2(5, 2), _teamDown, RandomName()));
            _charList.Add(new Striker(new Vector2(6, 2), _teamDown, RandomName()));
            _charList.Add(new Striker(new Vector2(7, 2), _teamDown, RandomName()));
            _charList.Add(new Defensor(new Vector2(4, 1), _teamDown, RandomName()));
            _charList.Add(new Defensor(new Vector2(5, 1), _teamDown, RandomName()));
            _charList.Add(new Defensor(new Vector2(6, 1), _teamDown, RandomName()));
            _charList.Add(new Defensor(new Vector2(7, 1), _teamDown, RandomName()));
            _charList.Add(new SpecialDefensor(new Vector2(3, 1), _teamDown, RandomName()));
            _charList.Add(new SpecialDefensor(new Vector2(8, 1), _teamDown, RandomName()));
        }

        public void Execute()
        {
            for(int i = 0; i < _duration; i++)
            {
                foreach (Character character in _charList)
                {
                    character.Execute(this);

                    if (IsGoal())
                    {
                        Player? goaler = GetPlayerAtPosition(Ball.Position);
                        if (goaler != null)
                            goaler.ScoreGoal(this);
                        else
                            GoalerTeam().AddScore(1);
                    }
                }
            }
        }


        public Team GetWinner()
        {
            if (_teamUp.Score > _teamDown.Score)
                return _teamUp;
            if (_teamUp.Score < _teamDown.Score)
                return _teamDown;
            else
                return new Team("EMPATE", TeamSide.UP);
        }

        public bool IsInside(Vector2 pos)
        {
            return pos.x <= Size.x &&
                   0 < pos.x &&
                   pos.y <= Size.y &&
                   0 < pos.y;
        }

        public void Visit(Visitor visitor)
        {
            for(int i = 0; i < _charList.Count; i++)
            {
                visitor(_charList[i]);
            }
        }

        public bool IsOcupped(Vector2 pos)
        {
            foreach(Character c in _charList)
            {
                if (c.Position == pos)
                    return true;
            }
            return false;
        }

        public void Restart()
        {
            Ball.Position = GetRandomPosition();
            foreach(Player p in GetPlayers())
            {
                p.RestartPosition();
            }
        }

        public Vector2 GetRandomPosition()
        {
            Vector2 pos = new Vector2(RandomRangeInt(1, Size.x + 1), RandomRangeInt(1, Size.y + 1));

            if (IsInside(pos))
                return pos;
            else
                return GetRandomPosition();
        }

        public void MoveBall(Vector2 pos)
        {
            Ball.Position = pos;
        }

        public bool IsGoal()
        {
            return Ball.Position.y <= 1 || Ball.Position.y >= Size.y;
        }

        public bool IsBallAlone()
        {
            foreach(Player p in GetPlayers())
            {
                if (HasBall(p))
                    return false;
            }
            return true;
        }

        public bool HasBall(Player p)
        {
            return p.Position == Ball.Position;
        }

        //Devuelve el equipo al que se le suman los puntos
        public Team GoalerTeam()
        {
            if (Ball.Position.y == Size.y)
                return _teamDown;
            return _teamUp;
        }
        public Team EnemyTeam(Player p)
        {
            if (p.Team == _teamDown)
                return _teamUp;
            return _teamDown;
        }

        public Player GetRandomPlayer(Team team)
        {
            List<Player> list = GetTeamList(team);
            int index = RandomRangeInt(0, list.Count);
            return list[index];
        }

        public Player? GetPlayerAtPosition(Vector2 pos)
        {
            foreach (Player p in GetPlayers())
            {
                if (p.Position == pos)
                    return p;
            }
            return null;
        }

        public List<Character> GetCharList()
        {
            List<Character> list = new();

            foreach (Character c in _charList)
            {
                list.Add(c);
            }
            return list;
        }

        public List<Player> GetPlayers()
        {
            List<Player> list = new();

            foreach (Character c in _charList)
            {
                if (c.GetCharType() == CharType.PLAYER)
                {
                    list.Add((Player)c);
                }
            }
            return list;
        }

        public List<Player> GetTeamList(Team team)
        {
            List<Player> players = new();
            foreach (Character c in _charList)
            {
                if (c.GetCharType() == CharType.PLAYER)
                {
                    Player p = (Player)c;
                    if (p.Team == team)
                        players.Add(p);
                }
            }
            return players;
        }
    }
}
