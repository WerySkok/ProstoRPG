using System;
using RPG.classes.Skills;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.classes
{
    class Mage:Character
    {
        public Mage():base(new Skill[] {new Fireball(), new Attack()})
        {
            MaxHp = 90;
            Hp = 90;
            MaxMana = 120;
            Mana = 120;
            manaType = "Мана";
            Name = "Маг";
        }
    }
}
