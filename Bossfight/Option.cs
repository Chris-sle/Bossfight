namespace Bossfight
{
    internal class Option
    {
        public static string GetUserChoice(string question, string[] optionslist)
        {
            ConsoleKeyInfo key; // lagre key press
            int cursorPosition = 0; // 0 = Assignment 1, 1 = Assignment 2 = Assignment 3
            string[] options = optionslist;
            do
            {
                
                Console.Clear();
                Console.WriteLine(question);

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == cursorPosition)
                    {
                        Console.WriteLine($"> {options[i]}"); // Vise '>' på det valgte valge.
                    }
                    else
                    {
                        Console.WriteLine($"  {options[i]}");
                    }
                }

                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow)
                {
                    cursorPosition = (cursorPosition - 1 + options.Length) % options.Length; // Beveg seg oppover, og rundt om nødvendig.
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    cursorPosition = (cursorPosition + 1) % options.Length; // Beveg seg nedover, og rundt om nødvendig.
                }
            } while (key.Key != ConsoleKey.Enter);

            return options[cursorPosition];
        }
    }
}
