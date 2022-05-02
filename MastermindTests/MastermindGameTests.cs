using MastermindGame.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MastermindGame.Tests
{
    // This class has all the unit tests developed for Mastermind class
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
            bool result = _mastermind.SetSecret("");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Return_ErrorMessage_When_Guess_Is_Empty()
        {
            string result = _mastermind.SetGuess("");
            Assert.AreEqual(result,"Empty");
        }

        [DataTestMethod]
        [DataRow("yellow,blue")]
        [DataRow("yellow")]
        [DataRow("[yellow, blue, [blue, green]")]
        [DataRow("[yellow, blue], [blue, green")]
        [DataRow("[yellow], blue,[blue, green]")]
        [DataRow("[yellow], [blue][blue, green]")]
        public void Return_ErrorMessage_When_Guess_Format_Is_Invalid(string guess)
        {
            string result = _mastermind.SetGuess(guess);
            Assert.AreEqual(result, "InvalidFormat");
        }

        [DataTestMethod]
        [DataRow("[yellow, blue, green ]")]
        [DataRow("yellow, blue, green   ")]
        [DataRow("yeLLow, blue,green")]
        [DataRow("YELLOW")]
        public void Return_OkMessage_When_Secret_Is_Registered(string secret)
        {
            bool result = _mastermind.SetSecret(secret);
            Assert.IsTrue(result);
        }

        [DataTestMethod]
        [DataRow("[YeLLoW, blue, green ]")]
        [DataRow("[yellow, blue, GREEN    ]   ")]
        [DataRow("[yellow], [BluE],[green]")]
        [DataRow("[yellow,blue], [blue, green, red]")]
        [DataRow("[yellow, blue], [blue, green ]")]
        [DataRow("[yellow], [blue, green,red], [white, brown], [black, pink, purple], [orange, gray]")]
        public void Return_OkMessage_When_Guess_Is_Registered(string guess)
        {
            string result = _mastermind.SetGuess(guess);
            Assert.AreEqual(result, "Correct");
        }

        [DataTestMethod]
        [DataRow("[blue, red, green, pink]", "[yellow, red, blue, purple]", 1)]
        [DataRow("[blue, red, green, pink]", "[blue, red, green, pink]", 4)]
        [DataRow("[blue, red, green, pink]", "[pink, blue, red, green]", 0)]
        [DataRow("[blue, red, green, pink]", "[blue, red]", 2)]
        [DataRow("[blue, red, green, pink]", "[green, pink]", 0)]
        [DataRow("[blue, red, green, pink]", "[red, yellow], [blue, red]", 2)]
        [DataRow("[red, white, black]", "[red, white],[blue, yellow, black]", 3)]
        [DataRow("[red, white, black]", "[red, white],[red, white, black]", 5)]
        [DataRow("[red, white, black]", "[red, green],[blue, white, green],[pink, gray, black]", 3)]
        [DataRow("[red, white, black]", "[blue],[green],[red],[white, blue, gray],[pink, brown, black, red, blue]", 2)]
        public void Return_Well_Placed_Colours(string secret, string guess, int expectedResult)
        {
            _mastermind.SetSecret(secret);
            _mastermind.SetGuess(guess);
            int result = _mastermind.CountWellPlacedColours();
            Assert.AreEqual(result, expectedResult);
        }

        [DataTestMethod]
        [DataRow("[blue, red, green, pink]", "[yellow, red, blue, purple]", 1)]
        [DataRow("[blue, red, green, pink]", "[blue, red, green, pink]", 0)]
        [DataRow("[blue, red, green, pink]", "[pink, blue, red, green]", 4)]
        [DataRow("[blue, red, green, pink]", "[blue, red]", 0)]
        [DataRow("[blue, red, green, pink]", "[green, pink]", 2)]
        [DataRow("[blue, red, green, pink]", "[red, yellow], [blue, red]", 1)]
        [DataRow("[red, white, black]", "[red, white],[blue, yellow, black]", 0)]
        [DataRow("[red, white, black]", "[red, white],[red, white, black]", 0)]
        [DataRow("[red, white, black]", "[red, green],[blue, pink, white],[pink, gray, black]", 1)]
        [DataRow("[red, white, black]", "[blue],[green, red],[white, blue, gray],[pink, brown, black, red, blue]", 3)]
        public void Return_Correct_Misplaced_Colours(string secret, string guess, int expectedResult)
        {
            _mastermind.SetSecret(secret);
            _mastermind.SetGuess(guess);
            int result = _mastermind.CountCorrectMisplacedColours();
            Assert.AreEqual(result, expectedResult);
        }
    }
}
