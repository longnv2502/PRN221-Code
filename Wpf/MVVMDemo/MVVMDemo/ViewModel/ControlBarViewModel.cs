using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MVVMDemo.ViewModel
{
    public class ControlBarViewModel : RootViewModel
    {
        public ICommand CloseWindowCommand { get; set; }
        public ICommand ClickButtonCommand { get; set; }
        public ControlBarViewModel()
        {
            
            ClickButtonCommand = new RelayCommand<Button>(
                (p) => { return true; },
                (p) =>
                {
                   p.Content = "TEST CLICK";
                }
            );
            CloseWindowCommand = new RelayCommand<UserControl>(
                (p) => { return true; }, 
                (p) =>
                {
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
