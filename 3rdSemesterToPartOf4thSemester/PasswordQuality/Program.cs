#nullable disable
namespace PasswordQuality
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int countChars = 0, countCharsUpper = 0, countCharsLower = 0, countDigits = 0;
            bool isLongEnough = false, hasTwoChars = false, hasTwoDigits = false, hasUpperAndLowerCase = false, hasSpecialChar = false, isInbetweenCorrect = false, isCorrect = false;
            do
            {
                countChars = 0;
                countCharsLower = 0;
                countCharsUpper = 0;
                countDigits = 0;
                Console.Write("Eingabetext: ");
                input = Console.ReadLine();

                for (int i = 0; i < input.Length; i++)
                {
                    if (input.Length >= 8)
                    {
                        isLongEnough = true;
                    }
                    if (input[i] >= 'A' && input[i] <= 'Z')
                    {
                        countCharsUpper++;
                        countChars++;
                    }
                    else if (input[i] >= 'a' && input[i] <= 'z')
                    {
                        countCharsLower++;
                        countChars++;
                    }
                    if (countChars >= 2)
                    {
                        hasTwoChars = true;
                    }
                    if (input[i] >= '0' && input[i] <= '9')
                    {
                        countDigits++;
                    }
                    if (countDigits >= 2)
                    {
                        hasTwoDigits = true;
                    }
                    if (countCharsLower >= 1 && countCharsUpper >= 1)
                    {
                        hasUpperAndLowerCase = true;
                    }
                    if (i >= 1 && i <= input.Length - 1)
                    {
                        if (input[i] >= '0' && input[i] <= '9' || input[i] >= '!' && input[i] <= '@')
                        {
                            hasSpecialChar = true;
                            isInbetweenCorrect = true;
                        }
                    }
                }

                if (!isLongEnough)
                {
                    Console.WriteLine("Passwort zu kurz!");
                }
                else if (!hasTwoChars)
                {
                    Console.WriteLine("Keine 2 Buchstaben!");
                }
                else if (!hasTwoDigits)
                {
                    Console.WriteLine("Keine 2 Ziffern!");
                }
                else if (!hasUpperAndLowerCase)
                {
                    Console.WriteLine("Ein Klein- oder Großbuchstabe fehlt!");
                }
                else if (!hasSpecialChar)
                {
                    Console.WriteLine("Es fehlt ein Sonderzeichen!");
                }
                else if (!isInbetweenCorrect)
                {
                    Console.WriteLine("Es fehlt ein Sonderzeichen oder eine Ziffer inmitten des Passwortes!");
                }
                if (isLongEnough && hasTwoChars && hasTwoDigits && hasUpperAndLowerCase && hasSpecialChar && isInbetweenCorrect)
                {
                    isCorrect = true;
                }
            } while (!isCorrect);



            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}
