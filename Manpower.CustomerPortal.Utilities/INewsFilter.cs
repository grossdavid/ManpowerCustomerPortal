using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapa.Intranet.Utilities
{
    public interface INewsFilter
    {
        string Text { get; }
        string Value { get; }
        bool Selected { get; set; }
    }
}
