using Personal_Finance_Manager.MVVM_tools;
using Personal_Finance_Manager.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Manager.ViewModel
{
    public class RegistrationViewModel : BaseViewModel
    {
        public IMessanger Messenger { get; set; }
        public RegistrationViewModel(IMessanger messenger)
        {
            this.Messenger = messenger;
        }
        
    }
}
