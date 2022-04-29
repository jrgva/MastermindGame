using MastermindGame.Library;
using System;

namespace MastermindGame.App
{
    internal class Program
    {
        static void Main()
        {
            LetsPlay();
        }

        private static void LetsPlay()
        {
            Mastermind mastermind = new Mastermind();
            UserInterface ui = new UserInterface();
            ui.ShowLogo();
            ui.ShowMenu();
            while (true)
            {
                string choice = Console.ReadLine();
                if (choice == "3")
                    break;
                else if (choice == "1")
                {
                    mastermind.SetRandomSecret();
                    ui.ShowHiddenSecret(mastermind.Secret);
                }
                else if (choice == "2")
                {
                    ui.InsertSecret();
                    while (!mastermind.SetSecret(Console.ReadLine()))
                    {
                        ui.EmptyInput("Secret");
                        ui.InsertSecret();
                    }
                }

                ui.InsertGuess();
                string resultGuess = mastermind.SetGuess(Console.ReadLine());
                while (resultGuess != "Correct")
                {
                    if (resultGuess == "Empty")
                        ui.EmptyInput("Secret");
                    else if (resultGuess == "InvalidFormat")
                        ui.IncorrectGuessFormat();
                    ui.InsertSecret();
                    resultGuess = mastermind.SetGuess(Console.ReadLine());
                }
                ui.ShowResult(mastermind.Secret, mastermind.Guess, mastermind.CountWellPlacedColours(), mastermind.CountCorrectMisplacedColours());
                ui.TryAgain();
                ui.ShowMenu();
            }
        }
    }
}
