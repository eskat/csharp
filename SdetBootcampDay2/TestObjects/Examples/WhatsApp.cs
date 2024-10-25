using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;

namespace SdetBootcampDay2.TestObjects.Examples
{
    public class WhatsApp
    {
        public WhatsApp()
        {
        }

        public string GetMessages(IRecipient recipient)
        {
            return recipient.GetMessages();
        }
    }
}
