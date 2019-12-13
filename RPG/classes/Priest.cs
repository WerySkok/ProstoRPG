using System;
using RPG.classes.Skills;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.classes
{
    class Priest : Character
    {
        public Priest():base(new Skill[] { new Heal(), new Attack() })
        {
            MaxHp = 75;
            Hp = 75;
            MaxMana = 80;
            Mana = 80;
            manaType = "Мана";
            Name = "Жрец";
        }
       
    }
}
