using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_2_Luis_Escolano
{
    internal class SpecialDefensor : Defensor
    {
        private double _hitProbability;

        public SpecialDefensor(Vector2 position, Team team, string name) : base(position, team, name)
        {
            _hitProbability = Utils.RandomRange(30, 70);
        }

        public override void Execute(Partido partido)
        {
            if (!IsEnabled())
            {
                _turnsDisabled--;
                return;
            }
            base.Execute(partido);
            DisableCharacterAround(partido);            
        }

        // Javi: Mejor, try to disable
        void DisableCharacterAround(Partido partido)
        {
            foreach (Player p in GetPlayersAround(partido, 1))
            {
                if (p.Team != Team && Utils.Probability(_hitProbability))
                {
                    p.Disable(1);
                }
            }
        }
    }
}
