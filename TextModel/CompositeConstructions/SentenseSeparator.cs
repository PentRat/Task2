using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.TextModel.CompositeConstructions
{
    class SentenseSeparator : BaseTextComponent
    {
     
        public char Separator { get; set; }

        public SentenseSeparator(char separator)
        {
            Separator = separator;
        }
    }
}
