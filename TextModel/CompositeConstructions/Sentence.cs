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
       public  IList<BaseSentenceComponent> SentenceComponents { get; private set; }
       public IEnumerable<BaseSentenceComponent> SentenceComponent { get { return SentenceComponents.AsEnumerable(); } }

        public Sentence(IList<BaseSentenceComponent> sentenceComponent)
        {
            SentenceComponents = sentenceComponent;
        }
        public void Add(BaseSentenceComponent _baseSentenceComponent)
        {
            SentenceComponents.Add(_baseSentenceComponent); 
        }
    
    }
}
