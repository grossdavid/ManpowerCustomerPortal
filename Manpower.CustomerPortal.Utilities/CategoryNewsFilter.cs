using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.DataAbstraction;

namespace Sapa.Intranet.Utilities
{
    public class CategoryNewsFilter : INewsFilter
    {
        public CategoryNewsFilter()
        {
        }

        public CategoryNewsFilter(Category category)
        {
            Category = category;
        }

        public Category Category { get; set; }

        public string Text
        {
            get { return Category != null ? Category.Name : null; }
        }

        public string Value
        {
            get { return Category != null ? "c:" + Category.Name + "_" + Category.ID: null; }
        }

        public bool Selected { get; set; }
    }
}
