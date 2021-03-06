﻿using PoroLib.Structures;
using RtmpSharp.Messaging;

namespace PoroLib.Messages.LoginService
{
    class Login : IMessage
    {
        public RemotingMessageReceivedEventArgs HandleMessage(object sender, RemotingMessageReceivedEventArgs e)
        {
            object[] body = e.Body as object[];
            AuthenticationCredentials creds = body[0] as AuthenticationCredentials;

            Session session = new Session
            {
                Password = creds.Password,
                Summary = new AccountSummary
                {
                    AccountId = 1.0,
                    Username = creds.Username,
                    HasBetaAccess = true,
                    IsAdministrator = false,
                    PartnerMode = false,
                    NeedsPasswordReset = false
                },
                Token = "fake"
            };

            e.ReturnRequired = true;
            e.Data = session;

            return e;
        }
    }
}
