using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.CLRviaCSharpBook.Chapter15_BitFlags
{
    //[Flags]
    internal enum Actions
    {
        None = 0,
        Read = 0x0001,
        Write = 0x0002,
        ReadWrite = Read | Write,
        Delete = 0x0004,
        Query = 0x0008,
        Sync = 0x0010
    }
}
