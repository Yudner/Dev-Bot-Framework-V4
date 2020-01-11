using Microsoft.Bot.Builder.Dialogs;
using SuggestAction.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SuggestAction.Dialogs
{
    public class RootDialog: ComponentDialog
    {
        public RootDialog()
        {
            var waterfallStep = new WaterfallStep[]
            {
                ShowOptions,
                ShowDocumentation
            };
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), waterfallStep));
            AddDialog(new TextPrompt(nameof(TextPrompt)));
        }

        private async Task<DialogTurnResult> ShowOptions(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            //MOSTRAR BOTONES
            return await OptionDocumentationDialog.ShowOptions(stepContext, cancellationToken);
        }

        private async Task<DialogTurnResult> ShowDocumentation(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var option = stepContext.Context.Activity.Text;
            switch (option)
            {
                case ".NET":
                    await stepContext.Context.SendActivityAsync("Documentación .NET: https://docs.microsoft.com/en-us/azure/bot-service/dotnet/bot-builder-dotnet-sdk-quickstart?view=azure-bot-service-4.0", cancellationToken: cancellationToken);
                    break;
                case "JavaScript":
                    await stepContext.Context.SendActivityAsync("Documentación JavaScript: https://docs.microsoft.com/en-us/azure/bot-service/javascript/bot-builder-javascript-quickstart?view=azure-bot-service-4.0", cancellationToken: cancellationToken);
                    break;
                case "Python":
                    await stepContext.Context.SendActivityAsync("Documentación Python: https://docs.microsoft.com/en-us/azure/bot-service/python/bot-builder-python-quickstart?view=azure-bot-service-4.0", cancellationToken: cancellationToken);
                    break;
                default:
                    break;
            }
            return await stepContext.EndDialogAsync(cancellationToken: cancellationToken);
        }
    }
}
