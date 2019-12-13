using System;
using RPG.classes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Game
    {
        private Team[] teams = new Team[] { new Team("1", true), new Team("2", false) };

        private void TeamsInfo()
        {
            foreach (Team team in teams)
            {
                team.TeamInfo();
            }
        }

        private int PlayableStep(int current, int targetTeam)
        {
            TeamsInfo();
            Console.Write("Выберите бойца: ");
            int chosen = int.Parse(Console.ReadLine());

            teams[current - 1].Persons[chosen - 1].SkillsInfo();
            Console.Write("Выберите способность: ");
            int chosenSkill = int.Parse(Console.ReadLine());

            if (teams[current - 1].Persons[chosen - 1].Skills[chosenSkill - 1].Title == "Лечение")
            {
                Console.Write("Выберите союзника: ");
            }
            else
            {
                Console.Write("Выберите цель: ");
            }
            int target = int.Parse(Console.ReadLine());

            if (chosen > 0 || chosen <= teams[current - 1].Persons.Length)
            {
                if (chosenSkill > 0 && chosenSkill <= teams[current - 1].Persons[chosen - 1].Skills.Length)
                {
                    if (target > 0 && target <= teams[targetTeam - 1].Persons.Length)
                    {
                        if (teams[current - 1].Persons[chosen - 1].Hp > 0)
                        {
                            if (teams[current - 1].Persons[chosen - 1].Mana >= teams[current - 1].Persons[chosen - 1].Skills[chosenSkill - 1].Energy)
                            {
                                if (teams[current - 1].Persons[chosen - 1].Skills[chosenSkill - 1].Title == "Лечение" && teams[current - 1].Persons[target - 1].Hp > 0)
                                {
                                    teams[current - 1].Persons[chosen - 1].Skills[chosenSkill - 1].Action(teams[current - 1].Persons[chosen - 1], teams[current - 1].Persons[target - 1]);
                                    return 2;
                                }
                                else if (teams[targetTeam - 1].Persons[target - 1].Hp > 0)
                                {
                                    teams[current - 1].Persons[chosen - 1].Skills[chosenSkill - 1].Action(teams[current - 1].Persons[chosen - 1], teams[targetTeam - 1].Persons[target - 1]);
                                    return 2;
                                }
                                else
                                {
                                    Console.WriteLine("Цель уже мёртва!");
                                    Console.ReadLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("У вас недостаточно маны!");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine(teams[current - 1].Persons[chosen - 1].Name + " мёртв!\n" +
                                              "Вы не можете играть при помощи него!");
                            Console.ReadLine();
                        }
                    }
                }
            }
            return 1;
        }

        private int AIStep(int current, int targetTeam)
        {
            Random r = new Random();
            bool exitFromLoop = false;
            int AIChosen;
            int AITarget;
            int AIChosenSkill;
            do
            {
                AIChosen = r.Next(0, teams[current - 1].Persons.Length);

                AIChosenSkill = r.Next(0, teams[current - 1].Persons[AIChosen].Skills.Length);

                if (teams[current - 1].Persons[AIChosen].Skills[AIChosenSkill].Title == "Лечение")
                {
                    AITarget = r.Next(0, teams[current - 1].Persons.Length);
                }
                else
                {
                    AITarget = r.Next(0, teams[targetTeam - 1].Persons.Length);
                }

                if (teams[current - 1].Persons[AIChosen].Hp > 0)
                {
                    if (teams[current - 1].Persons[AIChosen].Mana >= teams[current - 1].Persons[AIChosen].Skills[AIChosenSkill].Energy)
                    {
                        if (teams[current - 1].Persons[AIChosen].Skills[AIChosenSkill].Title == "Лечение" && teams[current - 1].Persons[AITarget].Hp > 0)
                        {
                            teams[current - 1].Persons[AIChosen].Skills[AIChosenSkill].Action(teams[current - 1].Persons[AIChosen], teams[current - 1].Persons[AITarget]);
                            exitFromLoop = true;
                        }
                        else if (teams[targetTeam - 1].Persons[AITarget].Hp > 0)
                        {
                            teams[current - 1].Persons[AIChosen].Skills[AIChosenSkill].Action(teams[current - 1].Persons[AIChosen], teams[targetTeam - 1].Persons[AITarget]);
                            exitFromLoop = true;
                        }
                    }
                }
            } while (!exitFromLoop);

            TeamsInfo();

            if (teams[current - 1].Persons[AIChosen].Skills[AIChosenSkill].Title == "Лечение")
            {
                Console.WriteLine("Вражеский {0} >> {1} (+{2} hp) >> Вражеский {3}", teams[current - 1].Persons[AIChosen].Name, teams[current - 1].Persons[AIChosen].Skills[AIChosenSkill].Title,
                              teams[current - 1].Persons[AIChosen].Skills[AIChosenSkill].Rate, teams[current - 1].Persons[AITarget].Name);
            }
            else
            {
                Console.WriteLine($"Вражеский {teams[current - 1].Persons[AIChosen].Name} >> { teams[current - 1].Persons[AIChosen].Skills[AIChosenSkill].Title} (-{teams[current - 1].Persons[AIChosen].Skills[AIChosenSkill].Rate} hp) >> Ваш {teams[targetTeam - 1].Persons[AITarget].Name}");
            }

            Console.Write("Для продолжения нажмите любую Enter...");
            Console.ReadLine();
            return 1;
        }

        public void Start()
        {
            int current = 1;
            bool gameOver = false;
            while (!gameOver)
            {
                Console.WriteLine("Сейчас ходит отряд №{0}", current);
                if (teams[current - 1].IsPlayable)
                {
                    current = PlayableStep(current, 2);
                }
                else
                {
                    current = AIStep(current, 1);
                }

                Console.Clear();

                foreach (Team team in teams)
                {
                    if (team.IsEnd())
                    {
                        gameOver = true;
                        Console.WriteLine("Игра окончена. Команда №{0} проиграла.", team.Name);
                    }
                }
            }
        }
    }
}
