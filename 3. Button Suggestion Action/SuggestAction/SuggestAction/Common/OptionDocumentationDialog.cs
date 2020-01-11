using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SuggestAction.Common
{
    public class OptionDocumentationDialog
    {
        public static async Task<DialogTurnResult> ShowOptions(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var options = await stepContext.PromptAsync(
               nameof(TextPrompt),
               new PromptOptions
               {
                   Prompt = CreateSuggestedActions()
               },
               cancellationToken
            );
            return options;
        }
        private static Activity CreateSuggestedActions()
        {
            var reply = MessageFactory.Text("¿De qué plataforma deseas información?");

            reply.SuggestedActions = new SuggestedActions()
            {
                Actions = new List<CardAction>()
                {
                    new CardAction(){Title = ".NET", Value = ".NET", Type = ActionTypes.ImBack},
                    new CardAction(){Title = "JavaScript", Value = "JavaScript", Type = ActionTypes.ImBack},
                    new CardAction(){Title = "Python", Value = "Python", Type = ActionTypes.ImBack}
                }
            };
            return reply;
        }
    }
}
