using System.Reflection;
using Days;
using NUnit.Framework;

namespace Examples
{
    public class Day1Test
    {
        IDay day;

        [SetUp]
        public void Setup()
        {
            day = new Day1();
        }

        [Test]
        public void ExampleA()
        {
            string pathInput = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Inputs", $"Day1", $"ExampleA.txt");

            int answerA = day.AnswerA(pathInput);
            int expectedAnswerA = 3;

            Assert.That(answerA, Is.EqualTo(expectedAnswerA));
        }

        [Test]
        public void ExampleB()
        {
            string pathInput = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Inputs", $"Day1", $"ExampleB.txt");

            int answerB = day.AnswerB(pathInput);
            int expectedAnswerB = 6;

            Assert.That(answerB, Is.EqualTo(expectedAnswerB));
        }
    }
}