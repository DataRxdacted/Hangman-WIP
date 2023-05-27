using ConsoleApp1;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
internal class Program
{
    private static void Main(string[] args)
    {
        int numberOfLetters = 0;
        string[] hiddenWord = new string[12];
        string[] lettersOfRandomWord = new string[12];
        string[] lettersOfRandomWordGLOBAL = new string[12];
        string wordCheck = "";
        string[] words = new string[10] { "daniel", "faggot", "gay", "what", "bombastic", "criminal", "offensive", "nigger", "test", "oesophagus" };
        Random RandNumber = new Random();
        string randomWord = words[RandNumber.Next(0, words.Length)];
        Console.WriteLine(randomWord);
        Console.WriteLine("Would you like to play: Y / N ");
        string userChoice = Console.ReadLine();
        string userGuess = "";
        string foundLetter = "";
        bool hiddenCheck = true;
        string completedWord = "";
        char correctLetterCHAR = 'C';
        string correctLetter = "";

        char[] randomWordLettersInAnArray = randomWord.ToCharArray();
        foreach (char character in randomWordLettersInAnArray)
        {

            string letter = character.ToString();
            lettersOfRandomWord[numberOfLetters] = letter;
            numberOfLetters = numberOfLetters + 1;
        }
        lettersOfRandomWordGLOBAL = lettersOfRandomWord;

        while (userChoice == "Y")
        {




            for (int attempts = 0; attempts < 3; attempts++)
            {
                Console.WriteLine("You have used {0}", attempts);


                if (userGuess == "")
                {
                    Console.WriteLine("Enter your guess: ");
                    userGuess = Console.ReadLine();

                    for (int i = 0; i < numberOfLetters; i++)
                    {
                        if (hiddenCheck)
                        {
                            hiddenWord[i] = "_";
                        }
                    }
                    hiddenCheck = false;
                    for (int i = 0; i < numberOfLetters; i++)
                    {
                        if (userGuess == lettersOfRandomWord[i])
                        {
                            Console.WriteLine("You guessed the right letter! ");
                            foundLetter = lettersOfRandomWord[i];
                            hiddenWord[i] = foundLetter;
                            wordCheck = wordCheck + hiddenWord[i];
                            attempts = attempts - 1;
                            lettersOfRandomWord[i] = "FOUND";

                            userGuess = "";


                        }

                        // foreach (string name in hiddenWord)
                        // {
                        //     Console.WriteLine("test {0}", name);
                        //      Console.Write("pass 5");
                        //    }
                    }

                    for (int i = 0; i < numberOfLetters; i++)
                    {
                        if (userGuess != lettersOfRandomWord[i])
                        {
                            userGuess = "";
                        }
                        if (i == numberOfLetters && userGuess == "")
                        {
                            Console.WriteLine("Incorrect guess");
                        }
                    }
                }

                for (int i = 0; i < hiddenWord.Length; i++)
                {
                    Console.WriteLine(hiddenWord[i]);
                }

                for (int i = 0; i < wordCheck.Length; i++)
                {
                    if (userChoice == "Y")
                    {
                        correctLetterCHAR = wordCheck[i];
                        correctLetter = Convert.ToString(correctLetter);
                        completedWord = completedWord + wordCheck[i];


                        if (completedWord == randomWord)
                        {
                            Console.WriteLine("you won");
                            break;
                        }
                    }
                }
                Console.WriteLine(completedWord);
            }

            Console.WriteLine("you got it wrong");
            Console.WriteLine("Would you like to continue play: Y / N ");
            userChoice = Console.ReadLine();
        }
    }
}