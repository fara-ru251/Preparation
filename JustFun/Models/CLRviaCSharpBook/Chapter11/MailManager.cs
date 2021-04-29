using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustFun.Models.CLRviaCSharpBook.Chapter11
{
    internal class MailManager
    {

        //define event member with already defined delegate layout
        public event EventHandler<NewMailEventArgs> NewMail;


        //define method for raising event to notify registered objects, that event has occurred
        //if class "sealed" make this method "private nonvirtual"
        protected virtual void OnNewMail(NewMailEventArgs e)
        {
            EventHandler<NewMailEventArgs> handler = Volatile.Read(ref NewMail);

            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void SimulateNewMail(String from, String to, String subject)
        {
            NewMailEventArgs newMail = new NewMailEventArgs(from, to, subject);

            OnNewMail(newMail);
        }

        public void GenericMethodParamWithDefaultValue<T>(T t = default(T))
        {
        }
    }
}
