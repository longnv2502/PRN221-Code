using ProductCURD01.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductCURD01.ViewModel
{
    public class ProductVM : BaseVM
    {
        private ObservableCollection<Product> _List;
        public ObservableCollection<Product> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private Product _SelectedItem;
        public Product SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Name = SelectedItem.Name;
                }
            }
        }

        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }


        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public ProductVM()
        {
            List = new ObservableCollection<Product>(DataProvider.Ins.DB.Products);

            AddCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(Name))
                    return false;

                var displayList = DataProvider.Ins.DB.Products.Where(x => x.Name == Name);
                if (displayList == null || displayList.Count() != 0)
                    return false;

                return true;

            }, (p) =>
            {
                var product = new Product() { Name = Name };

                DataProvider.Ins.DB.Products.Add(product);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(product);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(Name) || SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.Products.Where(x => x.Name == Name);
                if (displayList == null || displayList.Count() != 0)
                    return false;

                return true;

            }, (p) =>
            {
                var product = DataProvider.Ins.DB.Products.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                product.Name = Name;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.Name = Name;
            });
        }
    }
}