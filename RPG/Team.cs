using System;
using RPG.classes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Team
    {
        public Team(string _name, bool _isPlayable)
        {
            Name = _name;
            Persons = new Character[] { new Warrior(), new Mage(), new Priest() };
            IsPlayable = _isPlayable;
        }

        public Character[] Persons
        {
            get;
            private set;
        }
        public string Name
        {
            get;
            private set;
        }

        public bool IsPlayable
        {
            get;
            private set;
        }

        public bool IsEnd()
        {
            foreach (Character character in Persons)
            {
                if (!character.IsDead && character.Name != "Жрец")
                {
                    return false;
                }
            }
            return true;
        }

        public void TeamInfo()
        {
            Console.WriteLine("Информация об отряде {0}", Name);
            for (int i = 0; i < Persons.Length; i++)
            {
                Persons[i].Info(i + 1, "   ");
            }
        }
    }
}
