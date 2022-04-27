using System;
using System.Collections.Generic;
using System.Linq;

namespace MastermindLibrary
{
    public class Mastermind
    {
        // Fields
        private List<string> guess;
        private List<string> secret;

        // Constructors
        public Mastermind() { }

        // Properties
        public string Secret 
        {
            get => ListToString(secret);
            set => secret = StringToList(value);
        }
        public string Guess
        {
            get => ListToString(guess);
            set => guess = StringToList(value);
        }

        // Public methods
        public string SetSecret(string newSecret)
        {
            if (String.IsNullOrEmpty(newSecret.Trim().Replace("[","").Replace("]","").Trim()))
                return "Secret can't be empty!";
            else
            {
                Secret = newSecret;
                return "Your secret has been registered!";
            }
        }

        public string SetGuess(string newGuess)
        {
            if (String.IsNullOrEmpty(newGuess.Trim().Replace("[", "").Replace("]", "").Trim()))
                return "Guess can't be empty!";
            else
            {
                Guess = newGuess;
                return $"Your guess is: {Guess}";
            }
        }

        // Private methods
        private List<string> StringToList(string s)
        {
            return s.Replace("[", "").Replace("]", "").Split(',').Select(s => s.Trim()).ToList();
        }

        private string ListToString(List<string> l)
        {
            return "[" + string.Join(",", l) + "]";
        }


    }
}