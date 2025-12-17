using System.Reflection;
using Days;
using NUnit.Framework;

namespace Examples
{
    public class Day2Test
    {
        IDay day;

        [SetUp]
        public void Setup()
        {
            day = new Day2();
        }

        [Test]
        public void ExampleA()
        {
            string pathInput = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Inputs", $"Day2", $"ExampleA.txt");

            string answerA = day.AnswerA(pathInput);
            string expectedAnswerA = "1227775554";

            Assert.That(answerA, Is.EqualTo(expectedAnswerA));
        }

        [Test]
        public void ExampleB()
        {
            string pathInput = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Inputs", $"Day2", $"ExampleB.txt");

            string answerB = day.AnswerB(pathInput);
            string expectedAnswerB = "4174379265";

            Assert.That(answerB, Is.EqualTo(expectedAnswerB));
        }
    }
}