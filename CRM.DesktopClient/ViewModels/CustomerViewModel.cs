using System;
using CRM.Data.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace CRM.DesktopClient.ViewModels
{
    public class CustomerViewModel : ViewModelBase
    {
        private readonly Action<Customer> _addCustomer;
        private readonly Action _changeToMainCustomerView;
        private Customer _selectedCustomer;
        private Mode _currentMode;

        public CustomerViewModel(Action changeToMainCustomerView, Action<Customer> addCustomer)
        {
            _changeToMainCustomerView = changeToMainCustomerView;
            _addCustomer = addCustomer;
            UpdateCustomerCommand = new RelayCommand(AddCustomer);
            CancelCommand = new RelayCommand(CallChangeToCustomerView);
            _selectedCustomer = new Customer();
        }

        public Mode CurrentMode
        {
            get => _currentMode;
            set { Set(() => CurrentMode, ref _currentMode, value); }
        }

        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set { Set(() => SelectedCustomer, ref _selectedCustomer, value); }
        }

        public RelayCommand UpdateCustomerCommand { get; }
        public RelayCommand CancelCommand { get; }

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
            if(CurrentMode==Mode.Add) 
                SelectedCustomer.CustomerId = Guid.NewGuid();

            CallAddCustomer(SelectedCustomer);
            _selectedCustomer = new Customer();
            CallChangeToCustomerView();
        }
    }
}