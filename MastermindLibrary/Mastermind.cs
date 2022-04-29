using System;
using System.Collections.Generic;
using System.Linq;

namespace MastermindLibrary
{
    public class Mastermind
    {
        // Fields
        // Guess is a nested list because player can introduce multiple guesses in the same try
        private List<List<string>> _guess;
        private List<string> _secret;

        // Constructors
        public Mastermind() { }

        // Properties
        // The public properties are always strings
        public string Secret 
        {
            get => ListToString(_secret);
            set => _secret = value.Replace("[", "").Replace("]", "").Split(',').Select(s => s.Trim().ToLower()).ToList();
        }
        public string Guess
        {
            get
            {
                List<string> guesses = new List<string>();
                foreach(var g in _guess)
                {
                    guesses.Add(string)
                }
                return
            }
            set => _guess = StringToList(value);
        }

        private string ListToString(List<string> l)
        {
            return "[" + string.Join(",", l) + "]";
        }

        private int CountCorrectColours()
        {
            return _secret.Intersect(_guess).Count();
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

        public int CountWellPlacedColours()
        {
            return _guess.Where(c => _secret.IndexOf(c) == _guess.IndexOf(c)).Count();
        }

        public int CountCorrectMisplacedColours()
        {
            return CountCorrectColours() - CountWellPlacedColours();
        }
        
    }
}