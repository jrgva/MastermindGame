using MastermindLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace MastermindGame.Tests
{
    [TestClass]
    public class MastermindGameTests
    {
        private readonly Mastermind _mastermind;

        public MastermindGameTests()
        {
            _mastermind = new Mastermind();
        }

        [TestMethod]
        public void Return_ErrorMessage_When_Secret_Is_Empty()
        {
            string result = _mastermind.SetSecret("");
            Assert.AreEqual(result, "Secret can't be empty!");
        }

        [TestMethod]
        public void Return_ErrorMessage_When_Guess_Is_Empty()
        {
            string result = _mastermind.SetGuess("");
            Assert.AreEqual(result, "Guess can't be empty!");
        }

        [DataTestMethod]
        [DataRow("yellow,blue")]
        public void Return_ErrorMessage_When_Guess_Format_Is_Invalid(string guess)
        {
            string result = _mastermind.SetGuess(guess);
            Assert.AreEqual(result, "Guess format should be: [colour1, colour2, ...], [colour1, colour2, ...], [...]");
        }

        [DataTestMethod]
        [DataRow("[yellow, blue, green ]")]
        [DataRow("yellow, blue, green   ")]
        [DataRow("yeLLow, blue,green")]
        [DataRow("YELLOW")]
        public void Return_OkMessage_When_Secret_Is_Registered(string secret)
        {
            string result = _mastermind.SetSecret(secret);
            Assert.AreEqual(result, "Your secret has been registered!");
        }

        [DataTestMethod]
        [DataRow("[YeLLoW, blue, green ]","[yellow,blue,green]")]
        [DataRow("yellow, blue, GREEN   ","[yellow,blue,green]")]
        [DataRow("yellow, BluE,green","[yellow,blue,green]")]
        [DataRow("yellow","[yellow]")]
        public void Return_OkMessage_When_Guess_Is_Registered(string guess, string expectedResult)
        {
            string result = _mastermind.SetGuess(guess);
            Assert.AreEqual(result, $"Your guess is: {expectedResult}");
        }

        [DataTestMethod]
        [DataRow("[yellow, blue, green]", "[green, red]", 1)]
        [DataRow("[yellow, blue, green]", "[green]", 1)]
        [DataRow("[yellow, blue, green]", "[red]", 0)]
        [DataRow("[yellow, blue, green]", "[blue, yellow]", 2)]
        [DataRow("[yellow, blue, green]", "[blue, green, grey, brown, white]", 2)]
        public void Return_Correct_Colours(string secret, string guess, int expectedResult)
        {
            _mastermind.SetSecret(secret);
            _mastermind.SetGuess(guess);
            int result = _mastermind.CountCorrectColours();
            Assert.AreEqual(result,expectedResult);
        }

        [DataTestMethod]
        [DataRow("[red, white, black]", "[yellow, blue]", 0)]
        [DataRow("[red, white, black]", "[red, white, black]", 3)]
        [DataRow("[red, white, black]", "[black, white, red]", 1)]
        [DataRow("[red, white, black]", "[brown, blue, black]", 1)]
        [DataRow("[red, white, black]", "[red, white]", 2)]
        public void Return_Well_PLaced_Colours(string secret, string guess, int expectedResult)
        {
            _mastermind.SetSecret(secret);
            _mastermind.SetGuess(guess);
            int result = _mastermind.CountWellPlacedColours();
            Assert.AreEqual(result, expectedResult);
        }
    }
}
