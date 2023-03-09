using EmployeeDetails.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetails.ViewModels
{
    public class EmployeeVM : BaseVM
    {

        private ObservableCollection<EmployeeDetail> _lstemployeeDetail;

        public ObservableCollection<EmployeeDetail> LstEmployeeDetail
        {
            get { return _lstemployeeDetail; }
            set
            {
                _lstemployeeDetail = value;
                OnPropertyChanged(nameof(LstEmployeeDetail));
            }
        }


        public EmployeeVM()
        {
            LoadEmployee();
        }
        private void LoadEmployee() {
            LstEmployeeDetail = new ObservableCollection<EmployeeDetail>(DataProvider.Ins.DB.EmployeeDetails);
        }
        private void Delete(object obj)
        {
            var emp = obj as EmployeeDetail;
            DataProvider.Ins.DB.EmployeeDetails.Remove(emp);
        }

    }
}
