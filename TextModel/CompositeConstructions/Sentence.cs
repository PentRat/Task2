using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.TextModel.SimpleConstructions;

namespace Task2.TextModel.CompositeConstructions
{
    public class Sentence : BaseTextComponent
    {
        public static IList<BaseSentenceComponent> BasicSentenceComponents { get; set; }

        public Sentence()
        {
            BasicSentenceComponents = new List<BaseSentenceComponent>();
        }
    }
}
