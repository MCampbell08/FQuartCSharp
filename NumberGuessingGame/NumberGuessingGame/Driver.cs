using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame
{
    public class Driver
    {
        #region Private Variables
        private string input;
        private int parsedInput;
        private int numberOfGuesses = 0;
        private bool isValid = false;
        private bool duplicate = false;
        private int[] collOfGuesses = new int[MAX_ATTEMPTS];
        #endregion

        #region Difficulty Limits
        private const int MINIMUM = 1;
        private const int MAX_EASY = 10;
        private const int MAX_MEDIUM = 50;
        private const int MAX_HARD = 100;
        private const int MAX_ATTEMPTS = 5;
        #endregion

        public void Run()
        {
            ChoiceOfDifficulty();
        }

        public void ChoiceOfDifficulty()
        {
            Console.Write("Please select a difficulty. 1(Easy), 2(Medium), 3(Hard): ");
            input = Console.ReadLine();
            isValid = int.TryParse(input, out parsedInput);
            numberOfGuesses = 0;
            if (isValid)
            {
                if (parsedInput == 1)
                {
                    Game(Difficulty.Easy);
                }
                else if (parsedInput == 2)
                {
                    Game(Difficulty.Medium);
                }
                else if (parsedInput == 3)
                {
                    Game(Difficulty.Hard);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
                Run();
            }
        }

        private bool CheckParse(bool parsedOutcome)
        {
            if (!parsedOutcome)
            {
                Console.WriteLine("Invalid input read.");
                Console.WriteLine("You've currently used up only [" + numberOfGuesses + "] of guesses.");
                return false;
            }
            return true;
        }

        private bool CheckGuess(int num)
        {
            if (num == MAX_ATTEMPTS)
            {
                Console.WriteLine("You have used up all your attempts.");
                return true;
            }
            return false;
        }

        private bool CheckDup(int numInput)
        {
            for (int i = 0; i < numberOfGuesses; ++i)
            {
                if (collOfGuesses[i] == numInput)
                {
                    Console.WriteLine("That friend is a duplicate guess, select a new number...");
                    duplicate = true;
                    --numberOfGuesses;
                    return true;
                }
            }
            duplicate = false;
            return false;
        }

        private bool LowOrHigh(int compNum, int numInput)
        {
            if (CheckDup(numInput)) return false;
            if (numInput != compNum)
            {
                if (numInput < compNum)
                {
                    Console.WriteLine("Input was too low! Try again!");
                }
                else if (numInput > compNum)
                {
                    Console.WriteLine("Input was too high! Try again!");
                }
                Console.WriteLine("You've currently used up only [" + numberOfGuesses + "] of your guesses.");
                collOfGuesses[numberOfGuesses-1] = numInput;
                return true;
            }
            Console.WriteLine("You guessed it! It only took you [" + numberOfGuesses + "] times. Good job!");
            collOfGuesses[numberOfGuesses-1] = numInput;
            return false;
        }

        private void Restart()
        {
            Console.WriteLine("Would you like to restart the game? (\"y\" for yes and \"n\") for no.");
            string restartInput = Console.ReadLine();
            if (restartInput == "y" || restartInput == "Y")
            {
                Run();
            }
            else if (restartInput == "n" || restartInput == "N")
            {
                Console.WriteLine("Goodbye.");
            }
            else
            {
                Console.WriteLine("Incorrect input, try again.");
                Restart();
            }
        }

        private void Game(Difficulty difficultyChoice)
        {
            int i = (int)difficultyChoice;
            Random rand = new Random();
            int compNum;
            bool done = false;
            bool validParse = false;
            string numberSelection;
            int parsedNumSelection;
            switch (i)
            {
                case 0:
                    {
                        compNum = rand.Next(1, 11);
                        while (!done)
                        {
                            Console.Write("Please select a number of 1-10 (inclusively): ");
                            numberSelection = Console.ReadLine();
                            validParse = int.TryParse(numberSelection, out parsedNumSelection);
                            if (CheckParse(validParse))
                            {
                                if (parsedNumSelection >= MINIMUM || parsedNumSelection <= MAX_EASY)
                                {
                                    ++numberOfGuesses;
                                    if (CheckGuess(numberOfGuesses) && parsedNumSelection != compNum)
                                    {
                                        done = true;
                                    }
                                    if (!LowOrHigh(compNum, parsedNumSelection))
                                    {
                                        if (!duplicate)
                                        {
                                            done = true;
                                            Restart();
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Input was not in the selected range, try again.");
                                }
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        compNum = rand.Next(1, 51);
                        while (!done)
                        {
                            Console.Write("Please select a number of 1-50 (inclusively): ");
                            numberSelection = Console.ReadLine();
                            validParse = int.TryParse(numberSelection, out parsedNumSelection);
                            if (CheckParse(validParse))
                            {
                                if (parsedNumSelection >= MINIMUM || parsedNumSelection <= MAX_MEDIUM)
                                {
                                    ++numberOfGuesses;
                                    if (CheckGuess(numberOfGuesses) && parsedNumSelection != compNum)
                                    {
                                        done = true;
                                    }
                                    if (!LowOrHigh(compNum, parsedNumSelection))
                                    {
                                        if (!duplicate)
                                        {
                                            done = true;
                                            Restart();
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Input was not in the selected range, try again.");
                                }
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        compNum = rand.Next(1, 101);
                        while (!done)
                        {
                            Console.Write("Please select a number of 1-100 (inclusively): ");
                            numberSelection = Console.ReadLine();
                            validParse = int.TryParse(numberSelection, out parsedNumSelection);
                            if (CheckParse(validParse))
                            {
                                if (parsedNumSelection >= MINIMUM || parsedNumSelection <= MAX_HARD)
                                {
                                    ++numberOfGuesses;
                                    if (CheckGuess(numberOfGuesses) && parsedNumSelection != compNum)
                                    {
                                        done = true;
                                    }
                                    if (!LowOrHigh(compNum, parsedNumSelection))
                                    {
                                        if (!duplicate)
                                        {
                                            done = true;
                                            Restart();
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Input was not in the selected range, try again.");
                                }
                            }
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }

            }
        }

    }
}
