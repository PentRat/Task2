using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.TextModel.SimpleConstructions
{
    public class InSentenseSeparator : BaseSentenceComponent
    {
        public char Separator { get; private set; }

        public InSentenseSeparator(char separator)
        {
            Separator = separator;
        }

    }
}
