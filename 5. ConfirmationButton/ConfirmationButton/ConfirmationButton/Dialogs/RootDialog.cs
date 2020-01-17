using ConfirmationButton.Common;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConfirmationButton.Dialogs
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
            AddDialog(new ConfirmPrompt(nameof(ConfirmPrompt), ConfirmValidate));
        }

        private async Task<DialogTurnResult> ShowOptions(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            //MOSTRAR OPCIONES DE CONFIRMACIÓN
            return await ConfirmButtonDialog.ShowOption(stepContext, cancellationToken);
        }
        private async Task<bool> ConfirmValidate(PromptValidatorContext<bool> promptContext, CancellationToken cancellationToken)
        {
            var option = promptContext.Recognized.Value;

            if (option)
                await promptContext.Context.SendActivityAsync("Tus datos han sido registrados", cancellationToken: cancellationToken);
            else
                await promptContext.Context.SendActivityAsync("Está bien, será la próxima", cancellationToken: cancellationToken);

            return true;
        }
        private async Task<DialogTurnResult> ConfirmOptions(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            return await stepContext.EndDialogAsync(cancellationToken: cancellationToken);
        }
    }
}
