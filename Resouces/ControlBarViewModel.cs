using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MVVM.ViewModel
{
    public class ControlBarViewModel : RootViewModel
    {
        public ICommand CloseWindowCommand { get; set; }
        public ControlBarViewModel() 
        {
            CloseWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {
                FrameworkElement window = getWindowParent(p);
                var w = window as Window;
                if (w != null)
                {
                    w.Close();
                }
            }
            );
        }
        FrameworkElement getWindowParent(UserControl p) 
        {
            FrameworkElement parent = p;
            while (parent.Parent != null) 
            {
                parent = parent.Parent as FrameworkElement;
            }
            return parent;
        }
    }
}
