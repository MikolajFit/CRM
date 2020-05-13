using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Data.Models;
using GalaSoft.MvvmLight;

namespace CRM.DesktopClient.ViewModels
{
    public class CustomerDetailViewModel:ViewModelBase
    {
        public string DisplayName => $@"{SelectedCustomer.FirstName} {SelectedCustomer.LastName}";

        private Customer _selectedCustomer;

        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set { Set(() => SelectedCustomer, ref _selectedCustomer, value); }
        }
    }
}
