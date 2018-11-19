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
       private readonly IList<BaseSentenceComponent> _components = new List<BaseSentenceComponent>();
       public IEnumerable<BaseSentenceComponent>  SentenceComponents => _components.AsEnumerable();
       public int WordsCount { get; private set; }

        public Sentence(IList<BaseSentenceComponent> sentenceComponents)
        {
            foreach (var sentenceComponent in sentenceComponents)
            {
                Add(sentenceComponent);
            }
        }

        public void Add(BaseSentenceComponent baseSentenceComponent)
        {
            if (baseSentenceComponent is Word)
            { WordsCount++; }
            _components.Add(baseSentenceComponent);
        }
    
    }
}
