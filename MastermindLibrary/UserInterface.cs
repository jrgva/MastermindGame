using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MastermindGame.Library
{
    public class UserInterface
    {
        // Constants
        private const string logo = "-------------------------------------------------------------------------------\n" +
                                    "#################################  MASTERMIND  ################################\n" +
                                    "-------------------------------------------------------------------------------";

        private const string menu = "Introduce the number to select one game mode:\n" +
                                    "1. Againt the machine\n" +
                                    "2. Against another player";

        // Public methods
        public void ShowLogo() => Console.WriteLine(logo);

        public void ShowMenu() => Console.WriteLine(menu);

        public void ShowSecret(string secret)
        {
            Console.WriteLine(Regex.Replace(secret, "[a-z]", "*"));
        }

        public void ShowGuess(string guess) => Console.WriteLine("Your guess is: " + guess);

        public void SecretRegistered() => Console.WriteLine("Your secret has been registered!");

        public void IncorrectGuessFormat() => Console.WriteLine("Guess format should be: [colour1, colour2, ...], [colour1, colour2, ...], [...]");





    }
}
