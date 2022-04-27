using MastermindLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        [DataRow("[yellow, blue, green ]")]
        [DataRow("yellow, blue, green   ")]
        [DataRow("yellow, blue,green")]
        [DataRow("yellow")]
        public void Return_OkMessage_When_Secret_Is_Registered(string secret)
        {
            string result = _mastermind.SetSecret(secret);
            Assert.AreEqual(result, "Your secret has been registered!");
        }

        [DataTestMethod]
        [DataRow("[yellow, blue, green ]")]
        [DataRow("yellow, blue, green   ")]
        [DataRow("yellow, blue,green")]
        [DataRow("yellow")]
        public void Return_OkMessage_When_Guess_Is_Registered(string guess)
        {
            string result = _mastermind.SetGuess(guess);
            string expectedResult = "[" + string.Join(",", guess.Replace("[", "").Replace("]", "").Split(',').Select(s => s.Trim()).ToList()) + "]";
            Assert.AreEqual(result, $"Your guess is: {expectedResult}");
        }
    }
}
