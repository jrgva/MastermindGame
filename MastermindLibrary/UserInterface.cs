using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MastermindGame.Library
{
    // This class has all the messages and interaction that the console gives to the user
    public class UserInterface
    {
        // Constants
        private const string logo = "-------------------------------------------------------------------------------\n" +
                                    "#################################  MASTERMIND  ################################\n" +
                                    "-------------------------------------------------------------------------------";

        private const string menu = "Insert the number to select one game mode:\n" +
                                    "1. Againt the machine\n" +
                                    "2. Against another player\n" +
                                    "3. Exit";

        // Public methods
        public void ShowLogo() => Console.WriteLine(logo);

        public void ShowMenu() => Console.WriteLine(menu);

        public void InsertSecret() => Console.WriteLine("Insert your secret:");

        public void ShowHiddenSecret(string secret) => Console.WriteLine(Regex.Replace(secret, "[a-z]", "*"));

        public void InsertGuess() => Console.WriteLine("Insert your guess:");

        public void SecretRegistered() => Console.WriteLine("Your secret has been registered!");

        public void IncorrectGuessFormat() => Console.WriteLine("Guess format should be: [colour1, colour2, ...], [colour1, colour2, ...], [...]");

        public void EmptyInput(string input) => Console.WriteLine($"{input} can't be empty!");

        public void ShowResult(string secret, string guess, int wellPlaced, int correctMisplaced) => Console.WriteLine( $"\nThe secret was: {secret}\n" +
                                                                                                                        $"Your guess was: {guess}\n" +
                                                                                                                        $"Well placed colours: {wellPlaced}\n" +
                                                                                                                        $"Correct misplaced colours: {correctMisplaced}\n");
        public void TryAgain() => Console.WriteLine("Let's try again!\n");
    }
}
