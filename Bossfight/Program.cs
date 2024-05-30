namespace Bossfight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                StartMenu();
            }
        }

        private static void StartMenu()
        {
            var Hero = new GameCharacter("Hero", 100, 25, 40);
            var rand = new Random();
            var num = rand.Next(0, 30);
            var Boss = new GameCharacter("Boss", 400, num, 10);
            const string question = "Quick bossfight, beware!";
            string[] choices = { "Start Game", "Exit" };
            var result= Option.GetUserChoice(question, choices);

            switch (result)
            {
                case "Start Game":
                    Battle(Hero, Boss);
                    break;
                case "Exit":
                    System.Environment.Exit(1);
                    break;
            }
        }

        private static void Battle(GameCharacter hero, GameCharacter boss)
        {
            var rand = new Random();

            while (hero.Health > 0 && boss.Health > 0)
            {
                if (hero.Stamina > 0)
                {
                    hero.Fight(boss);
                }
                else
                {
                    hero.Recharge();
                }

                
                boss.Strength = rand.Next(0, 30);

                if (boss.Health > 0)
                {
                    if (boss.Stamina > 0)
                    {
                        boss.Fight(hero);
                    }
                    else
                    {
                        boss.Recharge();
                    }
                }

                Console.WriteLine($"{hero.Name}: HP={hero.Health}, Stamina={hero.Stamina}");
                Console.WriteLine($"{boss.Name}: HP={boss.Health}, Stamina={boss.Stamina}");
                Console.WriteLine();
            }

            if (hero.Health <= 0 && boss.Health <= 0)
            {
                Console.WriteLine("Both Hero and Boss have fallen. It's a draw!");
            }
            else if (hero.Health <= 0)
            {
                Console.WriteLine("Hero has fallen. Boss Wins!");
            }
            else if (boss.Health <= 0)
            {
                Console.WriteLine("Boss has fallen. Hero Wins!");
            }

            Console.ReadKey();
        }
    }
}
