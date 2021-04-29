using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.CLRviaCSharpBook.Chapter10
{
    public sealed class BitArray
    {
        private Byte[] _byteArray;
        private Int32 _numBits;

        public BitArray(Int32 numBits)
        {
            if (numBits <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numBits), "numBits must be > 0");
            }

            this._numBits = numBits;
            this._byteArray = new Byte[(numBits + 7) / 8];
        }

        public Boolean this[Int32 bitPos]
        {
            get
            {
                if ((bitPos < 0) || (bitPos >= _numBits))
                {
                    throw new ArgumentOutOfRangeException("bitPos");
                }


                var left_side = _byteArray[bitPos / 8];
                var right_side = 1 << (bitPos % 8);
                var result = left_side & right_side;

                return result != 0;
            }

            set
            {
                if ((bitPos < 0) || (bitPos >= _numBits))
                {
                    throw new ArgumentOutOfRangeException("bitPos", bitPos.ToString());
                }

                if (value)
                {
                    //Turn the indexed bit on
                    var left_side = _byteArray[bitPos / 8];
                    var right_side = 1 << (bitPos % 8);
                    var result = left_side | right_side;


                    _byteArray[bitPos / 8] = (Byte)result;
                }
                else
                {
                    var left_side = _byteArray[bitPos / 8];

                    var right_side_prev = 1 << (bitPos % 8);
                    var right_side = ~right_side_prev;
                    var result = left_side | right_side;

                    //Turn the indexed bit off
                    _byteArray[bitPos / 8] = (Byte)result;
                }
            }
        }
    }
}
