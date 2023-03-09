using PersonCRUD.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PersonCRUD.ViewModel
{
    public class PersonVM :BaseVM
    {
        public ObservableCollection<Person> Persons { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public PersonVM()
        {
            Persons = new ObservableCollection<Person>
        {
            new Person{Name="Eros"},
            new Person{Name="Tethys"},
            new Person{Name="Atlas"},
            new Person{Name="Apollo"},
            new Person{Name="Hades"},
        };

            DeleteCommand = new RelayCommand<Person>(
                (p) => p != null, // CanExecute()
                (p) => Persons.Remove(p) // Execute()
                );
            AddCommand = new RelayCommand<string>(
                (s) => true, // CanExecute()
                (s) => Persons.Add(new Person { Name = s }) // Execute()
                );
        }
    }
}
