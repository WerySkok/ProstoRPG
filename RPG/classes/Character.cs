using System;
using RPG.classes.Skills;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.classes
{
    abstract class Character
    {
        private int hp;
        private int maxHp;
        private int mana;
        private int maxMana;
        public string manaType;
        public string Name;
        public bool IsDead = false;
        private Skill[] skills;

        public Character(Skill[] _skills)
        {
            skills = _skills;
        }

        public int Hp
        {
            get
            {
                return hp;
            }

            set
            {
                if (value <= 0)
                {
                    IsDead = true;
                    hp = 0;
                }
                else if (value > MaxHp)
                {
                    hp = MaxHp;
                }
                else
                {
                    hp = value;
                }
            }
        }

        public int MaxHp
        {
            get
            {
                return maxHp;
            }

            protected set
            {
                if (value < 0)
                {
                    maxHp = 0;
                }
                else
                {
                    maxHp = value;
                }
            }
        }

        public int Mana
        {
            get
            {
                return mana;
            }

            set
            {
                if (value > MaxMana)
                {
                    mana = MaxMana;
                }
                else if (value < 0)
                {
                    mana = 0;
                }
                else
                {
                    mana = value;
                }
            }
        }

        public int MaxMana
        {
            get
            {
                return maxMana;
            }
            protected set
            {
                if (value < 0)
                {
                    maxMana = 0;
                }
                else
                {
                    maxMana = value;
                }
            }
        }

        public Skill[] Skills
        {
            get
            {
                return skills;
            }
        }

        public void SkillsInfo()
        {
            for (int i = 0; i < Skills.Length; i++)
            {
                Console.WriteLine("{0} - {1}. {2} hp, {3} {4}", i + 1, Skills[i].Title, Skills[i].Rate, Skills[i].Energy, manaType);
            }
        }

        public void Info(int characterNumber, string spaces)
        {
            Console.WriteLine("{0}. {1}", characterNumber, Name);
            Console.WriteLine("{0}Здоровье: {1}/{2}", spaces, Hp, MaxHp);
            Console.WriteLine("{0}{1}: {2}/{3}", spaces, manaType, Mana, MaxMana);
        }
    }
}
