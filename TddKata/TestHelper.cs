using NUnit.Framework;

namespace TddKata
{
    public static class TestHelper
    {
        public static void ShouldReturn(this string input, int expected)
        {
            // arrange
            var calculator = new Calculator();
            // act
            var actual = calculator.Add(input);
            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}