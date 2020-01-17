using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ButtonSelectOption.Common
{
    public class OptionButtonDialog
    {
        public static async Task<DialogTurnResult> ShowOptions(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var option = await stepContext.PromptAsync(
              nameof(ChoicePrompt),
              new PromptOptions
              {
                  Prompt = MessageFactory.Text("Selecciona la nube de tu preferencia"),
                  Choices = ChoiceFactory.ToChoices(new List<string> {"Azure", "AWS", "Google Cloud" }),
                  Style = ListStyle.HeroCard
              },
              cancellationToken
            );
            return option;
        }
    }
}
