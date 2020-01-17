using Cards.Common;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cards.Dialogs
{
    public class RootDialog : ComponentDialog
    {
        public RootDialog()
        {
            var waterfallStep = new WaterfallStep[]
            {
                ShowHeroCardOption,
                ResponseOption
            };
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), waterfallStep));
            AddDialog(new TextPrompt(nameof(TextPrompt)));
        }

        private async Task<DialogTurnResult> ShowHeroCardOption(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            //MOSTRAR HERO CARD
            return await CarouselDialog.ShowOptions(stepContext, cancellationToken);
        }

        private async Task<DialogTurnResult> ResponseOption(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var option = stepContext.Context.Activity.Text;
            await stepContext.Context.SendActivityAsync($"Seleccionaste {option}", cancellationToken: cancellationToken);
            return await stepContext.EndDialogAsync(cancellationToken: cancellationToken);
        }
    }
}
