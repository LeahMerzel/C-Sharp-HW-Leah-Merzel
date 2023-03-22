using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leah_s_HomeWork.HW10_Store
{
    public class Category
    {
        private static int _counter = 0;
        public int CategoryId { get; }
        public string Name { get; set; }
        public int ParentCategoryId { get; set; }

        public Category(string name, int parentCategoryId) : this()
        {
            Name = name;
            ParentCategoryId = parentCategoryId;
        }
        public Category(string name) : this()
        {
            Name = name;
        }

        public Category()
        {
            _counter++;
            CategoryId = _counter;
        }
        public override string ToString()
        {
            return CategoryId + " " + Name + " " + ParentCategoryId;
        }
    }
}
