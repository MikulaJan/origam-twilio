#region license
/*
Copyright 2005 - 2021 Advantage Solutions, s. r. o.

This file is part of ORIGAM (http://www.origam.org).

ORIGAM is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

ORIGAM is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with ORIGAM. If not, see <http://www.gnu.org/licenses/>.
*/
#endregion
using System;
using Microsoft.Extensions.Configuration;
using Origam.Sms;
using Origam.Twilio;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Origam.Twilio
{
    public class TwilioSendSms : ISmsService
    {
        private static TwilioSettings settings;

        private static TwilioSettings Settings
        {
            get
            {
                if (settings == null)
                {
                    var builder = new ConfigurationBuilder()
                        .AddJsonFile("twiliosettings.json", optional: false,
                            reloadOnChange: true);
                    var configuration = builder.Build();

                    settings = new TwilioSettings
                    {
                        AccountSid = configuration["Twilio:AccountSid"],
                        AuthToken = configuration["Twilio:AuthToken"],
                        FromPhoneNumber = configuration["Twilio:FromPhoneNumber"]
                    };

                }
                return settings;
            }
        }

        public void SendSms(string from, string to, string body)
        {
            SendSms(to, body);
        }
        
        private void SendSms(string to, string body)
        {
            var accountSid = Settings.AccountSid;
            var authToken = Settings.AuthToken;
            var from = Settings.FromPhoneNumber;
            
            TwilioClient.Init(accountSid, authToken);
            var message = MessageResource.Create(
                body: body,
                from: new PhoneNumber(from),
                to: new PhoneNumber(to));
        }
    }
}