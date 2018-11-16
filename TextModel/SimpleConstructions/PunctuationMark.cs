using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.TextModel.SimpleConstructions
{
    public class PunctuationMark : BaseSentenceComponent
    {
        public static IList<char> SymbolCombination { get; set; }

        public PunctuationMark(IList<char> symbolCombination)
        {
            SymbolCombination = symbolCombination;
        }

    }
}
