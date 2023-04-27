using App.Core;

namespace App.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CanListExpectedKeys()
        {
            var repository = new MultiValueRepository();
            var parserService = new ParserService(repository);
            parserService.ProcessInput("seed");

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                parserService.ProcessInput("keys");
  
                var output = sw.ToString();

                Assert.That(output, Is.EqualTo("foo\r\nbaz\r\n\r\n"));
            }
        }

        [Test]
        public void KeyExistReturnsTrue()
        {
            var repository = new MultiValueRepository();
            var parserService = new ParserService(repository);
            parserService.ProcessInput("seed");

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                parserService.ProcessInput("KeyExists foo");

                var output = sw.ToString();

                Assert.That(output, Is.EqualTo("true\r\n\r\n"));
            }
        }

        [Test]
        public void KeyExistReturnsFalse()
        {
            var repository = new MultiValueRepository();
            var parserService = new ParserService(repository);
            parserService.ProcessInput("seed");

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                parserService.ProcessInput("KeyExists acme");

                var output = sw.ToString();

                Assert.That(output, Is.EqualTo("false\r\n\r\n"));
            }
        }
    }
}