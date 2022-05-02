using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MastermindGame.Library
{
    // This class has all the logic and data necesary for playing the game.
    public class Mastermind
    {
        // Possible choices of colours for vs machine mode
        private List<string> availableColours = new List<string>()
        {
            "red",
            "orange",
            "yellow",
            "green",
            "blue",
            "purple",
            "pink",
            "brown",
            "white",
            "black",
            "gray",
        };

        // Fields
        // Guess is a nested list because player can introduce multiple guesses in the same try
        private List<List<string>> _guess;
        private List<string> _secret;

        // Constructors
        public Mastermind()
        {
            _guess = new List<List<string>>();
            _secret = new List<string>();
        }

        // Properties
        // The public properties are always strings because it's the way user interacts with console
        // Get and Set are functions that try to parse the input and convert it to lists
        public string Secret
        {
            get => ListToString(_secret);
            set => _secret = StringToList(value);
        }
        public string Guess
        {
            get
            {
                List<string> guesses = new List<string>();
                foreach (var g in _guess)
                {
                    guesses.Add(ListToString(g));
                }
                return string.Join(',', guesses);
            }
            set
            {
                MatchCollection matches = Regex.Matches(value, @"(\[.*?\])");
                foreach (Match match in matches)
                {
                    _guess.Add(StringToList(match.Groups[1].Value));
                }
            }
        }

        // Private methods
        // Method used to generate a random secret in vs machine mode
        public void SetRandomSecret()
        {
            Random random = new Random();
            int numberOfColours = random.Next(1, 5);
            for (int i = 0; i < numberOfColours; i++)
            {
                _secret.Add(availableColours.ElementAt(random.Next(0, availableColours.Count - 1)));
            }
        }

        // Method used to represent the data as string
        private string ListToString(List<string> l) => "[" + string.Join(",", l) + "]";

        // Method used to parse the data into a lists
        private List<string> StringToList(string s) => s.Replace("[", "").Replace("]", "").Split(',').Select(s => s.Trim().ToLower()).ToList();

        // This method counts how many colours are correct in the guesses
        private int CountCorrectColours()
        {
            int count = 0;
            foreach (List<string> g in _guess)
            {
                count += _secret.Intersect(g).Count(); ;
            }
            return count;
        }

        // Public methods
        // This method validates the input and sets a new secret based on that input
        public bool SetSecret(string newSecret)
        {
            if (string.IsNullOrEmpty(newSecret.Trim().Replace("[", "").Replace("]", "").Trim()))
                return false;
            else
            {
                Secret = newSecret;
                return true;
            }
        }

        // This method validates the input and sets a new guess based on that input, a regex is used for validate de format. The regex separates each guess and compares a composition of guesses with the input of the user
        public string SetGuess(string newGuess)
        {
            if (string.IsNullOrEmpty(newGuess.Trim().Replace("[", "").Replace("]", "").Trim()))
                return "Empty";
            else
            {
                MatchCollection matches = Regex.Matches(newGuess.Replace(" ", ""), @"(?:\[(?:\w,?)+\],?)");
                if (string.Join(',', matches.Select(m => m.Value.TrimEnd(',')).ToList()) != newGuess.Replace(" ", ""))
                    return "InvalidFormat";
                else
                {
                    Guess = newGuess;
                    return "Correct";
                }
            }
        }

        // This method counts how many colours are well placed. It compares the index in the secret with each the index in each guess
        public int CountWellPlacedColours()
        {
            int count = 0;
            foreach (List<string> g in _guess)
            {
                count += g.Where(c => _secret.IndexOf(c) == g.IndexOf(c)).Count();
            }
            return count;
        }

        // This method calculates how many misplaced colours exists. The difference between the correct and the well placed colours gives us that number
        public int CountCorrectMisplacedColours()
        {
            return CountCorrectColours() - CountWellPlacedColours();
        }

    }
}