using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.CLRviaCSharpBook.Chapter14_String
{
    internal sealed class CharTest
    {
        char c_min = char.MinValue;

        char c_max = char.MaxValue;

        public void CheckFor(char c)
        {
            var category = char.GetUnicodeCategory(c_max);

            var new_c = char.ToLowerInvariant(c_max);

            var culture = System.Globalization.CultureInfo.CurrentCulture;

            char turkish_char = '\u0069';


        }

        

    }
}
