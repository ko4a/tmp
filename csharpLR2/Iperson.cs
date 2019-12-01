using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpLR2
{
    interface IPerson
    {
        string Name { get; }
        string Patronomic { get; }
        string Lastname { get; }
        DateTime Date { get; }
        int Age { get; }
    }
}
