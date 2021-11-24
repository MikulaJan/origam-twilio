using System;
using System.Reflection.Metadata.Ecma335;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Origam.twilio
{
    public class TwilioSendSms
    {
        public void SendSms(string from, string to, string body)
        {
            var accountSid = Environment.
                GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            var authToken = Environment.
                GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
            TwilioClient.Init(accountSid, authToken);
            var message = MessageResource.Create(
                body: body,
                from: new Twilio.Types.PhoneNumber(from),
                to: new Twilio.Types.PhoneNumber(to));
        }
    }
}