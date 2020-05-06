using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Data.Models;

namespace CRM.DesktopClient.ViewModels
{
    public class CustomerListViewModel:BaseViewModel
    {
        private ObservableCollection<Customer> _customers = null;
        private Customer _selectedCustomer;
        public CustomerListViewModel()
        {
        }
        public ObservableCollection<Customer> Customers
        {
            get => GetCustomers();
            set
            {
                _customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }

        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));
            }

        }

        internal ObservableCollection<Customer> GetCustomers()
        {
            if (_customers == null)
                _customers = new ObservableCollection<Customer>();
            _customers.Clear();
            _customers.Add(new Customer()
            {
                CustomerId = new Guid(),
                FirstName = "Mikolaj",
                LastName = "Fitowski",
            });
            _customers.Add(new Customer()
            {
                CustomerId = new Guid(),
                FirstName = "Mikolaj",
                LastName = "Fitowski",
            });
            return _customers;
        }
    }
}
