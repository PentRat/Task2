using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.TextModel.SimpleConstructions
{
    public class Word : BaseSentenceComponent
    {
        public IList<char> Letters { get; set;}

        public Word(IList<char> letters)
        {
            Letters = letters;
        }
    }
}
