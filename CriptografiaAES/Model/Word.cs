using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriptografiaAES.Model
{
    internal class Word
    {
        public byte[] Bytes { get; set; }

        public Word(byte[] Bytes)
        {
            this.Bytes = Bytes;
        }
    }
}
