using Moq;
using NUnit.Framework;
using SdetBootcampDay2.TestObjects.Examples;

namespace SdetBootcampDay2.Examples
{
    [TestFixture]
    public class Examples02
    {
        [Test]
        public void ExampleNotUsingAMock()
        {
            var whatsApp = new WhatsApp();
            var recipient = new Recipient();

            string messages = whatsApp.GetMessages(recipient);

            Assert.That(messages, Is.EqualTo("REAL messages"));
        }

        [Test]
        public void ExampleUsingAMock()
        {
            var whatsApp = new WhatsApp();
            var recipient = new Mock<IRecipient>();

            // Occurs because method is not overrideable. Need to implement an Interface or have method be virtual (less elegant)
            recipient.Setup(o => o.GetMessages()).Returns("MOCKED messages");

            string messages = whatsApp.GetMessages(recipient.Object);

            // Let's see what happens when we run this test...
            Assert.That(messages, Is.EqualTo("MOCKED messages"));

            // Verification that mock method was called exactly once (Alt Times.Exactly(1))
            recipient.Verify(r => r.GetMessages(), Times.Once());
        }
    }
}
