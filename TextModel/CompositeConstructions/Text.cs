using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.TextModel.CompositeConstructions
{
    public class Text
    {
        public static IList<BaseTextComponent> TextComponents { get; set; }

        public Text()
        {
            TextComponents = new List<BaseTextComponent>();
        }
    }
}
