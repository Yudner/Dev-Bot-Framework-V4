using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConfirmationButton.Common
{
    public class ConfirmButtonDialog
    {
        public static async Task<DialogTurnResult> ShowOption(WaterfallStepContext stepContext, CancellationToken cancellation)
        {
            var options = await stepContext.PromptAsync(
              nameof(ConfirmPrompt),
              new PromptOptions
              {
                  Prompt = MessageFactory.Text("¿Aceptas los términos y condiciones?"),
                  Style = ListStyle.SuggestedAction
              }
            );
            return options;
        }
    }
}
