using System;
using System.Windows.Input;
using CRM.Data.Models;
using CRM.DesktopClient.Commands;

namespace CRM.DesktopClient.ViewModels
{
    public class AddCustomerViewModel : BaseViewModel
    {
        private readonly Action<Customer> _addCustomer;
        private readonly Action _changeToMainCustomerView;
        private string _address;
        private string _firstName;
        private string _lastName;
        private string _mail;
        private string _phoneNumber;


        public AddCustomerViewModel(Action changeToMainCustomerView, Action<Customer> addCustomer)
        {
            _changeToMainCustomerView = changeToMainCustomerView;
            _addCustomer = addCustomer;
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string Mail
        {
            get => _mail;
            set
            {
                _mail = value;
                OnPropertyChanged(nameof(Mail));
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public ICommand AddCustomerCommand
        {
            get { return new BaseCommand(p => AddCustomer(), p => CanAddCustomer); }
        }

        public bool CanAddCustomer => true;

        public ICommand CancelAddingCommand
        {
            get { return new BaseCommand(p => CallChangeToCustomerView(), p => true); }
        }

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
            var customer = new Customer
            {
                CustomerId = new Guid(),
                Address = Address,
                FirstName = FirstName,
                LastName = LastName,
                Mail = Mail,
                PhoneNumber = PhoneNumber
            };
            CallAddCustomer(customer);
            CallChangeToCustomerView();
        }
    }
}