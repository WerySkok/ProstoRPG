using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.classes.Skills
{
    abstract class Skill
    {
        private string name;
        private int energy;
        private int rate;
        public string Title
        {
            get
            {
                return name;
            }
            protected set
            {
                name = value;
            }
        }
        public int Energy // то что снимается с маны
        {
            get
            {
                return energy;
            }
            protected set
            {
                energy = value;
            }
        }
        public int Rate // то число, оказывающее воздействие на цель
        {
            get
            {
                return rate;
            }
            protected set
            {
                rate = value;
            }
        }
        public abstract void Action(Character self, Character target);
    }
}
