using System;
using Origam.twilio;

namespace origam.twilio.test
{
    public class TestSendSms : ITestSendSms
    {
        private readonly ITestSendSms _smsService;

        public TestSendSms(ITestSendSms smsService)
        {
            _smsService = smsService;
        }
        
        public void SendMessage(string recipient, string text)
        {
            Console.WriteLine("Sending SMS");
            _smsService.SendMessage(recipient, text);
            Console.WriteLine("SMS Sent");
        }
    }
}