using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.classes.Skills
{
    class Attack:Skill
    {
        public Attack()
        {
            Title = "Слабая атака";
            Energy = 0;
            Rate = 5;
        }
        public override void Action(Character self, Character target)
        {
            target.Hp -= Rate;
            self.Mana -= Energy;
        }
    }
}
