using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.CLRviaCSharpBook.Chapter11
{
    internal class NewMailEventArgs : EventArgs
    {
        //Fields
        private readonly String _from;
        private readonly String _to;
        private readonly String _subject;

        public NewMailEventArgs(String from, String to, String subject)
        {
            this._from = from;
            this._to= to;
            this._subject = subject;
        }

        //Properties
        public String From
        {
            get { return _from; }
        }

        public String To
        {
            get { return _to; }
        }
        public String Subject
        {
            get { return _subject; }
        }
    }
}
