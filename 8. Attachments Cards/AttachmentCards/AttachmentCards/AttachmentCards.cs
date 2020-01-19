// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AttachmentCards.Common;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace AttachmentCards
{
    public class AttachmentCards : ActivityHandler
    {
        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text($"Hello world!"), cancellationToken);
                }
            }
        }
        public override Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default)
        {
            return base.OnTurnAsync(turnContext, cancellationToken);
        }
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            var message = turnContext.Activity.Text.ToLower();

            if (message.Equals("imagen"))
                await turnContext.SendActivityAsync(AttachmentCard.GetImageGIF(), cancellationToken);

            else if (message.Equals("video"))
                await turnContext.SendActivityAsync(AttachmentCard.GetVideo(), cancellationToken);

            else if (message.Equals("audio"))
                await turnContext.SendActivityAsync(AttachmentCard.GetAudio(), cancellationToken);

            else if (message.Equals("documento"))
                await turnContext.SendActivityAsync(AttachmentCard.GetDocumento(), cancellationToken);

            else
                await turnContext.SendActivityAsync("Opción no válida", cancellationToken: cancellationToken);

        }
    }
}
