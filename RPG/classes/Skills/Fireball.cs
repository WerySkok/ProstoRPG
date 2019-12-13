using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.classes.Skills
{
    class Fireball : Skill
    {
        public Fireball()
        {
            Title = "Огненный шар";
            Energy = 40;
            Rate = 25;
        }
        public override void Action(Character self, Character target)
        {
            target.Hp -= Rate;
            self.Mana -= Energy;
        }
    }
}
