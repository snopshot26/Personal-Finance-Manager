using Personal_Finance_Manager.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Manager.Service
{
    public class Messanger : IMessanger
    {
        private readonly Dictionary<Type, List<Action<object>>> _subscribers = new();

        public void Subscribe<T>(Action<object> action) where T : IMessage
        {
            var messageType = typeof(T);
            if (!_subscribers.ContainsKey(messageType))
            {
                _subscribers[messageType] = new List<Action<object>>();
            }
            _subscribers[messageType].Add(action);
        }
        public void Send<T>(T message) where T : IMessage
        {
            var messageType = typeof(T);
            if (_subscribers.ContainsKey(messageType))
            {
                foreach (var action in _subscribers[messageType])
                {
                    action.Invoke(message);
                }
            }
        }
    }
}
