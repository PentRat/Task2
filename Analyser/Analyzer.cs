using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.TextModel.CompositeConstructions;
using Task2.TextModel.SimpleConstructions;

namespace Task2.Analyser
{
    public class Analyzer
    {
        public List<Sentence> SortByWordsCount(Text text)
        {
            var orderedSentences = text.TextComponents
            .Select(x => x as Sentence)
            .Where(x => x != null)
            .OrderBy(x => x.WordsCount)
            .ToList();
            return orderedSentences;
        }
    }
}
