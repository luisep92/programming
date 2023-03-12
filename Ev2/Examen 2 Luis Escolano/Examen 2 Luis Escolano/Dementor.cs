using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Examen_2_Luis_Escolano
{
    public class Dementor : Character
    {

        public Dementor(Vector2 position) : base(position)
        {

        }

        public override CharType GetCharType()
        {
            return CharType.DEMENTOR;
        }
        public override void Execute(Partido p)
        {
            double prob = Utils.RandomRange(0, 100);
            if (prob < 50)
            {
                List<Player> l = GetPlayersAround(p, 1);
                if(l.Count > 0)
                {
                    l[Utils.RandomRangeInt(0, l.Count - 1)].Disable(2);
                }
                    
            }
            else
            {
                List<Player> players = p.GetPlayers();
                SortByDistance(players);

                foreach (Player player in players)
                {
                    if(Distance(player) > 1)
                    {
                       if(!MoveTo(p, player.Position))
                       {
                           List<Vector2> av = GetAvailablePositions(p, 1);
                           if (av.Count > 0)
                               Position = av[Utils.RandomRangeInt(0, av.Count)];
                       }
                    }
                }
            }

            if (Utils.Probability(20))
            {
                Execute(p);
            }
        }
        
        protected int Distance(Player p)
        {
            return Distance(p.Position);
        }

        void SortByDistance(List<Player> l)
        {
            l.Sort((a, b) =>
            {
                if (Distance(a) > Distance(b))
                    return 1;
                if (Distance(a) < Distance(b))
                    return -1;
                return 0;
            });
        }
    }
}
