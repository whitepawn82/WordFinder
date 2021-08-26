using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QU_test_01
{
    public class WordDetailDTO
    {
        public int Position { get; private set; }
        public int Count { get; private set; }

        public WordDetailDTO(int position, int count)
        {
            Position = position;
            Count = count;
        }

        internal void SetValue(int count, int i)
        {
            Position = i;
            Count = count;
        }
    }
}
