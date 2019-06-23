using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortMas
{
    class Tree
    {
        public double data;
        public Tree left, right;
        public Tree()
        {
            data = 0;
            left = null;
            right = null;
        }
        public Tree(double d)
        {
            data = d;
            left = null;
            right = null;
        }
        public override string ToString()
        {
            return data.ToString() + " ";
        }
    }
}
