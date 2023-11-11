using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prakt5
{
    internal class SortByRunningResult : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.CompareTo(y);
        }
    }
}
