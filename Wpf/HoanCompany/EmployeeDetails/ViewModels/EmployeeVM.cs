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
        //private EmployeeDetail _employeeDetail;

        //public EmployeeDetail EmployeeDetail
        //      {
        //	get { return _employeeDetail; }
        //	set { 
        //		_employeeDetail = value; 
        //		OnPropertyChanged(nameof(EmployeeDetail));
        //	}
        //}
        private ObservableCollection<EmployeeDetail> _lstemployeeDetail;

        public ObservableCollection<EmployeeDetail> LstEmployeeDetail
        {
            get { return _lstemployeeDetail; }
            set
            {
                _lstemployeeDetail = value;
                //OnPropertyChanged(nameof(LstEmployeeDetail));
                OnPropertyChanged();
            }
        }


        public EmployeeVM()
        {
            LstEmployeeDetail = new ObservableCollection<EmployeeDetail>(DataProvider.Ins.DB.EmployeeDetails);
        }


    }
}
