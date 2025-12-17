using System.Reflection;
using Days;
using NUnit.Framework;

namespace Examples
{
    public class Day6Test
    {
        IDay day;

        [SetUp]
        public void Setup()
        {
            day = new Day6();
        }

        [Test]
        public void ExampleA()
        {
            string pathInput = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Inputs", $"Day6", $"ExampleA.txt");

            string answerA = day.AnswerA(pathInput);
            string expectedAnswerA = "4277556";

            Assert.That(answerA, Is.EqualTo(expectedAnswerA));
        }

        [Test]
        public void ExampleB()
        {
            string pathInput = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Inputs", $"Day6", $"ExampleB.txt");

            string answerB = day.AnswerB(pathInput);
            string expectedAnswerB = "3263827";

            Assert.That(answerB, Is.EqualTo(expectedAnswerB));
        }
    }
}