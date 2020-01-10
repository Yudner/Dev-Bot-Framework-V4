using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TextFlow.Dialogs
{
    public class RootDialog: ComponentDialog
    {
        public RootDialog()
        {
            var waterfallStep = new WaterfallStep[]
            {
                SetName,
                SetAge,
                ShowData
            };

            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), waterfallStep));
            AddDialog(new TextPrompt(nameof(TextPrompt)));
            AddDialog(new NumberPrompt<int>(nameof(NumberPrompt<int>), ValidateAge));
        }

        private async Task<bool> ValidateAge(PromptValidatorContext<int> promptContext, CancellationToken cancellationToken)
        {
            return await Task.FromResult(
              promptContext.Recognized.Succeeded &&
              promptContext.Recognized.Value > 0 &&
              promptContext.Recognized.Value < 150
            );
        }

        private async Task<DialogTurnResult> SetName(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Para iniciar una conversación necesito algunos datos.", cancellationToken: cancellationToken);
            await Task.Delay(1000);
            return await stepContext.PromptAsync(
              nameof(TextPrompt),
              new PromptOptions { Prompt = MessageFactory.Text("Por favor ingresa tu nombre")},
              cancellationToken
            );
        }

        private async Task<DialogTurnResult> SetAge(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var name = stepContext.Context.Activity.Text;
            return await stepContext.PromptAsync(
                nameof(NumberPrompt<int>),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text($"Bien {name}, ahora necesito tu edad"),
                    RetryPrompt = MessageFactory.Text($"{name}, Por favor ingresa una edad válida")
                },
                cancellationToken
                );
        }

        private async Task<DialogTurnResult> ShowData(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Genial, gracias por registrar tus datos.", cancellationToken: cancellationToken);
            return await stepContext.EndDialogAsync(cancellationToken: cancellationToken);
        }
    }
}
