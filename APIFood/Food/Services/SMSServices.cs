using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Microsoft.Extensions.Configuration;

namespace Food.Services
{
    public class SMSServices
    {
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _fromPhoneNumber;
        public SMSServices(IConfiguration configuration)
        {
            _accountSid = configuration["Twilio:AccountSid"];
            _authToken = configuration["Twilio:AuthToken"];
            _fromPhoneNumber = configuration["Twilio:FromPhoneNumber"];
        }

        public void SendSms(string to, string message)
        {
            TwilioClient.Init(_accountSid, _authToken);

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber(to))
            {
                From = new PhoneNumber(_fromPhoneNumber),
                Body = message,
            };

            MessageResource.Create(messageOptions);
        }
    }
}
