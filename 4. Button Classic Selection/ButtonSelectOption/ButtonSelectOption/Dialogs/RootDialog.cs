using ButtonSelectOption.Common;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ButtonSelectOption.Dialogs
{
    public class RootDialog: ComponentDialog
    {
        public RootDialog()
        {
            var waterfallSteps = new WaterfallStep[]
            {
                ShowOptions,
                ConfirmOptions
            };

            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), waterfallSteps));
            AddDialog(new ChoicePrompt(nameof(ChoicePrompt)));
        }

        private async Task<DialogTurnResult> ShowOptions(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            //MOSTRAR OPCIONES
            return await OptionButtonDialog.ShowOptions(stepContext, cancellationToken);
        }

        private async Task<DialogTurnResult> ConfirmOptions(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var option = stepContext.Context.Activity.Text;
            switch (option)
            {
                case "Azure":
                    await stepContext.Context.SendActivityAsync("Seleccionaste Azure", cancellationToken: cancellationToken);
                    break;
                case "AWS":
                    await stepContext.Context.SendActivityAsync("Seleccionaste AWS", cancellationToken: cancellationToken);
                    break;
                case "Google Cloud":
                    await stepContext.Context.SendActivityAsync("Seleccionaste Google Cloud", cancellationToken: cancellationToken);
                    break;
                default:
                    break;
            }
            return await stepContext.EndDialogAsync(cancellationToken: cancellationToken);
        }
    }
}
