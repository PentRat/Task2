using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.TextModel.CompositeConstructions
{
    public class Text
    {
        private readonly IList<BaseTextComponent> _components = new List<BaseTextComponent>();
        public IEnumerable<BaseTextComponent> TextComponents => _components.AsEnumerable();
        
        public void Add(BaseTextComponent baseTextComponent)
        {
            _components.Add(baseTextComponent);
        }

    }
}
