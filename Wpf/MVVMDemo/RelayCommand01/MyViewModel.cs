using Persons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RelayCommand01
{
    public ObservableCollection<Persons> Persons;
    public ICommand DeleteCommand { get; set; }
    public ICommand AddCommand { get; set; }

    public MyViewModel()
    {
        Persons = new ObservableCollection<Persons>
        {
            new Persons{Name="Eros"},
            new Persons{Name="Tethys"},
            new Persons{Name="Atlas"},
            new Persons{Name="Apollo"},
            new Persons{Name="Hades"},
        };

        DeleteCommand = new RelayCommand<Persons>(
            (p) => p != null, // CanExecute()
            (p) => Persons.Remove(p) // Execute()
            );
        AddCommand = new RelayCommand<string>(
            (s) => true, // CanExecute()
            (s) => Persons.Add(new Persons { Name = s }) // Execute()
            );
    }
}
