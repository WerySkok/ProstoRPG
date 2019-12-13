using System;
using RPG.classes.Skills;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.classes
{
    class Warrior:Character
    {
        public Warrior():base(new Skill[] { new SwordAttack(), new Attack() })
        {
            MaxHp = 120;
            Hp = 120;
            MaxMana = 75;
            Mana = 75;
            manaType = "Сила";
            Name = "Воин";
        }
    }
}
