using Microsoft.Bot.Builder.AI.Luis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatbotLUIS.Infrastructure
{
    public interface ILuisRecognizerService
    {
        LuisRecognizer _recognizer { get; }
    }
}
