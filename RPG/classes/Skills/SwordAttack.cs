using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.classes.Skills
{
    class SwordAttack:Skill
    {
        public SwordAttack()
        {
            Title = "Атака мечом";
            Energy = 25;
            Rate = 15;
        }
        public override void Action(Character self, Character target)
        {
            target.Hp -= Rate;
            self.Mana -= Energy;
        }
    }
}
