using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.TextModel.CompositeConstructions
{
    public class Text
    {
        public static IList<Sentence> TextSentences { get; set; }

        public Text()
        {
            TextSentences = new List<Sentence>();
        }
    }
}
