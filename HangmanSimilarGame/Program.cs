using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanSimilarGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string answer;
            do
            {
                string[] words = { "one", "two", "three", "four", "six", "seven", "eight", "nine" };
                Console.WriteLine("Welcome to Hangman-similar game, guess the world (a number from 1 to 9) by typing the letters.");

                Random random = new Random();
                int randomIndex = random.Next(0, 8);
                string selectedWord = words[randomIndex];
                string hiddenWorld = "";
                int amountOfGuesses = 0;

                for (int i = 0; i < selectedWord.Length; i++)
                {
                    hiddenWorld += "*";
                }
                while (hiddenWorld.Contains("*"))
                {
                    Console.WriteLine("World: {0}", hiddenWorld);
                    Console.Write("Guess a letter >>");

                    char letter = char.Parse(Console.ReadLine());
                    bool containsLetter = false;


                    for (int i = 0; i < selectedWord.Length; i++)
                    {
                        if (selectedWord[i] == letter)
                        {
                            hiddenWorld = hiddenWorld.Remove(i, 1);
                            hiddenWorld = hiddenWorld.Insert(i, letter.ToString());
                            containsLetter = true;
                        }
                    }
                    if (containsLetter == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Letter {0} is in the world", letter);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sorry, letter {0} is not in the world", letter);
                    }
                    Console.ResetColor();
                    amountOfGuesses++;
                }
                Console.WriteLine("Congratulations!!! You win :) the world was {0}", selectedWord);
                Console.WriteLine("You guessed {0} times", amountOfGuesses);
                Console.WriteLine("Would you like to play again? :) Type Y or y to start over or any other sign to quit");
                answer = Console.ReadLine();
                Console.ReadKey();
            } while (answer.ToLower() == "y");
        }
    }
}
