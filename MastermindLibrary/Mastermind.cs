using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MastermindGame.Library
{
    public class Mastermind
    {
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
        // The public properties are always strings
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

        public void SetRandomSecret()
        {
            Random random = new Random();
            int numberOfColours = random.Next(1, 5);
            for (int i = 0; i < numberOfColours; i++)
            {
                _secret.Add(availableColours.ElementAt(random.Next(0, availableColours.Count - 1)));
            }
        }

        private string ListToString(List<string> l) => "[" + string.Join(",", l) + "]";

        private List<string> StringToList(string s) => s.Replace("[", "").Replace("]", "").Split(',').Select(s => s.Trim().ToLower()).ToList();

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
        public bool SetSecret(string newSecret)
        {
            if (String.IsNullOrEmpty(newSecret.Trim().Replace("[", "").Replace("]", "").Trim()))
                return false;
            else
            {
                Secret = newSecret;
                return true;
            }
        }

        public string SetGuess(string newGuess)
        {
            if (String.IsNullOrEmpty(newGuess.Trim().Replace("[", "").Replace("]", "").Trim()))
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

        public int CountWellPlacedColours()
        {
            int count = 0;
            foreach (List<string> g in _guess)
            {
                count += g.Where(c => _secret.IndexOf(c) == g.IndexOf(c)).Count();
            }
            return count;
        }

        public int CountCorrectMisplacedColours()
        {
            return CountCorrectColours() - CountWellPlacedColours();
        }

    }
}