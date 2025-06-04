using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Manager.Message
{
    internal class NavigationMessage : IMessage
    {
        public Type ViewModelType { get; set; }
    }
}
