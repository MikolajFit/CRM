using System;
using CRM.Data.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace CRM.DesktopClient.ViewModels
{
    public class AddCustomerViewModel : ViewModelBase
    {
        private readonly Action<Customer> _addCustomer;
        private readonly Action _changeToMainCustomerView;
        private Customer _newCustomer;

        public AddCustomerViewModel(Action changeToMainCustomerView, Action<Customer> addCustomer)
        {
            _changeToMainCustomerView = changeToMainCustomerView;
            _addCustomer = addCustomer;
            AddCustomerCommand = new RelayCommand(AddCustomer);
            CancelAddingCommand = new RelayCommand(CallChangeToCustomerView);
            _newCustomer = new Customer();
        }

        public Customer NewCustomer
        {
            get => _newCustomer;
            set { Set(() => NewCustomer, ref _newCustomer, value); }
        }

        public RelayCommand AddCustomerCommand { get; }
        public RelayCommand CancelAddingCommand { get; }

        public void CallAddCustomer(Customer customer)
        {
            _addCustomer.Invoke(customer);
        }

        public void CallChangeToCustomerView()
        {
            _changeToMainCustomerView.Invoke();
        }

        public void AddCustomer()
        {
            _newCustomer.CustomerId = Guid.NewGuid();
            CallAddCustomer(NewCustomer);
            _newCustomer = new Customer();
            CallChangeToCustomerView();
        }
    }
}