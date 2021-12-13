using System;
using Origam.twilio;

namespace origam.twilio.test
{
    public interface ITestSendSms
    {
        void SendMessage(string recipient, string text);
    }
}