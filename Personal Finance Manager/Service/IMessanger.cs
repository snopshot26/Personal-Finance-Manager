using Personal_Finance_Manager.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Manager.Service
{
    public interface IMessanger
    {
        void Subscribe<T>(Action<object> action) where T : IMessage;
        void Send<T>(T message) where T : IMessage;
    }
}
