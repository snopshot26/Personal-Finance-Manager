using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Manager.View
{
    public partial class MainView : System.Windows.Window
    {
        public MainView()
        {
            InitializeComponent();
            // Set the DataContext to the MainViewModel
            this.DataContext = App.MainViewModel;
        }
        private void InitializeComponent()
        {
            // Here you would typically load the XAML for the view
            // For example, using a XAML file like "MainView.xaml"
            // this.Content = new System.Windows.Markup.XamlReader().Load("MainView.xaml");
        }
    }
}
