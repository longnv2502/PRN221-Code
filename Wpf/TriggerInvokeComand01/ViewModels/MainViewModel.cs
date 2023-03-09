using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TriggerInvokeComand01.Commands;

namespace TriggerInvokeComand01.ViewModels
{
    public class MainViewModel
    {

        public ICommand ExitCommand { get; }
        public ICommand OnViewLoadedCommand { get; }
        public ICommand LeftMouseButtonDownCommand { get; }
        public ICommand CmdSelectionLengthChangedCommand { get; set; }


        public MainViewModel()
        {
            ExitCommand = new RelayCommand(Exit);
            OnViewLoadedCommand = new RelayCommand(OnViewLoaded);
            LeftMouseButtonDownCommand = new RelayCommand(LeftMouseButtonDown);
            CmdSelectionLengthChangedCommand = new RelayCommand<TextBox>(
            p => {
                MessageBox.Show(""+p.SelectionLength);
                }
            ,
            p => { return p.SelectionLength > 4; }
            );
        }
        private void Exit()
        {
            Application.Current.Shutdown();
        }
        private void OnViewLoaded()
        {
            MessageBox.Show("Load load load");
        }
        private void LeftMouseButtonDown()
        {
            MessageBox.Show("Responding to left mouse button click event...");

        }

    }
}
