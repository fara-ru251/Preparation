using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.CLRviaCSharpBook
{
    internal sealed class InlineArray
    {
        public static void StackallocDemo()
        {
            unsafe
            {
                const int width = 20;
                char* pc = stackalloc char[width];

                string s = "Jeffrey Richter";

                for (int index = 0; index < width; index++)
                {
                    pc[width - 1 - index] = (index < s.Length) ? s[index] : '.';
                }

                Console.WriteLine(new string(pc, 0, width));
            }
        }

        public static void InlineArrayDemo()
        {
            unsafe
            {
                CharArray ca;
                int widthInBytes = sizeof(CharArray);

                int char_size = sizeof(char);
                int width = widthInBytes / char_size;

                string s = "Jeffrey Richter";

                for (int i = 0; i < width; i++)
                {
                    ca.Characters[width - 1 - i] = (i < s.Length) ? s[i] : '.';
                }

                Console.WriteLine(new String(ca.Characters, 0, width));
            }
        }
    }

    internal unsafe struct CharArray
    {
        public fixed char Characters[20];
    }
}
