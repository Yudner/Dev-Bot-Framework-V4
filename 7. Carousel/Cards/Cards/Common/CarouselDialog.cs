using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cards.Common
{
    public class CarouselDialog
    {
        public static async Task<DialogTurnResult> ShowOptions(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var option = await stepContext.PromptAsync(
              nameof(TextPrompt),
              new PromptOptions
              {
                  Prompt = CreateCarousel()
              },
              cancellationToken
            );
            return option;
        }
        private static Activity CreateCarousel()
        {
            var heroCard = new HeroCard
            {
                Title = "Bot Framework",
                Subtitle = "Microsoft Bot Framework V4",
                Images = new List<CardImage> { new CardImage("https://jarvischatbotstorage.blob.core.windows.net/images/Chat_Bot_Bot_Framework.png") },
                Buttons = new List<CardAction>()
                {
                    new CardAction(){Title = "Documentation", Value = "Documentation", Type = ActionTypes.ImBack},
                    new CardAction(){Title = "Report", Value = "Report", Type = ActionTypes.ImBack},
                    new CardAction(){Title = "Ir a la web", Value = "https://docs.microsoft.com/en-us/azure/bot-service/bot-builder-howto-add-media-attachments?view=azure-bot-service-4.0&tabs=csharp", Type = ActionTypes.OpenUrl},
                }
            };
            var heroCard2 = new HeroCard
            {
                Title = "Net Core",
                Subtitle = "Net Core",
                Images = new List<CardImage> { new CardImage("https://jarvischatbotstorage.blob.core.windows.net/images/netcore.png") },
                Buttons = new List<CardAction>()
                {
                    new CardAction(){Title = "Documentation", Value = "Documentation", Type = ActionTypes.ImBack},
                    new CardAction(){Title = "Report", Value = "Report", Type = ActionTypes.ImBack},
                    new CardAction(){Title = "Ir a la web", Value = "https://docs.microsoft.com/en-us/azure/bot-service/bot-builder-howto-add-media-attachments?view=azure-bot-service-4.0&tabs=csharp", Type = ActionTypes.OpenUrl},
                }
            };
            var optionsAttachments = new List<Attachment>()
            {
                heroCard.ToAttachment(),
                heroCard2.ToAttachment()
            };

            var reply = MessageFactory.Attachment(optionsAttachments);
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            return reply as Activity;
        }
    }
}
