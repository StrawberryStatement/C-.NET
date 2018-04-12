using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapecity_Code
{
    interface ISort
    {
        void Sort();
        int GetLength();
        Queue<int[]> arrayNow { get; }
    }
}
