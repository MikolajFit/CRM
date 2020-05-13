
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Data.Models;
using GalaSoft.MvvmLight;

namespace CRM.DesktopClient.ViewModels
{
    public class CustomerListViewModel:ViewModelBase
    {
        private ObservableCollection<Customer> _customers = null;
        private Customer _selectedCustomer;
        public CustomerListViewModel()
        {
            _customers = GetCustomers();
        }
        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set { Set(() => Customers, ref _customers, value); }
        }

        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set { Set(() => SelectedCustomer, ref _selectedCustomer, value); }

        }

        internal ObservableCollection<Customer> GetCustomers()
        {
            if (_customers == null)
                _customers = new ObservableCollection<Customer>();
            _customers.Clear();
            _customers.Add(new Customer()
            {
                CustomerId = Guid.NewGuid(),
                FirstName = "Mikolaj",
                LastName = "Fitowski",
            });
            _customers.Add(new Customer()
            {
                CustomerId = Guid.NewGuid(),
                FirstName = "Mikolaj",
                LastName = "Fitowski",
            });
            return _customers;
        }

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
            RaisePropertyChanged(nameof(Customers));
        }
    }
}
