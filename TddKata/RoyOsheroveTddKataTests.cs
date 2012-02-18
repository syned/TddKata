using System;
using System.Text;
using NUnit.Framework;
using FluentAssertions;

namespace TddKata
{
    public class RoyOsheroveTddKataTests
    {
        [Test]
        public void Given_empty_string_should_return_0()
        {
            "0".ShouldReturn(0);
        }

        [Test]
        public void Given_7_should_return_7()
        {
            // arrange
            "7".ShouldReturn(7);
            // act
            // assert
        }

        [Test]
        public void Given_two_numbers_should_return_sum()
        {
            // arrange
            "1,2".ShouldReturn(3);
            // act
            // assert
        }

        [Test]
        public void Given_unlimited_numbers_count_should_return_sum()
        {
            // arrange
            "1,2,3,4".ShouldReturn(10);
            // act
            // assert
        }

        [Test]
        public void given_new_line_should_support_as_a_delimiter()
        {
            // arrange
            "1,2\n3,4\n5".ShouldReturn(15);
            // act
            // assert
        }

        [Test]
        public void Should_support_different_delimiters()
        {
            // arrange
            "//;\n1;2;3".ShouldReturn(6);
            // act
            // assert
        }

        [Test]
        public void Given_negative_number_should_throw_exception()
        {
            // arrange
            Action a = () => "1,-2".ShouldReturn(1);
            // act
            // assert
            a.ShouldThrow<ArgumentException>().And.Message.Should().Contain("negatives not allowed");
        }

        [Test]
        public void Given_negative_number_should_throw_exception_and_message_should_include_negative_number()
        {
            // arrange
            Action a = () => "1,-2".ShouldReturn(1);
            // act
            // assert
            a.ShouldThrow<ArgumentException>().And.Message.Should().Contain("-2");
        }

        [Test]
        public void Given_negative_number_should_throw_exception_and_message_should_include_all_negative_numbers()
        {
            // arrange
            Action a = () => "1,-2,-100,5".ShouldReturn(1);
            // act
            // assert
            a.ShouldThrow<ArgumentException>().And.Message.Should().Contain("-2, -100");
        }

        [Test]
        public void Given_number_bigger_than_1000_should_ignore_it()
        {
            // arrange
            "1,1001,2".ShouldReturn(3);
            // act
            // assert
        }

        [Test]
        public void Should_support_delimiters_of_any_length()
        {
            // arrange
            "//[***]\n1***2***4".ShouldReturn(7);
            // act
            // assert
        }

        [Test]
        public void Should_support_many_defined_delimiters()
        {
            // arrange
            "//[*][%]\n1%2*3".ShouldReturn(6);
            // act
            // assert
        }
    }
}
