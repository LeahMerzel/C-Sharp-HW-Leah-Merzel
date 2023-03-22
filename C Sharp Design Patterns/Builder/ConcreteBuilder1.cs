using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Design_Patterns.Builder
{
    public class ConcreteBuilder1 : Builder
    {
        private Product _product = new Product();
        public override void BuildPartA()
        {
            _product.Add("Part A");
        }

        public override void BuildPartB()
        {
            _product.Add("Part B");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }
}
