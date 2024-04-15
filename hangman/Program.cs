using System;
using System.Collections.Generic;

class HangmanGame
{
    static List<string> words = new List<string>
    {
        "Apple", "Banana", "Orange", "Mango", "Strawberry",
        "Pineapple", "Watermelon", "Grape", "Lemon", "Peach",
        "Kiwi", "Blueberry", "Raspberry", "Blackberry", "Coconut",
        "Cherry", "Papaya", "Avocado", "Guava", "Apricot",
        "Fig", "Plum", "Cranberry", "Lychee", "Pomegranate",
        "Lime", "Cantaloupe", "Dragonfruit", "Passionfruit", "Tangerine",
        "Grapefruit", "Pear", "Nectarine", "Persimmon", "Starfruit",
        "Jackfruit", "Durian", "Gooseberry", "Elderberry", "Kumquat"
    };

    static Random random = new Random();
    static string secretWord = "";

    static void Main(string[] args)
    {
        bool playAgain = true;
        while (playAgain)
        {
            secretWord = words[random.Next(words.Count)];
            PlayGame();

            Console.WriteLine("Do you want to play again? (yes/no)");
            string response = Console.ReadLine().ToLower();
            playAgain = (response == "yes" || response == "y");
        }

        Console.WriteLine("Thank you for playing!");
    }

    static void PlayGame()
    {
        char[] guessedLetters = new char[secretWord.Length];
        for (int i = 0; i < secretWord.Length; i++)
        {
            guessedLetters[i] = '_';
        }

        int attemptsLeft = 7;
        while (attemptsLeft > 0)
        {
            Console.WriteLine($"Attempts left: {attemptsLeft}");
            Console.WriteLine("Enter your guess (letter or word):");
            string guess = Console.ReadLine().ToLower();

            if (guess.Length == 1)
            {
                char letterGuess = guess[0];
                if (char.IsLetter(letterGuess))
                {
                    bool found = false;
                    for (int i = 0; i < secretWord.Length; i++)
                    {
                        if (secretWord[i] == letterGuess)
                        {
                            guessedLetters[i] = letterGuess;
                            found = true;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("Incorrect guess!");
                        attemptsLeft--;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid letter.");
                }
            }
            else if (guess.Length > 1)
            {
                if (guess == secretWord)
                {
                    guessedLetters = secretWord.ToCharArray();
                }
                else
                {
                    Console.WriteLine("Incorrect guess!");
                    attemptsLeft--;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid guess.");
            }

            Console.WriteLine("Current word: " + new string(guessedLetters));

            if (new string(guessedLetters) == secretWord)
            {
                Console.WriteLine("Congratulations! You guessed the word!");
                return;
            }
        }

        Console.WriteLine("You ran out of attempts! The word was: " + secretWord);
    }
}
